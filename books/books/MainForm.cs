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
    public partial class MainForm : Form
    {
        private catalogBooksEntities dbCatalog;
        public catalogBooksEntities DbCatalog
        {
            get { return dbCatalog; }
        }

        public MainForm()
        {
            InitializeComponent();
            dbCatalog = new catalogBooksEntities();
        }

        private void showBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool show = true;
            ShowForm showForm = new ShowForm();
            foreach (Form item in this.MdiChildren)
            {
                if (item is ShowForm)
                {
                    show = false;
                    item.Focus();
                }
            }
            if (show)
            {
                showForm.MdiParent = this;
                showForm.Show();
            }
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
            {
                item.WindowState = FormWindowState.Minimized;
            }
        }

        private void maximizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
            {
                item.WindowState = FormWindowState.Maximized;
            }
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }
    }
}
