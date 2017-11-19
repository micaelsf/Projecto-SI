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
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Red;
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
            resources.ApplyResources(this.btnStartStop, "btnStartStop");
            this.btnStartStop.ForeColor = System.Drawing.Color.Green;
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Name = "label3";
            // 
            // AirMonit_DLog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.textBoxBrokerIP);
            this.Controls.Add(this.listBoxCityLog);
            this.Controls.Add(this.listBoxAlarmLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.Name = "AirMonit_DLog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.AirMonit_DLog_Load);
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
    }
}

