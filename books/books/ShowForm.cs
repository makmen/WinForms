using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace books
{
    public partial class ShowForm : Form
    {
        private catalogBooksEntities dbCatalog;
        public ShowForm()
        {
            InitializeComponent();
            dbCatalog = new catalogBooksEntities();
            UpdateListBook(0);
        }

        public void UpdateListBook(int i)
        {
            List<Book> listBook = // get Book from db
                (from book in dbCatalog.Book
                 select book).ToList();
            lstBooks.DataSource = listBook;
            lstBooks.DisplayMember = "name";
            if (listBook.Count > 0)
            {
                lstBooks.SelectedItem = listBook[i]; // set first record in combobox
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddBookForm addbook = new AddBookForm(dbCatalog, this);
            bool show = true;
            foreach (Form item in this.MdiParent.MdiChildren)
            {
                if (item is AddBookForm)
                {
                    show = false;
                    item.Focus();
                }
            }
            if (show)
            {
                addbook.MdiParent = this.MdiParent;
                addbook.Show();
            }
        }

        private void btnAddGenre_Click(object sender, EventArgs e)
        {
            AddGenreForm addGenre = new AddGenreForm(dbCatalog);
            bool show = true;
            foreach (Form item in this.MdiParent.MdiChildren)
            {
                if (item is AddGenreForm)
                {
                    show = false;
                    item.Focus();
                }
            }
            if (show)
            {
                addGenre.MdiParent = this.MdiParent;
                addGenre.Show();
            }
        }

        private void btnAddPublishing_Click(object sender, EventArgs e)
        {
            AddPublishingForm addPublishing = new AddPublishingForm(dbCatalog);
            bool show = true;
            foreach (Form item in this.MdiParent.MdiChildren)
            {
                if (item is AddPublishingForm)
                {
                    show = false;
                    item.Focus();
                }
            }
            if (show)
            {
                addPublishing.MdiParent = this.MdiParent;
                addPublishing.Show();
            }
        }

        private void lstBooks_DoubleClick(object sender, EventArgs e)
        {

        }

    }
}
