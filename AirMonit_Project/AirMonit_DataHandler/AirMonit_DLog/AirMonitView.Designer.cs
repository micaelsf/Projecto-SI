namespace AirMonit_DLog
{
    partial class AirMonitView
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
            this.listViewCityLog = new System.Windows.Forms.ListView();
            this.listViewAlarmLog = new System.Windows.Forms.ListView();
            this.btnSetCityLog = new System.Windows.Forms.Button();
            this.btnSetAlarmLog = new System.Windows.Forms.Button();
            this.btnStopAlarmLog = new System.Windows.Forms.Button();
            this.btnStopCityLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewCityLog
            // 
            this.listViewCityLog.Location = new System.Drawing.Point(268, 38);
            this.listViewCityLog.Name = "listViewCityLog";
            this.listViewCityLog.Size = new System.Drawing.Size(217, 227);
            this.listViewCityLog.TabIndex = 6;
            this.listViewCityLog.UseCompatibleStateImageBehavior = false;
            // 
            // listViewAlarmLog
            // 
            this.listViewAlarmLog.Location = new System.Drawing.Point(12, 38);
            this.listViewAlarmLog.Name = "listViewAlarmLog";
            this.listViewAlarmLog.Size = new System.Drawing.Size(216, 227);
            this.listViewAlarmLog.TabIndex = 5;
            this.listViewAlarmLog.UseCompatibleStateImageBehavior = false;
            // 
            // btnSetCityLog
            // 
            this.btnSetCityLog.Location = new System.Drawing.Point(268, 9);
            this.btnSetCityLog.Name = "btnSetCityLog";
            this.btnSetCityLog.Size = new System.Drawing.Size(107, 23);
            this.btnSetCityLog.TabIndex = 3;
            this.btnSetCityLog.Text = "Start City Log";
            this.btnSetCityLog.UseVisualStyleBackColor = true;
            this.btnSetCityLog.Click += new System.EventHandler(this.btnSetCityLog_Click);
            // 
            // btnSetAlarmLog
            // 
            this.btnSetAlarmLog.Location = new System.Drawing.Point(12, 9);
            this.btnSetAlarmLog.Name = "btnSetAlarmLog";
            this.btnSetAlarmLog.Size = new System.Drawing.Size(107, 23);
            this.btnSetAlarmLog.TabIndex = 4;
            this.btnSetAlarmLog.Text = "Start Alarm Log";
            this.btnSetAlarmLog.UseVisualStyleBackColor = true;
            this.btnSetAlarmLog.Click += new System.EventHandler(this.btnSetAlarmLog_Click);
            // 
            // btnStopAlarmLog
            // 
            this.btnStopAlarmLog.Location = new System.Drawing.Point(125, 9);
            this.btnStopAlarmLog.Name = "btnStopAlarmLog";
            this.btnStopAlarmLog.Size = new System.Drawing.Size(103, 23);
            this.btnStopAlarmLog.TabIndex = 4;
            this.btnStopAlarmLog.Text = "Stop Alarm Log";
            this.btnStopAlarmLog.UseVisualStyleBackColor = true;
            this.btnStopAlarmLog.Click += new System.EventHandler(this.btnStopAlarmLog_Click);
            // 
            // btnStopCityLog
            // 
            this.btnStopCityLog.Location = new System.Drawing.Point(381, 9);
            this.btnStopCityLog.Name = "btnStopCityLog";
            this.btnStopCityLog.Size = new System.Drawing.Size(104, 23);
            this.btnStopCityLog.TabIndex = 3;
            this.btnStopCityLog.Text = "Stop City Log";
            this.btnStopCityLog.UseVisualStyleBackColor = true;
            this.btnStopCityLog.Click += new System.EventHandler(this.btnStopCityLog_Click);
            // 
            // AirMonitView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 277);
            this.Controls.Add(this.listViewCityLog);
            this.Controls.Add(this.listViewAlarmLog);
            this.Controls.Add(this.btnStopCityLog);
            this.Controls.Add(this.btnSetCityLog);
            this.Controls.Add(this.btnStopAlarmLog);
            this.Controls.Add(this.btnSetAlarmLog);
            this.Name = "AirMonitView";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewCityLog;
        private System.Windows.Forms.ListView listViewAlarmLog;
        private System.Windows.Forms.Button btnSetCityLog;
        private System.Windows.Forms.Button btnSetAlarmLog;
        private System.Windows.Forms.Button btnStopAlarmLog;
        private System.Windows.Forms.Button btnStopCityLog;
    }
}

