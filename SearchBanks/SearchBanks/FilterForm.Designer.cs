namespace SearchBanks
{
    partial class FilterForm
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
            this.chkBank = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbBank = new System.Windows.Forms.ComboBox();
            this.chkServices = new System.Windows.Forms.CheckBox();
            this.lbServices = new System.Windows.Forms.ListBox();
            this.dptTimeClose = new System.Windows.Forms.DateTimePicker();
            this.dptTimeOpen = new System.Windows.Forms.DateTimePicker();
            this.chkTime = new System.Windows.Forms.CheckBox();
            this.chkMainOffice = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.chkShowMainOffice = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkBank
            // 
            this.chkBank.AutoSize = true;
            this.chkBank.Location = new System.Drawing.Point(12, 40);
            this.chkBank.Name = "chkBank";
            this.chkBank.Size = new System.Drawing.Size(57, 17);
            this.chkBank.TabIndex = 0;
            this.chkBank.Text = "Банки";
            this.chkBank.UseVisualStyleBackColor = true;
            this.chkBank.CheckedChanged += new System.EventHandler(this.chkBank_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(411, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Выберите банк";
            // 
            // cbBank
            // 
            this.cbBank.FormattingEnabled = true;
            this.cbBank.Location = new System.Drawing.Point(220, 40);
            this.cbBank.Name = "cbBank";
            this.cbBank.Size = new System.Drawing.Size(185, 21);
            this.cbBank.TabIndex = 27;
            // 
            // chkServices
            // 
            this.chkServices.AutoSize = true;
            this.chkServices.Location = new System.Drawing.Point(12, 97);
            this.chkServices.Name = "chkServices";
            this.chkServices.Size = new System.Drawing.Size(62, 17);
            this.chkServices.TabIndex = 28;
            this.chkServices.Text = "Услуги";
            this.chkServices.UseVisualStyleBackColor = true;
            this.chkServices.CheckedChanged += new System.EventHandler(this.chkServices_CheckedChanged);
            // 
            // lbServices
            // 
            this.lbServices.FormattingEnabled = true;
            this.lbServices.Location = new System.Drawing.Point(220, 97);
            this.lbServices.Name = "lbServices";
            this.lbServices.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbServices.Size = new System.Drawing.Size(275, 186);
            this.lbServices.TabIndex = 29;
            // 
            // dptTimeClose
            // 
            this.dptTimeClose.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dptTimeClose.Location = new System.Drawing.Point(330, 315);
            this.dptTimeClose.Name = "dptTimeClose";
            this.dptTimeClose.Size = new System.Drawing.Size(103, 20);
            this.dptTimeClose.TabIndex = 32;
            // 
            // dptTimeOpen
            // 
            this.dptTimeOpen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dptTimeOpen.Location = new System.Drawing.Point(220, 315);
            this.dptTimeOpen.Name = "dptTimeOpen";
            this.dptTimeOpen.Size = new System.Drawing.Size(104, 20);
            this.dptTimeOpen.TabIndex = 30;
            // 
            // chkTime
            // 
            this.chkTime.AutoSize = true;
            this.chkTime.Location = new System.Drawing.Point(12, 315);
            this.chkTime.Name = "chkTime";
            this.chkTime.Size = new System.Drawing.Size(99, 17);
            this.chkTime.TabIndex = 33;
            this.chkTime.Text = "Время работы";
            this.chkTime.UseVisualStyleBackColor = true;
            this.chkTime.CheckedChanged += new System.EventHandler(this.chkTime_CheckedChanged);
            // 
            // chkMainOffice
            // 
            this.chkMainOffice.AutoSize = true;
            this.chkMainOffice.Location = new System.Drawing.Point(12, 364);
            this.chkMainOffice.Name = "chkMainOffice";
            this.chkMainOffice.Size = new System.Drawing.Size(156, 17);
            this.chkMainOffice.TabIndex = 34;
            this.chkMainOffice.Text = "Фильтр на главный офис";
            this.chkMainOffice.UseVisualStyleBackColor = true;
            this.chkMainOffice.CheckedChanged += new System.EventHandler(this.chkMainOffice_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(398, 412);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 23);
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(269, 412);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(97, 23);
            this.btnAdd.TabIndex = 36;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // chkShowMainOffice
            // 
            this.chkShowMainOffice.AutoSize = true;
            this.chkShowMainOffice.Location = new System.Drawing.Point(220, 364);
            this.chkShowMainOffice.Name = "chkShowMainOffice";
            this.chkShowMainOffice.Size = new System.Drawing.Size(196, 17);
            this.chkShowMainOffice.TabIndex = 37;
            this.chkShowMainOffice.Text = "Показать только главные офисы";
            this.chkShowMainOffice.UseVisualStyleBackColor = true;
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 447);
            this.Controls.Add(this.chkShowMainOffice);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.chkMainOffice);
            this.Controls.Add(this.chkTime);
            this.Controls.Add(this.dptTimeClose);
            this.Controls.Add(this.dptTimeOpen);
            this.Controls.Add(this.lbServices);
            this.Controls.Add(this.chkServices);
            this.Controls.Add(this.cbBank);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.chkBank);
            this.Name = "FilterForm";
            this.Text = "Фильтрация объектов";
            this.Load += new System.EventHandler(this.FilterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkBank;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbBank;
        private System.Windows.Forms.CheckBox chkServices;
        private System.Windows.Forms.ListBox lbServices;
        private System.Windows.Forms.DateTimePicker dptTimeClose;
        private System.Windows.Forms.DateTimePicker dptTimeOpen;
        private System.Windows.Forms.CheckBox chkTime;
        private System.Windows.Forms.CheckBox chkMainOffice;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckBox chkShowMainOffice;
    }
}