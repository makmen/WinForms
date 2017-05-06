namespace ImageGDI
{
    partial class StartForm
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
            this.rad3 = new System.Windows.Forms.RadioButton();
            this.rad5 = new System.Windows.Forms.RadioButton();
            this.rad7 = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.grpOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // rad3
            // 
            this.rad3.AutoSize = true;
            this.rad3.Checked = true;
            this.rad3.Location = new System.Drawing.Point(77, 19);
            this.rad3.Name = "rad3";
            this.rad3.Size = new System.Drawing.Size(48, 17);
            this.rad3.TabIndex = 0;
            this.rad3.TabStop = true;
            this.rad3.Text = "3 x 3";
            this.rad3.UseVisualStyleBackColor = true;
            // 
            // rad5
            // 
            this.rad5.AutoSize = true;
            this.rad5.Location = new System.Drawing.Point(77, 42);
            this.rad5.Name = "rad5";
            this.rad5.Size = new System.Drawing.Size(48, 17);
            this.rad5.TabIndex = 1;
            this.rad5.TabStop = true;
            this.rad5.Text = "5 x 5";
            this.rad5.UseVisualStyleBackColor = true;
            // 
            // rad7
            // 
            this.rad7.AutoSize = true;
            this.rad7.Location = new System.Drawing.Point(77, 65);
            this.rad7.Name = "rad7";
            this.rad7.Size = new System.Drawing.Size(48, 17);
            this.rad7.TabIndex = 2;
            this.rad7.TabStop = true;
            this.rad7.Text = "7 x 7";
            this.rad7.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(77, 120);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.rad3);
            this.grpOption.Controls.Add(this.rad5);
            this.grpOption.Controls.Add(this.rad7);
            this.grpOption.Location = new System.Drawing.Point(12, 12);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(200, 99);
            this.grpOption.TabIndex = 0;
            this.grpOption.TabStop = false;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 151);
            this.Controls.Add(this.grpOption);
            this.Controls.Add(this.btnStart);
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Уровень сложности";
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rad3;
        private System.Windows.Forms.RadioButton rad5;
        private System.Windows.Forms.RadioButton rad7;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox grpOption;
    }
}