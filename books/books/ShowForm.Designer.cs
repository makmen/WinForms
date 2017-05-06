namespace books
{
    partial class ShowForm
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
            this.lstBooks = new System.Windows.Forms.ListBox();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnAddGenre = new System.Windows.Forms.Button();
            this.btnAddPublishing = new System.Windows.Forms.Button();
            this.btnShowClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstBooks
            // 
            this.lstBooks.FormattingEnabled = true;
            this.lstBooks.Location = new System.Drawing.Point(13, 13);
            this.lstBooks.Name = "lstBooks";
            this.lstBooks.Size = new System.Drawing.Size(526, 316);
            this.lstBooks.TabIndex = 0;
            this.lstBooks.DoubleClick += new System.EventHandler(this.lstBooks_DoubleClick);
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(13, 343);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(125, 23);
            this.btnAddBook.TabIndex = 1;
            this.btnAddBook.Text = "Добавить книгу";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddGenre
            // 
            this.btnAddGenre.Location = new System.Drawing.Point(153, 343);
            this.btnAddGenre.Name = "btnAddGenre";
            this.btnAddGenre.Size = new System.Drawing.Size(125, 23);
            this.btnAddGenre.TabIndex = 2;
            this.btnAddGenre.Text = "Добавить жанр";
            this.btnAddGenre.UseVisualStyleBackColor = true;
            this.btnAddGenre.Click += new System.EventHandler(this.btnAddGenre_Click);
            // 
            // btnAddPublishing
            // 
            this.btnAddPublishing.Location = new System.Drawing.Point(294, 343);
            this.btnAddPublishing.Name = "btnAddPublishing";
            this.btnAddPublishing.Size = new System.Drawing.Size(158, 23);
            this.btnAddPublishing.TabIndex = 3;
            this.btnAddPublishing.Text = "Добавить издательство";
            this.btnAddPublishing.UseVisualStyleBackColor = true;
            this.btnAddPublishing.Click += new System.EventHandler(this.btnAddPublishing_Click);
            // 
            // btnShowClose
            // 
            this.btnShowClose.Location = new System.Drawing.Point(464, 343);
            this.btnShowClose.Name = "btnShowClose";
            this.btnShowClose.Size = new System.Drawing.Size(75, 23);
            this.btnShowClose.TabIndex = 4;
            this.btnShowClose.Text = "Закрыть";
            this.btnShowClose.UseVisualStyleBackColor = true;
            this.btnShowClose.Click += new System.EventHandler(this.button4_Click);
            // 
            // ShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 378);
            this.Controls.Add(this.btnShowClose);
            this.Controls.Add(this.btnAddPublishing);
            this.Controls.Add(this.btnAddGenre);
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.lstBooks);
            this.Name = "ShowForm";
            this.Text = "Книги";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstBooks;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnAddGenre;
        private System.Windows.Forms.Button btnAddPublishing;
        private System.Windows.Forms.Button btnShowClose;
    }
}