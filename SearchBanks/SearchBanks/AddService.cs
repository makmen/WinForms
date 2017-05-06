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
    public partial class AddService : Form
    {
        private MainForm mdiParent;
        private AddAtmForm parent;

        public AddService(AddAtmForm parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int res = CheckData();
            if (res == 0)
            {
                Service newService = new Service();
                newService.title = tbTitle.Text;
                newService.code = int.Parse(tbCode.Text);
                if (mdiParent.DBConnect.AddService(newService))
                {
                    parent.UpdateList();
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
            check = ErrorControls.EmptyTextBox(tbCode);
            if (check) 
            {
                check = ErrorControls.RegexTextBox(tbCode, "^[0-9]+$");
            }
            ErrorControls.CountErrors(ref i, check);

            return i;
        }

        private void AddService_Load(object sender, EventArgs e)
        {
            mdiParent = (MainForm)this.MdiParent;
        }
    }
}
