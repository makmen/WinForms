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
    public partial class FilterForm : Form
    {
        private MainForm mdiParent;

        public FilterForm()
        {
            InitializeComponent();
            cbBank.Enabled = false;
            lbServices.Enabled = false;
            dptTimeOpen.CustomFormat = "HH:mm";
            dptTimeClose.CustomFormat = "HH:mm";
            dptTimeOpen.Text = "09:00";
            dptTimeClose.Text = "18:00";
            dptTimeOpen.Enabled = false;
            dptTimeClose.Enabled = false;
            chkShowMainOffice.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FilterForm_Load(object sender, EventArgs e)
        {
            mdiParent = (MainForm)this.MdiParent;
            List<Bank> banks = mdiParent.DBConnect.GetAllBanks();
            cbBank.DataSource = banks;
            cbBank.DisplayMember = "name";
            if (banks.Count > 0)
            {
                cbBank.SelectedItem = banks[0]; // set first record in combobox
            }
            UpdateList();
        }

        public void UpdateList()
        {
            List<Service> services = mdiParent.DBConnect.GetAllServices();
            lbServices.DataSource = services;
            lbServices.DisplayMember = "title";
        }

        private void chkBank_CheckedChanged(object sender, EventArgs e)
        {
            cbBank.Enabled = (chkBank.Checked) ? true : false;
        }

        private void chkServices_CheckedChanged(object sender, EventArgs e)
        {
            lbServices.Enabled = (chkServices.Checked) ? true : false;
        }

        private void chkTime_CheckedChanged(object sender, EventArgs e)
        {
            dptTimeOpen.Enabled = (chkTime.Checked) ? true : false;
            dptTimeClose.Enabled = (chkTime.Checked) ? true : false;
        }

        private void chkMainOffice_CheckedChanged(object sender, EventArgs e)
        {
            chkShowMainOffice.Enabled = (chkMainOffice.Checked) ? true : false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Atm newAtm = new Atm();
            bool filter = false;
            bool mainOffice = false;
            if (chkBank.Checked)
            {
                newAtm.Bank = (Bank)cbBank.SelectedItem;
                filter = true;
            }
            if (chkServices.Checked)
            {
                for (int i = 0; i < lbServices.SelectedItems.Count; ++i)
                {
                    newAtm.Service.Add((Service)lbServices.SelectedItems[i]);
                }
                filter = true;
            }
            if (chkTime.Checked)
            {
                TimeSpan time = new TimeSpan(dptTimeOpen.Value.Hour, dptTimeOpen.Value.Minute, dptTimeOpen.Value.Second);
                newAtm.timeopen = (int)time.TotalSeconds;
                time = new TimeSpan(dptTimeClose.Value.Hour, dptTimeClose.Value.Minute, dptTimeClose.Value.Second);
                newAtm.timeclose = (int)time.TotalSeconds;
                filter = true;
            }
            if (chkMainOffice.Checked)
            {
                mainOffice = true;
                newAtm.mainoffice = chkShowMainOffice.Checked;
                filter = true;
            }

            if (filter)
            {
                List<Atm> atm = mdiParent.DBConnect.GetAtmFilters(newAtm, mainOffice);
                if (atm.Count > 0)
                {
                    mdiParent.MapForm.UpdateMapFiler(atm);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Нет результатов удовлетворяющих условию поиска");
                }
            }
            else
            {
                this.Close();
            }

        }



    }
}
