namespace WindowsFormsApp1
{
    partial class AirMonitAlarm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.initSensorsButton = new System.Windows.Forms.Button();
            this.stopSensorsButton = new System.Windows.Forms.Button();
            this.timeTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 65);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(487, 186);
            this.listBox1.TabIndex = 0;
            // 
            // initSensorsButton
            // 
            this.initSensorsButton.Location = new System.Drawing.Point(12, 38);
            this.initSensorsButton.Name = "initSensorsButton";
            this.initSensorsButton.Size = new System.Drawing.Size(117, 21);
            this.initSensorsButton.TabIndex = 1;
            this.initSensorsButton.Text = "Initialize Sensors";
            this.initSensorsButton.UseVisualStyleBackColor = true;
            this.initSensorsButton.Click += new System.EventHandler(this.InitSensorsButton_Click);
            // 
            // stopSensorsButton
            // 
            this.stopSensorsButton.Location = new System.Drawing.Point(135, 38);
            this.stopSensorsButton.Name = "stopSensorsButton";
            this.stopSensorsButton.Size = new System.Drawing.Size(117, 21);
            this.stopSensorsButton.TabIndex = 2;
            this.stopSensorsButton.Text = "Stop Sensors";
            this.stopSensorsButton.UseVisualStyleBackColor = true;
            this.stopSensorsButton.Click += new System.EventHandler(this.StopSensorsButton_Click);
            // 
            // timeTextbox
            // 
            this.timeTextbox.Location = new System.Drawing.Point(78, 12);
            this.timeTextbox.Name = "timeTextbox";
            this.timeTextbox.Size = new System.Drawing.Size(51, 20);
            this.timeTextbox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Frequency:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "(seconds)";
            // 
            // AirMonitAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 262);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeTextbox);
            this.Controls.Add(this.stopSensorsButton);
            this.Controls.Add(this.initSensorsButton);
            this.Controls.Add(this.listBox1);
            this.Name = "AirMonitAlarm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button initSensorsButton;
        private System.Windows.Forms.Button stopSensorsButton;
        private System.Windows.Forms.TextBox timeTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

