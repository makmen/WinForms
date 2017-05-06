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
    public partial class AddPublishingForm : Form
    {
        private catalogBooksEntities dbCatalog;
        public AddPublishingForm(catalogBooksEntities dbCatalog)
        {
            InitializeComponent();
            this.dbCatalog = dbCatalog;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ErrorControls.EmptyTextBox(tbName)) // add in db
            {
                Publishing pb = new Publishing();
                pb.name = tbName.Text;
                pb.year = (int)nudYear.Value;
                dbCatalog.Publishing.Add(pb);
                dbCatalog.SaveChanges();
                this.Close();
            }
        }
    }
}
