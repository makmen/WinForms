namespace SearchBanks
{
    partial class ShowAllAtmForm
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
            this.lbAtm = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbAtm
            // 
            this.lbAtm.FormattingEnabled = true;
            this.lbAtm.Location = new System.Drawing.Point(13, 13);
            this.lbAtm.Name = "lbAtm";
            this.lbAtm.Size = new System.Drawing.Size(532, 485);
            this.lbAtm.TabIndex = 0;
            this.lbAtm.DoubleClick += new System.EventHandler(this.lbAtm_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 505);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Чтобы отредактировать запись два раза щелкните по ней";
            // 
            // ShowAllAtmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 527);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbAtm);
            this.Name = "ShowAllAtmForm";
            this.Text = "Редактирование данных объектов";
            this.Load += new System.EventHandler(this.ShowAllAtmForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbAtm;
        private System.Windows.Forms.Label label1;
    }
}