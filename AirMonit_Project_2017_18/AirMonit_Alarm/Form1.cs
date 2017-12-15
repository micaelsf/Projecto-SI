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

            // force activate event onIndexChanged
            comboBoxParameters.SelectedIndex = 0;

            textBoxConditionValueMax.Visible = false;
            labelTextAND.Visible = false;
            comboBoxCreateCondition.Visible = false;

            this.selectedParameter = comboBoxParameters.SelectedItem.ToString();

            if (comboBoxActiveConditions.Items.Count > 0)
            {
                ShowConditionFields();
                this.selectedCondition = comboBoxActiveConditions.SelectedItem.ToString();
            }
            else
            {
                HideConditionFields();
                this.selectedCondition = null;
            }

            this.isCreatingRule = false;

            CheckBoxCheck();
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
                    "[ " + doc.GetElementsByTagName("AirMonitParam")[0].Attributes["param"].Value + " ] " +
                    "City: " + doc.GetElementsByTagName("AirMonitParam")[0].SelectSingleNode("city").InnerText +
                    ", Value: " + doc.GetElementsByTagName("AirMonitParam")[0].SelectSingleNode("value").InnerText +
                    ", DateTime: " + doc.GetElementsByTagName("AirMonitParam")[0].SelectSingleNode("date").InnerText + " "
                    + "at " + doc.GetElementsByTagName("AirMonitParam")[0].SelectSingleNode("time").InnerText +
                    ", " + doc.GetElementsByTagName("description")[0].InnerText + "" +
                    Environment.NewLine);
            });
            
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
            comboBoxActiveConditions.Text = "";
            comboBoxActiveConditions.Items.Clear();
            comboBoxActiveConditions.Items.AddRange(xmlhandler.GetActiveConditionsFrom(this.selectedParameter));
            if (comboBoxActiveConditions.Items.Count > 0)
            {
                ShowConditionFields();
                comboBoxActiveConditions.SelectedIndex = 0;
            } 
            else
            {
                HideConditionFields();
            }

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

            CheckBoxCheck();
            xmlhandler.SetParameterActive(this.selectedParameter);
        }

        private void CheckBoxCheck()
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
            /*if (comboBoxActiveConditions.Items.Count == 0)
            {
                return;
            }*/

            if (!ValidateFieldsOnSave())
            {
                return;
            }

            // update old values on save
            this.oldValues = this.values;
            this.oldDescription = textBoxConditionDescription.Text;

            if (this.isCreatingRule)
            {
                if (xmlhandler.CreateRule(selectedParameter, this.selectedCondition))
                {
                    MessageBox.Show("Rule successfully created");
                    RefreshRuleSection();
                    comboBoxActiveConditions.Items.Clear();
                    comboBoxActiveConditions.Items.AddRange(xmlhandler.GetActiveConditionsFrom(this.selectedParameter));
                    comboBoxActiveConditions.SelectedIndex = 0;
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
            comboBoxParameters.Enabled = true;
            checkBoxActive.Enabled = true;
            buttonSave.Text = "Save changes";
            comboBoxActiveConditions.Show();
            this.isCreatingRule = false;

            if (comboBoxActiveConditions.Items.Count > 0)
            {
                comboBoxActiveConditions.SelectedIndex = 0;
                buttonRemoveCondition.Show();
                comboBoxCreateCondition.Visible = false;
                buttonAddCondition.Enabled = true;
                return;
            }

            comboBoxCreateCondition.Visible = false;
            buttonAddCondition.Enabled = true;
            
        }

        private void HideConditionFields()
        {
            buttonRemoveCondition.Visible = false;
            labelTextAND.Visible = false;
            textBoxConditionValue.Hide();
            textBoxConditionValueMax.Hide();
            textBoxConditionDescription.Hide();
            labelSelectedCondition.Hide();
            labelDescription.Hide();
            labelValue.Hide();
        }

        private void ShowConditionFields()
        {
            buttonRemoveCondition.Visible = true;
            if (this.selectedCondition == "between")
            {
                textBoxConditionValueMax.Show();
                labelTextAND.Visible = true;
            }
            textBoxConditionValue.Show();
            textBoxConditionDescription.Show();
            labelSelectedCondition.Show();
            labelDescription.Show();
            labelValue.Show();
        }

        private bool ValidateFieldsOnSave()
        {
            if ((selectedCondition == "between" && textBoxConditionValueMax.Text.Trim() == "") ||
                (selectedCondition == "between" && textBoxConditionValue.Text.Trim() == ""))
            {
                MessageBox.Show("Min and Max values are required!");
                return false;
            }

            long valueMin = -1, valueMax = -1;
            try
            {
                valueMin = long.Parse(textBoxConditionValue.Text);

                if (selectedCondition == "between")
                {
                    valueMax = long.Parse(textBoxConditionValueMax.Text);
                }
            }
            catch (Exception e)
            {
                if (selectedCondition == "between")
                {
                    MessageBox.Show("Invalid values! Only numbers accepted.");
                }
                else
                {
                    MessageBox.Show("Invalid value! Only numbers accepted.");
                }

                return false;
            }

            if (selectedCondition == "between")
            {
                if (valueMin >= valueMax)
                {
                    MessageBox.Show("Min value must be lower than max value!");
                }
                if (valueMin < 0 || valueMax < 0)
                {
                    MessageBox.Show("Values cannot be negative numbers!");
                }
                return false;
            }

            if (valueMin < 0)
            {
                MessageBox.Show("Value cannot be a negative number!");
                return false;
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
                MessageBox.Show("Program is running... Please disconnect the alarm to edit your conditions.");
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

                if (comboBoxActiveConditions.Items.Count > 0)
                {
                    ShowConditionFields();
                    return;
                }

                HideConditionFields();
            }
        }

        // rollback the fields values to the values before any change
        private void RollbackFieldsValues()
        {
            if (comboBoxActiveConditions.Items.Count > 0)
            {
                if (this.oldValues[1] != null)
                {
                    textBoxConditionValueMax.Text = this.oldValues[1];
                }

                textBoxConditionValue.Text = this.oldValues[0];
                textBoxConditionDescription.Text = this.oldDescription;
            }
        }

        // verify if there are any field changed
        private bool AreChangedFields()
        {
            if (comboBoxActiveConditions.Items.Count == 0)
            {
                return false;
            }

            return oldDescription.Trim() != textBoxConditionDescription.Text.Trim() ||
                oldValues[0] != values[0] || oldValues[1] != values[1];

        }

        private void buttonRemoveCondition_Click(object sender, EventArgs e)
        {
            if (mClient != null && mClient.IsConnected)
            {
                MessageBox.Show("Program is running... Please turn off the alarm to remove a condition.");
                return;
            }

            buttonRemoveCondition.Visible = true;
            DialogResult result = MessageBox.Show("You want to remove the condition '" + this.selectedCondition + "' ?",
                                        "Warning",
                                        MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                xmlhandler.RemoveCondition(this.selectedParameter, this.selectedCondition);
                MessageBox.Show("Condition successfully removed");
                comboBoxActiveConditions.Items.Remove(this.selectedCondition);

                if (comboBoxActiveConditions.Items.Count > 0)
                {
                    comboBoxActiveConditions.SelectedIndex = 0;
                    return;
                }

                comboBoxActiveConditions.Text = "";
                HideConditionFields();
            }
            if (result == DialogResult.No)
            {
                RollbackFieldsValues();
            }
        }

        private void buttonAddCondition_Click(object sender, EventArgs e)
        {
            comboBoxParameters.Enabled = false;
            checkBoxActive.Enabled = false;
            comboBoxActiveConditions.Hide();
            comboBoxCreateCondition.Visible = true;
            buttonAddCondition.Enabled = false;

            comboBoxCreateCondition.Items.Clear();

            object[] availableList = xmlhandler.GetAvailableConditions(this.selectedParameter);

            this.isCreatingRule = true;

            if (availableList.Length > 0)
            {
                ShowConditionFields();
                comboBoxCreateCondition.Items.AddRange(availableList);
                comboBoxCreateCondition.SelectedIndex = 0;
                string selectedConditionToCreate = comboBoxCreateCondition.SelectedItem.ToString();
                this.selectedCondition = selectedConditionToCreate;
                labelSelectedCondition.Text = this.selectedCondition + ":";
                buttonRemoveCondition.Visible = false;
            }

            if (comboBoxCreateCondition.Items.Count == 0)
            {
                labelSelectedCondition.Text = "";
                HideConditionFields();
                return;
            }

            textBoxConditionValue.Text = "";
            textBoxConditionValueMax.Text = "";
            textBoxConditionDescription.Text = "";
            buttonSave.Text = "Create";
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

        private void comboBoxCreateCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedCondition = comboBoxCreateCondition.SelectedItem.ToString();
            labelSelectedCondition.Text = this.selectedCondition + ":";

            if (this.selectedCondition == "between")
            {
                labelTextAND.Visible = true;
                textBoxConditionValueMax.Visible = true;
                return;
            }

            labelTextAND.Visible = false;
            textBoxConditionValueMax.Visible = false;
        }

        private void textBoxConditionValue_Enter(object sender, EventArgs e)
        {
            textBoxConditionValue.BackColor = Color.FromName("HighLight");
        }

        private void textBoxConditionValue_Leave(object sender, EventArgs e)
        {
            textBoxConditionValue.BackColor = Color.FromName("ActiveCaption");
        }

        private void textBoxConditionValueMax_Enter(object sender, EventArgs e)
        {
            textBoxConditionValueMax.BackColor = Color.FromName("HighLight");
        }

        private void textBoxConditionValueMax_Leave(object sender, EventArgs e)
        {
            textBoxConditionValueMax.BackColor = Color.FromName("ActiveCaption");
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
