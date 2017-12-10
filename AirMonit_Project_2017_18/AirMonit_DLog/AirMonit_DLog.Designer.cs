namespace AirMonit_DLog
{
    partial class AirMonit_DLog
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
            m_cClient.Unsubscribe(topics);
            m_cClient.Disconnect();
            m_cClient = null;

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AirMonit_DLog));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxAlarmLog = new System.Windows.Forms.ListBox();
            this.listBoxCityLog = new System.Windows.Forms.ListBox();
            this.textBoxBrokerIP = new System.Windows.Forms.TextBox();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Name = "label2";
            // 
            // listBoxAlarmLog
            // 
            this.listBoxAlarmLog.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxAlarmLog, "listBoxAlarmLog");
            this.listBoxAlarmLog.Name = "listBoxAlarmLog";
            // 
            // listBoxCityLog
            // 
            this.listBoxCityLog.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxCityLog, "listBoxCityLog");
            this.listBoxCityLog.Name = "listBoxCityLog";
            // 
            // textBoxBrokerIP
            // 
            resources.ApplyResources(this.textBoxBrokerIP, "textBoxBrokerIP");
            this.textBoxBrokerIP.Name = "textBoxBrokerIP";
            // 
            // btnStartStop
            // 
            this.btnStartStop.BackColor = System.Drawing.Color.LimeGreen;
            resources.ApplyResources(this.btnStartStop, "btnStartStop");
            this.btnStartStop.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.UseVisualStyleBackColor = false;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Name = "label3";
            // 
            // labelStatus
            // 
            resources.ApplyResources(this.labelStatus, "labelStatus");
            this.labelStatus.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelStatus.Name = "labelStatus";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxBrokerIP);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // AirMonit_DLog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.listBoxCityLog);
            this.Controls.Add(this.listBoxAlarmLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.Name = "AirMonit_DLog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxAlarmLog;
        private System.Windows.Forms.ListBox listBoxCityLog;
        private System.Windows.Forms.TextBox textBoxBrokerIP;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

