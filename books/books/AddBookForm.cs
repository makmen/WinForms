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
    public partial class AddBookForm : Form
    {
        private catalogBooksEntities dbCatalog;
        private ShowForm parent;
        public AddBookForm(catalogBooksEntities dbCatalog, ShowForm parent = null)
        {
            InitializeComponent();
            this.dbCatalog = dbCatalog;
            this.parent = parent;
            List<Genre> listGenre = // get genre from db
                (from genre in dbCatalog.Genre
                 select genre).ToList();
            cmbGenre.DataSource = listGenre;
            cmbGenre.DisplayMember = "name";
            if (listGenre.Count > 0)
            {
                cmbGenre.SelectedItem = listGenre[0]; // set first record in combobox
            }
            List<Publishing> listPublishing = // get Publishing from db
                (from publishing in dbCatalog.Publishing
                 select publishing).ToList();
            cmbPublishing.DataSource = listPublishing;
            cmbPublishing.DisplayMember = "name";
            if (listPublishing.Count > 0)
            {
                cmbPublishing.SelectedItem = listPublishing[0]; // set first record in combobox
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int res = CheckUser();
            if (res == 0)
            {
                Book book = new Book();
                book.name = tbName.Text;
                book.author = tbAuthor.Text;
                book.Genre = (Genre)cmbGenre.SelectedItem;
                book.Publishing = (Publishing)cmbPublishing.SelectedItem;
                dbCatalog.Book.Add(book);
                dbCatalog.SaveChanges();
                // take count records in db Book
                int lastId =
                    (from bk in dbCatalog.Book
                     select bk.id).Count();
                parent.UpdateListBook(lastId - 1);
                this.Close();
            }
        }

        private int CheckUser() // get back quantity of errors
        {
            bool check;
            int i = 0;
            check = ErrorControls.EmptyTextBox(tbName);
            ErrorControls.CountErrors(ref i, check);

            check = ErrorControls.EmptyTextBox(tbAuthor);
            ErrorControls.CountErrors(ref i, check);

            check = ErrorControls.EmptyComboBox(cmbGenre);
            ErrorControls.CountErrors(ref i, check);

            check = ErrorControls.EmptyComboBox(cmbPublishing);
            ErrorControls.CountErrors(ref i, check);

            return i;
        }
    }
}
