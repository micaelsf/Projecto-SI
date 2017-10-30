namespace WindowsFormsApp1
{
    partial class AirMonitAlarmForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.errorFrequencyLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 96);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(430, 173);
            this.listBox1.TabIndex = 0;
            // 
            // initSensorsButton
            // 
            this.initSensorsButton.Location = new System.Drawing.Point(12, 56);
            this.initSensorsButton.Name = "initSensorsButton";
            this.initSensorsButton.Size = new System.Drawing.Size(117, 21);
            this.initSensorsButton.TabIndex = 1;
            this.initSensorsButton.Text = "Initialize Sensors";
            this.initSensorsButton.UseVisualStyleBackColor = true;
            this.initSensorsButton.Click += new System.EventHandler(this.InitSensorsButton_Click);
            // 
            // stopSensorsButton
            // 
            this.stopSensorsButton.Location = new System.Drawing.Point(135, 56);
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
            this.timeTextbox.TextChanged += new System.EventHandler(this.timeTextbox_TextChanged);
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
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = " [0.1 to 60] seconds";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sensors value history:";
            // 
            // errorFrequencyLabel
            // 
            this.errorFrequencyLabel.AutoSize = true;
            this.errorFrequencyLabel.ForeColor = System.Drawing.Color.Red;
            this.errorFrequencyLabel.Location = new System.Drawing.Point(12, 35);
            this.errorFrequencyLabel.Name = "errorFrequencyLabel";
            this.errorFrequencyLabel.Size = new System.Drawing.Size(0, 13);
            this.errorFrequencyLabel.TabIndex = 7;
            // 
            // AirMonitAlarmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 426);
            this.Controls.Add(this.errorFrequencyLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeTextbox);
            this.Controls.Add(this.stopSensorsButton);
            this.Controls.Add(this.initSensorsButton);
            this.Controls.Add(this.listBox1);
            this.Name = "AirMonitAlarmForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AirMonitAlarmForm_FormClosing);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label errorFrequencyLabel;
    }
}

