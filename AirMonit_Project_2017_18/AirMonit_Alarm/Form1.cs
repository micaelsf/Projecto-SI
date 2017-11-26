using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace AirMonit_Alarm
{
    public partial class Form1 : Form
    {
        private MqttClient mClient;
        private string[] topics = { "data", "alarm" };
        private IPAddress ipAddress;
        private XMLHandler xmlhandler;

        private string selectedParameter;
        private string selectedCondition;
        private string[] values;

        private string[] oldValues;
        private string oldDescription;
        private bool isCreatingRule;

        public Form1()
        {
            InitializeComponent();
            xmlhandler = new XMLHandler(this);

            SensorData sensorData = new SensorData();

            labelInvalidIp.Visible = false;
            labelStatus.Text = "Disconnected";
            textBoxIpAddress.Text = "127.0.0.1";

            comboBoxParameters.Items.AddRange(xmlhandler.GetActiveParameters());
            comboBoxParameters.SelectedIndex = 0;
            textBoxConditionValueMax.Visible = false;
            labelTextAND.Visible = false;
            comboBoxCreateCondition.Visible = false;

            this.selectedParameter = comboBoxParameters.SelectedItem.ToString();
            this.selectedCondition = comboBoxActiveConditions.SelectedItem.ToString();

            this.isCreatingRule = false;

            checkBoxCheck();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (!xmlhandler.IsValidXmlRules)
            {
                MessageBox.Show("XML rules file is not valid.");
                return;
            }

            if (AreChangedFields())
            {
                DialogResult result = MessageBox.Show("You have unsaved changes, if you want to save them, please press 'Yes' and save the changes before start your alarm application.", 
                            "Warning",
                            MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    return;
                }
                if (result == DialogResult.No)
                {
                    RollbackFieldsValues();
                }
            }

            bool validIP;

            validIP = IPAddress.TryParse(textBoxIpAddress.Text, out ipAddress);

            labelStatus.Text = "Connected";

            if (validIP)
            {
                labelInvalidIp.Visible = false;

                mClient = new MqttClient(textBoxIpAddress.Text);

                mClient.Connect(Guid.NewGuid().ToString());

                mClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

                byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE };//QoS
                mClient.Subscribe(topics, qosLevels);

                if (!mClient.IsConnected)
                {
                    MessageBox.Show("Error connecting to message broker...");
                    return;
                }
            }
            else
            {
                labelInvalidIp.Visible = true;
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            if (mClient != null && mClient.IsConnected)
            {
                labelStatus.Text = "Disconnected";
                mClient.Unsubscribe(topics);
                mClient.Disconnect(); //Free process and process's resources
            }
            mClient = null;

        }

        private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string dataStr = xmlhandler.ParseXMLData(Encoding.UTF8.GetString(e.Message));

            if (dataStr == null)
            {
                Debug.WriteLine(xmlhandler.ValidationMessage);
                return;
            }

            this.Invoke((MethodInvoker)delegate ()
            {
                listBoxData.Items.Insert(0, dataStr + Environment.NewLine);
            });

            // if e.message arrives here, it means it is already validated
            xmlhandler.ValidateParameters(Encoding.UTF8.GetString(e.Message));
        }

        public void PublishAlarm(string outerXML)
        {
            // now every rules are validated and alarms triggered, lets publish the alarms
            if (mClient == null || !mClient.IsConnected)
            {
                MessageBox.Show("Error connecting to message broker...");
                return;
            }

            if (outerXML == null)
            {
                MessageBox.Show("Created alarm is not valid");
                return;
            }

            mClient.Publish("alarm", Encoding.UTF8.GetBytes(outerXML));

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(outerXML);

            this.Invoke((MethodInvoker)delegate ()
            {
                listBoxAlarms.Items.Insert(0, 
                    "City: " +  doc.GetElementsByTagName("AirMonitParam")[0].SelectSingleNode("city").InnerText +
                    ", Value: " + doc.GetElementsByTagName("AirMonitParam")[0].SelectSingleNode("value").InnerText + 
                    ", " + doc.GetElementsByTagName("description")[0].InnerText +
                    Environment.NewLine);
            });
            Debug.WriteLine("\nPUBLISHED: " + outerXML + "\n\n");
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            if (mClient != null && mClient.IsConnected)
            {
                labelStatus.Text = "Disconnected";
                mClient.Unsubscribe(topics);
                mClient.Disconnect(); //Free process and process's resources
            }
            mClient = null;
        }

        private void comboBoxParameters_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedParameter = comboBoxParameters.SelectedItem.ToString();
            labelSelectedParameter.Text = this.selectedParameter;

            // populate current parameter active rules 
            comboBoxActiveConditions.Items.Clear();
            comboBoxActiveConditions.Items.AddRange(xmlhandler.GetActiveConditionsFrom(this.selectedParameter));
            comboBoxActiveConditions.SelectedIndex = 0;

            if (xmlhandler.IsParameterActive(comboBoxParameters.SelectedItem.ToString()))
            {
                checkBoxActive.CheckState = CheckState.Checked;
                groupBoxParameterRules.Enabled = true;
            }
            else
            {
                checkBoxActive.CheckState = CheckState.Unchecked;
                groupBoxParameterRules.Enabled = false;
            }
        }

        private void checkBoxActive_Click(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (mClient != null && mClient.IsConnected)
            {
                MessageBox.Show("You must disconnect the alarm to edit the rules.");

                if (!checkBox.Checked)
                {
                    checkBox.CheckState = CheckState.Checked;
                    groupBoxParameterRules.Enabled = true;
                }
                else
                {
                    checkBox.CheckState = CheckState.Unchecked;
                    groupBoxParameterRules.Enabled = false;
                }

                return;
            }

            checkBoxCheck();
            xmlhandler.SetParameterActive(selectedParameter);
        }

        private void checkBoxCheck()
        {
            if (!checkBoxActive.Checked)
            {
                groupBoxParameterRules.Enabled = false;
            }
            else
            {
                groupBoxParameterRules.Enabled = true;
            }
        }

        private void comboBoxActiveRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedCondition = comboBoxActiveConditions.SelectedItem.ToString();
            labelSelectedCondition.Text = this.selectedCondition + ":";

            if (this.selectedCondition == "between")
            {
                textBoxConditionValueMax.Visible = true;
                labelTextAND.Visible = true;
                this.values = xmlhandler.GetConditionValue(this.selectedParameter, this.selectedCondition, true);
                textBoxConditionValueMax.Text = values[1];
                textBoxConditionValue.Text = values[0];
            } else
            {
                textBoxConditionValueMax.Visible = false;
                labelTextAND.Visible = false;
                this.values = xmlhandler.GetConditionValue(this.selectedParameter, this.selectedCondition, false);
                textBoxConditionValue.Text = values[0];
            }

            textBoxConditionDescription.Text = xmlhandler.GetConditionDescription(this.selectedParameter, this.selectedCondition);

            this.oldValues = this.values;
            this.oldDescription = textBoxConditionDescription.Text;
        }
            
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateFieldsOnSave())
            {
                return;
            }

            if (this.isCreatingRule)
            {
                if (xmlhandler.CreateRule(selectedParameter, this.selectedCondition))
                {
                    MessageBox.Show("Rule successfully created");
                    RefreshRuleSection();
                    return;
                }
            }

            if (xmlhandler.SaveChanges() && !this.isCreatingRule)
            {
                MessageBox.Show("Changes successfully saved");
            }

        }

        private void RefreshRuleSection()
        {
            buttonSave.Text = "Save changes";
            comboBoxActiveConditions.Enabled = true;
            comboBoxActiveConditions.SelectedIndex = 0;

            buttonRemoveCondition.Enabled = true;
            comboBoxCreateCondition.Visible = false;
            buttonAddCondition.Enabled = true;
            this.isCreatingRule = false;
        }

        private bool ValidateFieldsOnSave()
        {
            if ((selectedCondition == "between" && textBoxConditionValueMax.Text.Trim() == "") ||
                (selectedCondition == "between" && textBoxConditionValue.Text.Trim() == ""))
            {
                MessageBox.Show("Min and Max values are required!");
                return false;
            }

            long valueMin, valueMax;
            if (long.TryParse(textBoxConditionValue.Text, out valueMin) && long.TryParse(textBoxConditionValueMax.Text, out valueMax))
            {
                if (selectedCondition == "between" && (valueMin >= valueMax))
                {
                    MessageBox.Show("Min value must be lower than max value!");
                    return false;
                }
            }

            if (selectedCondition == "lessThan" && textBoxConditionValue.Text == "0")
            {
                MessageBox.Show("Condition lessThan cannot be set to 0 value!");
                return false;
            }

            if (textBoxConditionValue.Text.Trim() == "")
            {
                MessageBox.Show("Value is required!");
                return false;
            }

            if (textBoxConditionDescription.Text.Trim() == "")
            {
                MessageBox.Show("Description is required!");
                return false;
            }

            if (mClient != null && mClient.IsConnected)
            {
                MessageBox.Show("Program is running... Please turn off the alarm to edit your conditions.");
                return false;
            }

            return true;
        }

        private void textBoxConditionDescription_Leave(object sender, EventArgs e)
        {
            string description = textBoxConditionDescription.Text;
            if (description.Trim().Length > 100 || description.Trim().Length < 5)
            {
                MessageBox.Show("Description must be between 5 and 100 characteres.");
                textBoxConditionDescription.Text = description.Substring(0, Math.Min(description.Length, 100));
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (mClient == null || !mClient.IsConnected)
            {
                RollbackFieldsValues();
            }

            if (isCreatingRule)
            {
                RefreshRuleSection();
                isCreatingRule = false;
            }
        }

        // rollback the fields values to the values before any change
        private void RollbackFieldsValues()
        {
            if (this.oldValues[1] != null)
            {
                textBoxConditionValueMax.Text = this.oldValues[1];
            }

            textBoxConditionValue.Text = this.oldValues[0];
            textBoxConditionDescription.Text = this.oldDescription;
        }

        // verify if there are any field changed
        private bool AreChangedFields()
        {
            return oldDescription.Trim() != textBoxConditionDescription.Text.Trim() ||
                oldValues[0] != values[0] || oldValues[1] != values[1];

        }

        private void buttonRemoveCondition_Click(object sender, EventArgs e)
        {
            if (comboBoxActiveConditions.Items.Count > 0)
            {
                buttonRemoveCondition.Visible = true;
                DialogResult result = MessageBox.Show("You want to remove the condition '" + this.selectedCondition + "' ?",
                                            "Warning",
                                            MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    xmlhandler.RemoveCondition(this.selectedParameter, this.selectedCondition);
                    MessageBox.Show("Condition successfully removed");
                    comboBoxActiveConditions.Items.Remove(this.selectedCondition);
                    comboBoxActiveConditions.SelectedIndex = 0;
                }
                if (result == DialogResult.No)
                {
                    RollbackFieldsValues();
                }
            } else
            {
                buttonRemoveCondition.Visible = false;
            }
        }

        private void buttonAddCondition_Click(object sender, EventArgs e)
        {
            comboBoxActiveConditions.Enabled = false;
            comboBoxCreateCondition.Visible = true;
            buttonAddCondition.Enabled = false;
            buttonRemoveCondition.Enabled = false;

            comboBoxCreateCondition.Items.Clear();
            comboBoxCreateCondition.Items.AddRange(xmlhandler.GetAvailableConditions(this.selectedParameter));

            if (comboBoxCreateCondition.Items.Count > 0)
            {
                comboBoxCreateCondition.SelectedIndex = 0;
                string selectedConditionToCreate = comboBoxCreateCondition.SelectedItem.ToString();
                this.selectedCondition = selectedConditionToCreate;
                labelSelectedCondition.Text = this.selectedCondition + ":";

                if (this.selectedCondition == "between")
                {
                    textBoxConditionValueMax.Visible = true;
                }
            }
            

            textBoxConditionValue.Text = "";
            textBoxConditionValueMax.Text = "";
            textBoxConditionDescription.Text = "";
            buttonSave.Text = "Create";
            this.isCreatingRule = true;
        }

        public string[] GetConditionValues()
        {
            string[] values = new string[2];

            values[0] = textBoxConditionValue.Text;

            if (textBoxConditionValueMax.Visible == true)
            {
                values[1] = textBoxConditionValueMax.Text;
                values[0] = textBoxConditionValue.Text;
            }

            return values;
        }

        public string GetConditionDescription()
        {
            return textBoxConditionDescription.Text;
        }

        public string GetSelectedParameter()
        {
            return this.selectedParameter;
        }

        public string GetSelectedCondition()
        {
            return this.selectedCondition;
        }
    }
}
