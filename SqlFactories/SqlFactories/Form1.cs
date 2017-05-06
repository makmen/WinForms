using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlFactories
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            DbClass db = new DbClass();
            if (db.Connection != null)
            {
                label1.Text = "Соединение установлено";
            }
            else
            {
                label1.Text = "Соединение не установлено";
                label1.BackColor = Color.Red;
                button1.Enabled = true;
            }

            //db.Select("SELECT * FROM employee");

        }
    }
}
