using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageGDI
{
    public partial class ShowResultsForm : Form
    {
        private MainForm parent;

        public ShowResultsForm(MainForm parent, int countItems)
        {
            InitializeComponent();
            this.parent = parent;
            
            //parent.DB.GetRestults(countItems);

            /*List<Book> listBook = // get Book from db
            (from book in dbCatalog.Book
             select book).ToList();*/
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
