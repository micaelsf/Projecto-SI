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
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(573, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "City Log";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(176, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Alarm Log";
            // 
            // listBoxAlarmLog
            // 
            this.listBoxAlarmLog.FormattingEnabled = true;
            this.listBoxAlarmLog.Location = new System.Drawing.Point(12, 163);
            this.listBoxAlarmLog.Name = "listBoxAlarmLog";
            this.listBoxAlarmLog.Size = new System.Drawing.Size(459, 459);
            this.listBoxAlarmLog.TabIndex = 2;
            // 
            // listBoxCityLog
            // 
            this.listBoxCityLog.FormattingEnabled = true;
            this.listBoxCityLog.Location = new System.Drawing.Point(477, 163);
            this.listBoxCityLog.Name = "listBoxCityLog";
            this.listBoxCityLog.Size = new System.Drawing.Size(301, 459);
            this.listBoxCityLog.TabIndex = 2;
            // 
            // textBoxBrokerIP
            // 
            this.textBoxBrokerIP.Location = new System.Drawing.Point(244, 37);
            this.textBoxBrokerIP.Name = "textBoxBrokerIP";
            this.textBoxBrokerIP.Size = new System.Drawing.Size(182, 20);
            this.textBoxBrokerIP.TabIndex = 3;
            // 
            // btnStartStop
            // 
            this.btnStartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartStop.ForeColor = System.Drawing.Color.Green;
            this.btnStartStop.Location = new System.Drawing.Point(446, 27);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(109, 36);
            this.btnStartStop.TabIndex = 4;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(240, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Broker IP:";
            // 
            // AirMonit_DLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 634);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.textBoxBrokerIP);
            this.Controls.Add(this.listBoxCityLog);
            this.Controls.Add(this.listBoxAlarmLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AirMonit_DLog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Air Monitor Log";
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

