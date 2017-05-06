namespace SearchBanks
{
    partial class MinMaxForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbRur = new System.Windows.Forms.RadioButton();
            this.rbEur = new System.Windows.Forms.RadioButton();
            this.rbUsd = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbRur);
            this.groupBox1.Controls.Add(this.rbEur);
            this.groupBox1.Controls.Add(this.rbUsd);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 128);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Валюта";
            // 
            // rbRur
            // 
            this.rbRur.AutoSize = true;
            this.rbRur.Location = new System.Drawing.Point(86, 88);
            this.rbRur.Name = "rbRur";
            this.rbRur.Size = new System.Drawing.Size(49, 17);
            this.rbRur.TabIndex = 2;
            this.rbRur.TabStop = true;
            this.rbRur.Text = "RUR";
            this.rbRur.UseVisualStyleBackColor = true;
            // 
            // rbEur
            // 
            this.rbEur.AutoSize = true;
            this.rbEur.Location = new System.Drawing.Point(86, 53);
            this.rbEur.Name = "rbEur";
            this.rbEur.Size = new System.Drawing.Size(48, 17);
            this.rbEur.TabIndex = 1;
            this.rbEur.TabStop = true;
            this.rbEur.Text = "EUR";
            this.rbEur.UseVisualStyleBackColor = true;
            // 
            // rbUsd
            // 
            this.rbUsd.AutoSize = true;
            this.rbUsd.Location = new System.Drawing.Point(86, 19);
            this.rbUsd.Name = "rbUsd";
            this.rbUsd.Size = new System.Drawing.Size(48, 17);
            this.rbUsd.TabIndex = 0;
            this.rbUsd.TabStop = true;
            this.rbUsd.Text = "USD";
            this.rbUsd.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(83, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MinMaxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 193);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "MinMaxForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выберите валюту";
            this.Load += new System.EventHandler(this.MinMaxForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbRur;
        private System.Windows.Forms.RadioButton rbEur;
        private System.Windows.Forms.RadioButton rbUsd;
        private System.Windows.Forms.Button button1;
    }
}