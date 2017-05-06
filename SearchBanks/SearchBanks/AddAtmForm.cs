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
    public partial class AddAtmForm : Form
    {
        private MainForm mdiParent;
        private string mode;
        private Atm editAtm;

        private void AddAtmForm_Load(object sender, EventArgs e)
        {
            mdiParent = (MainForm)this.MdiParent;
            List<Bank> banks = mdiParent.DBConnect.GetAllBanks();
            cbBank.DataSource = banks;
            cbBank.DisplayMember = "name";
            if (banks.Count > 0)
            {
                cbBank.SelectedItem = banks[0]; // set first record in combobox
            }
            if (mode == "edit") // загрузка формы данными
            {
                tbTitle.Text = editAtm.title;
                tbPhone.Text = editAtm.phone;
                tbAddress.Text = editAtm.addressatm;
                tbGpsX.Text = editAtm.gpsX.ToString();
                tbGpsY.Text = editAtm.gpsY.ToString();
                tbDescription.Text = editAtm.description;
                tbCashier.Text = editAtm.cashier;
                if (editAtm.mainoffice)
                {
                    chkMainOffice.Checked = true;
                }
                dptTimeOpen.Text = (new TimeSpan(0, 0, editAtm.timeopen)).ToString();
                dptTimeClose.Text = (new TimeSpan(0, 0, editAtm.timeclose)).ToString();
                cbBank.SelectedItem = editAtm.Bank;

                List<Service> services = mdiParent.DBConnect.GetAllServices();
                lbServices.DataSource = services;
                lbServices.DisplayMember = "title";
                foreach (Service item in editAtm.Service)
                {
                    lbServices.SetSelected((item.id - 1), true);
                }
            }
            else
            {
                UpdateList();
            }
        }

        public AddAtmForm(string mode = "add", Atm editAtm = null)
        {
            InitializeComponent();
            this.mode = mode;
            this.editAtm = editAtm;
            dptTimeOpen.CustomFormat = "HH:mm";
            dptTimeClose.CustomFormat = "HH:mm";
            if (mode == "add")
            {
                dptTimeOpen.Text = "09:00";
                dptTimeClose.Text = "18:00";
            }
            else
            {
                this.Text = "Редактировать объект";
            }
        }

        public void UpdateList()
        {
            List<Service> services = mdiParent.DBConnect.GetAllServices();
            lbServices.DataSource = services;
            lbServices.DisplayMember = "title";
            if (services.Count > 0)
            {
                lbServices.SelectedItem = services[0];
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            int res = CheckData();
            if (res == 0)
            {
                Atm newAtm = new Atm();
                newAtm.title = tbTitle.Text;
                newAtm.phone = tbPhone.Text;
                newAtm.addressatm = tbAddress.Text;
                newAtm.gpsX = double.Parse(tbGpsX.Text);
                newAtm.gpsY = double.Parse(tbGpsY.Text);
                newAtm.dateregister = DateTime.Now;
                newAtm.mainoffice = chkMainOffice.Checked;
                TimeSpan time = new TimeSpan(dptTimeOpen.Value.Hour, dptTimeOpen.Value.Minute, dptTimeOpen.Value.Second);
                newAtm.timeopen = (int)time.TotalSeconds;
                time = new TimeSpan(dptTimeClose.Value.Hour, dptTimeClose.Value.Minute, dptTimeClose.Value.Second);
                newAtm.timeclose = (int)time.TotalSeconds;
                newAtm.cashier = tbCashier.Text;
                newAtm.description = tbDescription.Text;
                newAtm.idbank = ((Bank)cbBank.SelectedItem).id;
                for (int i = 0; i < lbServices.SelectedItems.Count; ++i)
                {
                    newAtm.Service.Add((Service)lbServices.SelectedItems[i]);
                }
                bool result;
                if (mode == "add")
                {
                    result = mdiParent.DBConnect.AddAtm(newAtm);
                }
                else
                {
                    newAtm.id = editAtm.id;
                    result = mdiParent.DBConnect.EditAtm(newAtm);
                }
                if (result)
                {
                    this.Close();
                }
            }
        }

        private int CheckData() // get back quantity of errors
        {
            bool check;
            int i = 0;
            check = ErrorControls.EmptyTextBox(tbTitle);
            ErrorControls.CountErrors(ref i, check);

            check = ErrorControls.EmptyTextBox(tbPhone);
            ErrorControls.CountErrors(ref i, check);

            check = ErrorControls.EmptyTextBox(tbAddress);
            ErrorControls.CountErrors(ref i, check);

            check = ErrorControls.EmptyTextBox(tbGpsX);
            if (check)
            {
                check = ErrorControls.TextBoxToDouble(tbGpsX);
            }
            ErrorControls.CountErrors(ref i, check);

            check = ErrorControls.EmptyTextBox(tbGpsY);
            if (check)
            {
                check = ErrorControls.TextBoxToDouble(tbGpsY);
            }
            ErrorControls.CountErrors(ref i, check);


            check = ErrorControls.EmptyTextBox(tbCashier);
            ErrorControls.CountErrors(ref i, check);

            check = ErrorControls.EmptyTextBox(tbDescription);
            ErrorControls.CountErrors(ref i, check);

            if (lbServices.SelectedItems.Count == 0)
            {
                check = false;
                lbServices.BackColor = Color.Red;
            }
            else
            {
                check = true;
                lbServices.BackColor = Color.White;
            }
            ErrorControls.CountErrors(ref i, check);
            
            return i;
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            AddService addService = new AddService(this);
            addService.MdiParent = mdiParent;
            addService.Show();
        }

    }
}
