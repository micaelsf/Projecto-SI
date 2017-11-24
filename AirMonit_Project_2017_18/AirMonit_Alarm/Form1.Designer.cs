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
            this.groupBoxParameterRules = new System.Windows.Forms.GroupBox();
            this.labelSelectedRule = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxActiveRules = new System.Windows.Forms.ComboBox();
            this.textBoxRuleDescription = new System.Windows.Forms.TextBox();
            this.textBoxRuleValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.labelSelectedParameter = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxParameters = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.labelInvalidIp = new System.Windows.Forms.Label();
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
            this.groupBox1.Controls.Add(this.groupBoxParameterRules);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.checkBoxActive);
            this.groupBox1.Controls.Add(this.labelSelectedParameter);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBoxParameters);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(550, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 347);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rules options";
            // 
            // groupBoxParameterRules
            // 
            this.groupBoxParameterRules.Controls.Add(this.labelSelectedRule);
            this.groupBoxParameterRules.Controls.Add(this.label9);
            this.groupBoxParameterRules.Controls.Add(this.label11);
            this.groupBoxParameterRules.Controls.Add(this.comboBoxActiveRules);
            this.groupBoxParameterRules.Controls.Add(this.textBoxRuleDescription);
            this.groupBoxParameterRules.Controls.Add(this.textBoxRuleValue);
            this.groupBoxParameterRules.Controls.Add(this.label8);
            this.groupBoxParameterRules.Controls.Add(this.label7);
            this.groupBoxParameterRules.Location = new System.Drawing.Point(10, 106);
            this.groupBoxParameterRules.Name = "groupBoxParameterRules";
            this.groupBoxParameterRules.Size = new System.Drawing.Size(188, 206);
            this.groupBoxParameterRules.TabIndex = 14;
            this.groupBoxParameterRules.TabStop = false;
            this.groupBoxParameterRules.Text = "Parameter rules";
            // 
            // labelSelectedRule
            // 
            this.labelSelectedRule.AutoSize = true;
            this.labelSelectedRule.Location = new System.Drawing.Point(114, 56);
            this.labelSelectedRule.Name = "labelSelectedRule";
            this.labelSelectedRule.Size = new System.Drawing.Size(19, 13);
            this.labelSelectedRule.TabIndex = 16;
            this.labelSelectedRule.Text = "<>";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(6, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Active rules:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(6, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Selected parameter:";
            // 
            // comboBoxActiveRules
            // 
            this.comboBoxActiveRules.FormattingEnabled = true;
            this.comboBoxActiveRules.Location = new System.Drawing.Point(77, 19);
            this.comboBoxActiveRules.Name = "comboBoxActiveRules";
            this.comboBoxActiveRules.Size = new System.Drawing.Size(105, 21);
            this.comboBoxActiveRules.TabIndex = 14;
            // 
            // textBoxRuleDescription
            // 
            this.textBoxRuleDescription.Location = new System.Drawing.Point(9, 124);
            this.textBoxRuleDescription.Name = "textBoxRuleDescription";
            this.textBoxRuleDescription.Size = new System.Drawing.Size(173, 20);
            this.textBoxRuleDescription.TabIndex = 12;
            // 
            // textBoxRuleValue
            // 
            this.textBoxRuleValue.Location = new System.Drawing.Point(49, 79);
            this.textBoxRuleValue.Name = "textBoxRuleValue";
            this.textBoxRuleValue.Size = new System.Drawing.Size(70, 20);
            this.textBoxRuleValue.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(6, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Value:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(6, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Description:";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(123, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Create rules";
            this.button1.UseVisualStyleBackColor = true;
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
            // 
            // labelSelectedParameter
            // 
            this.labelSelectedParameter.AutoSize = true;
            this.labelSelectedParameter.Location = new System.Drawing.Point(120, 56);
            this.labelSelectedParameter.Name = "labelSelectedParameter";
            this.labelSelectedParameter.Size = new System.Drawing.Size(19, 13);
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
            this.comboBoxParameters.Location = new System.Drawing.Point(123, 17);
            this.comboBoxParameters.Name = "comboBoxParameters";
            this.comboBoxParameters.Size = new System.Drawing.Size(75, 21);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 460);
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
        private System.Windows.Forms.TextBox textBoxRuleDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxRuleValue;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelSelectedParameter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxParameters;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBoxParameterRules;
        private System.Windows.Forms.Label labelSelectedRule;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxActiveRules;
    }
}

