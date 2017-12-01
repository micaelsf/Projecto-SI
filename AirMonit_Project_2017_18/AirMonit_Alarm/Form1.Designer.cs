namespace AirMonit_Alarm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxIpAddress = new System.Windows.Forms.TextBox();
            this.listBoxData = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxAlarms = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBoxParameterRules = new System.Windows.Forms.GroupBox();
            this.comboBoxCreateCondition = new System.Windows.Forms.ComboBox();
            this.buttonRemoveCondition = new System.Windows.Forms.Button();
            this.buttonAddCondition = new System.Windows.Forms.Button();
            this.labelTextAND = new System.Windows.Forms.Label();
            this.textBoxConditionValueMax = new System.Windows.Forms.TextBox();
            this.labelSelectedCondition = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxActiveConditions = new System.Windows.Forms.ComboBox();
            this.textBoxConditionDescription = new System.Windows.Forms.TextBox();
            this.textBoxConditionValue = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.labelSelectedParameter = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxParameters = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.labelInvalidIp = new System.Windows.Forms.Label();
            this.labelValue = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBoxParameterRules.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(301, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Status:";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelStatus.Location = new System.Drawing.Point(374, 60);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(29, 20);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "<>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Communication Channel IP Address:";
            // 
            // textBoxIpAddress
            // 
            this.textBoxIpAddress.Location = new System.Drawing.Point(190, 18);
            this.textBoxIpAddress.Name = "textBoxIpAddress";
            this.textBoxIpAddress.Size = new System.Drawing.Size(100, 20);
            this.textBoxIpAddress.TabIndex = 4;
            // 
            // listBoxData
            // 
            this.listBoxData.FormattingEnabled = true;
            this.listBoxData.Location = new System.Drawing.Point(16, 100);
            this.listBoxData.Name = "listBoxData";
            this.listBoxData.Size = new System.Drawing.Size(512, 160);
            this.listBoxData.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Data received:";
            // 
            // listBoxAlarms
            // 
            this.listBoxAlarms.FormattingEnabled = true;
            this.listBoxAlarms.Location = new System.Drawing.Point(16, 288);
            this.listBoxAlarms.Name = "listBoxAlarms";
            this.listBoxAlarms.Size = new System.Drawing.Size(512, 160);
            this.listBoxAlarms.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Triggered alarms:";
            // 
            // buttonConnect
            // 
            this.buttonConnect.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnect.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonConnect.Location = new System.Drawing.Point(535, 16);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(87, 22);
            this.buttonConnect.TabIndex = 7;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonConnect.UseVisualStyleBackColor = false;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonCancel);
            this.groupBox1.Controls.Add(this.buttonSave);
            this.groupBox1.Controls.Add(this.groupBoxParameterRules);
            this.groupBox1.Controls.Add(this.checkBoxActive);
            this.groupBox1.Controls.Add(this.labelSelectedParameter);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBoxParameters);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(550, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 347);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rules options";
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.LightGray;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonCancel.Location = new System.Drawing.Point(10, 318);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSave.Location = new System.Drawing.Point(127, 318);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(98, 23);
            this.buttonSave.TabIndex = 17;
            this.buttonSave.Text = "Save changes";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBoxParameterRules
            // 
            this.groupBoxParameterRules.Controls.Add(this.labelValue);
            this.groupBoxParameterRules.Controls.Add(this.comboBoxCreateCondition);
            this.groupBoxParameterRules.Controls.Add(this.buttonRemoveCondition);
            this.groupBoxParameterRules.Controls.Add(this.buttonAddCondition);
            this.groupBoxParameterRules.Controls.Add(this.labelTextAND);
            this.groupBoxParameterRules.Controls.Add(this.textBoxConditionValueMax);
            this.groupBoxParameterRules.Controls.Add(this.labelSelectedCondition);
            this.groupBoxParameterRules.Controls.Add(this.label9);
            this.groupBoxParameterRules.Controls.Add(this.comboBoxActiveConditions);
            this.groupBoxParameterRules.Controls.Add(this.textBoxConditionDescription);
            this.groupBoxParameterRules.Controls.Add(this.textBoxConditionValue);
            this.groupBoxParameterRules.Controls.Add(this.labelDescription);
            this.groupBoxParameterRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxParameterRules.Location = new System.Drawing.Point(10, 106);
            this.groupBoxParameterRules.Name = "groupBoxParameterRules";
            this.groupBoxParameterRules.Size = new System.Drawing.Size(215, 171);
            this.groupBoxParameterRules.TabIndex = 14;
            this.groupBoxParameterRules.TabStop = false;
            this.groupBoxParameterRules.Text = "Parameter rules";
            // 
            // comboBoxCreateCondition
            // 
            this.comboBoxCreateCondition.FormattingEnabled = true;
            this.comboBoxCreateCondition.Location = new System.Drawing.Point(116, 46);
            this.comboBoxCreateCondition.Name = "comboBoxCreateCondition";
            this.comboBoxCreateCondition.Size = new System.Drawing.Size(93, 21);
            this.comboBoxCreateCondition.TabIndex = 22;
            this.comboBoxCreateCondition.SelectedIndexChanged += new System.EventHandler(this.comboBoxCreateCondition_SelectedIndexChanged);
            // 
            // buttonRemoveCondition
            // 
            this.buttonRemoveCondition.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonRemoveCondition.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.buttonRemoveCondition.FlatAppearance.BorderSize = 0;
            this.buttonRemoveCondition.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRemoveCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveCondition.ForeColor = System.Drawing.Color.Red;
            this.buttonRemoveCondition.Location = new System.Drawing.Point(185, 17);
            this.buttonRemoveCondition.Name = "buttonRemoveCondition";
            this.buttonRemoveCondition.Size = new System.Drawing.Size(24, 24);
            this.buttonRemoveCondition.TabIndex = 21;
            this.buttonRemoveCondition.Text = "X";
            this.buttonRemoveCondition.UseVisualStyleBackColor = false;
            this.buttonRemoveCondition.Click += new System.EventHandler(this.buttonRemoveCondition_Click);
            // 
            // buttonAddCondition
            // 
            this.buttonAddCondition.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonAddCondition.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonAddCondition.FlatAppearance.BorderSize = 2;
            this.buttonAddCondition.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonAddCondition.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonAddCondition.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAddCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddCondition.ForeColor = System.Drawing.Color.White;
            this.buttonAddCondition.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonAddCondition.Location = new System.Drawing.Point(9, 46);
            this.buttonAddCondition.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAddCondition.Name = "buttonAddCondition";
            this.buttonAddCondition.Size = new System.Drawing.Size(94, 22);
            this.buttonAddCondition.TabIndex = 19;
            this.buttonAddCondition.Text = "Add Condition";
            this.buttonAddCondition.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonAddCondition.UseVisualStyleBackColor = false;
            this.buttonAddCondition.Click += new System.EventHandler(this.buttonAddCondition_Click);
            // 
            // labelTextAND
            // 
            this.labelTextAND.AutoSize = true;
            this.labelTextAND.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTextAND.Location = new System.Drawing.Point(129, 101);
            this.labelTextAND.Name = "labelTextAND";
            this.labelTextAND.Size = new System.Drawing.Size(25, 13);
            this.labelTextAND.TabIndex = 18;
            this.labelTextAND.Text = "and";
            // 
            // textBoxConditionValueMax
            // 
            this.textBoxConditionValueMax.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBoxConditionValueMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxConditionValueMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxConditionValueMax.Location = new System.Drawing.Point(153, 101);
            this.textBoxConditionValueMax.Name = "textBoxConditionValueMax";
            this.textBoxConditionValueMax.Size = new System.Drawing.Size(34, 13);
            this.textBoxConditionValueMax.TabIndex = 17;
            this.textBoxConditionValueMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxConditionValueMax.Enter += new System.EventHandler(this.textBoxConditionValueMax_Enter);
            this.textBoxConditionValueMax.Leave += new System.EventHandler(this.textBoxConditionValueMax_Leave);
            // 
            // labelSelectedCondition
            // 
            this.labelSelectedCondition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelSelectedCondition.Location = new System.Drawing.Point(19, 101);
            this.labelSelectedCondition.Name = "labelSelectedCondition";
            this.labelSelectedCondition.Size = new System.Drawing.Size(72, 13);
            this.labelSelectedCondition.TabIndex = 16;
            this.labelSelectedCondition.Text = "<>";
            this.labelSelectedCondition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(6, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Active conditions:";
            // 
            // comboBoxActiveConditions
            // 
            this.comboBoxActiveConditions.FormattingEnabled = true;
            this.comboBoxActiveConditions.Location = new System.Drawing.Point(101, 19);
            this.comboBoxActiveConditions.Name = "comboBoxActiveConditions";
            this.comboBoxActiveConditions.Size = new System.Drawing.Size(79, 21);
            this.comboBoxActiveConditions.TabIndex = 14;
            this.comboBoxActiveConditions.SelectedIndexChanged += new System.EventHandler(this.comboBoxActiveRules_SelectedIndexChanged);
            // 
            // textBoxConditionDescription
            // 
            this.textBoxConditionDescription.Location = new System.Drawing.Point(9, 140);
            this.textBoxConditionDescription.Name = "textBoxConditionDescription";
            this.textBoxConditionDescription.Size = new System.Drawing.Size(200, 20);
            this.textBoxConditionDescription.TabIndex = 12;
            this.textBoxConditionDescription.Leave += new System.EventHandler(this.textBoxConditionDescription_Leave);
            // 
            // textBoxConditionValue
            // 
            this.textBoxConditionValue.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBoxConditionValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxConditionValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxConditionValue.Location = new System.Drawing.Point(93, 101);
            this.textBoxConditionValue.Name = "textBoxConditionValue";
            this.textBoxConditionValue.Size = new System.Drawing.Size(34, 13);
            this.textBoxConditionValue.TabIndex = 9;
            this.textBoxConditionValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxConditionValue.Enter += new System.EventHandler(this.textBoxConditionValue_Enter);
            this.textBoxConditionValue.Leave += new System.EventHandler(this.textBoxConditionValue_Leave);
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelDescription.Location = new System.Drawing.Point(6, 124);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(63, 13);
            this.labelDescription.TabIndex = 11;
            this.labelDescription.Text = "Description:";
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxActive.Location = new System.Drawing.Point(10, 82);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(56, 17);
            this.checkBoxActive.TabIndex = 8;
            this.checkBoxActive.Text = "Active";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            this.checkBoxActive.Click += new System.EventHandler(this.checkBoxActive_Click);
            // 
            // labelSelectedParameter
            // 
            this.labelSelectedParameter.AutoSize = true;
            this.labelSelectedParameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedParameter.Location = new System.Drawing.Point(120, 56);
            this.labelSelectedParameter.Name = "labelSelectedParameter";
            this.labelSelectedParameter.Size = new System.Drawing.Size(21, 13);
            this.labelSelectedParameter.TabIndex = 3;
            this.labelSelectedParameter.Text = "<>";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(6, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Selected parameter:";
            // 
            // comboBoxParameters
            // 
            this.comboBoxParameters.FormattingEnabled = true;
            this.comboBoxParameters.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxParameters.Location = new System.Drawing.Point(123, 17);
            this.comboBoxParameters.Name = "comboBoxParameters";
            this.comboBoxParameters.Size = new System.Drawing.Size(67, 21);
            this.comboBoxParameters.TabIndex = 1;
            this.comboBoxParameters.SelectedIndexChanged += new System.EventHandler(this.comboBoxParameters_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(7, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Watching parameters:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonDisconnect);
            this.groupBox2.Controls.Add(this.labelInvalidIp);
            this.groupBox2.Controls.Add(this.textBoxIpAddress);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.buttonConnect);
            this.groupBox2.Location = new System.Drawing.Point(16, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(739, 46);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Channel configuration";
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.BackColor = System.Drawing.Color.Firebrick;
            this.buttonDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDisconnect.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonDisconnect.Location = new System.Drawing.Point(637, 15);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(87, 23);
            this.buttonDisconnect.TabIndex = 9;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = false;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // labelInvalidIp
            // 
            this.labelInvalidIp.AutoSize = true;
            this.labelInvalidIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvalidIp.ForeColor = System.Drawing.Color.Red;
            this.labelInvalidIp.Location = new System.Drawing.Point(296, 21);
            this.labelInvalidIp.Name = "labelInvalidIp";
            this.labelInvalidIp.Size = new System.Drawing.Size(91, 13);
            this.labelInvalidIp.TabIndex = 8;
            this.labelInvalidIp.Text = "Invalid Ip Address";
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelValue.Location = new System.Drawing.Point(92, 82);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(37, 13);
            this.labelValue.TabIndex = 23;
            this.labelValue.Text = "Value:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 460);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBoxAlarms);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "AirMonit_Alarm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxParameterRules.ResumeLayout(false);
            this.groupBoxParameterRules.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxIpAddress;
        private System.Windows.Forms.ListBox listBoxData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxAlarms;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelInvalidIp;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.TextBox textBoxConditionDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxConditionValue;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.Label labelSelectedParameter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxParameters;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxParameterRules;
        private System.Windows.Forms.Label labelSelectedCondition;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxActiveConditions;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxConditionValueMax;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelTextAND;
        private System.Windows.Forms.Button buttonAddCondition;
        private System.Windows.Forms.Button buttonRemoveCondition;
        private System.Windows.Forms.ComboBox comboBoxCreateCondition;
        private System.Windows.Forms.Label labelValue;
    }
}

