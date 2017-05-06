using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchBanks
{
    public partial class MinMaxForm : Form
    {
        private MainForm mdiParent;

        public MinMaxForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbUsd.Checked)
            {
                mdiParent.SearchMinMaxRates = "usd";
            }
            else if (rbEur.Checked)
            {
                mdiParent.SearchMinMaxRates = "eur";
            }
            else
            {
                mdiParent.SearchMinMaxRates = "rur";
            }
            this.Close();
            mdiParent.MapForm.UpdateMinMaxRates();
        }

        private void MinMaxForm_Load(object sender, EventArgs e)
        {
            mdiParent = (MainForm)this.MdiParent;
        }
    }
}
