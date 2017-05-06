using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DbBank;

namespace SearchBanks
{
    public partial class ShowAllAtmForm : Form
    {
        private MainForm mdiParent;
        public ShowAllAtmForm()
        {
            InitializeComponent();
        }

        private void ShowAllAtmForm_Load(object sender, EventArgs e)
        {
            mdiParent = (MainForm)this.MdiParent;
            List<Atm> atm = mdiParent.DBConnect.GetAllAtm();
            lbAtm.DataSource = atm;
            lbAtm.DisplayMember = "title";
            if (atm.Count > 0)
            {
                lbAtm.SelectedItem = atm[0];
            }
        }

        private void lbAtm_DoubleClick(object sender, EventArgs e)
        {
            Atm editAtm = (Atm)lbAtm.SelectedItem;
            bool show = true;
            AddAtmForm editAtmForm = new AddAtmForm("edit", editAtm);
            foreach (Form item in this.MdiChildren)
            {
                if (item is AddAtmForm)
                {
                    show = false;
                    item.Focus();
                }
            }
            if (show)
            {
                editAtmForm.MdiParent = mdiParent;
                editAtmForm.Show();
            }
        }

    }
}
