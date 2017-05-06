using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace ExamForms
{
    public partial class Dashboard : Form
    {
        private int group;
        private Form1 parent;
        private int id;

        public new Form1 ParentForm
        {
            get { return parent; }
        }

        public int Group
        {
            get { return group; }
        }

        public Dashboard(Form1 parent_, int group_, int id_)
        {
            InitializeComponent();
            parent = parent_;
            group = group_;
            id = id_;
            label1.Text = "Вы вошли как " + ((group == 1) ? "Администратор" : "Пользователь");

            //MemoryStream mStream = new MemoryStream(photo);
            //pictureBox1.Image = Image.FromStream(mStream);
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
            parent.TextBox1.Text = "";
            parent.TextBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Users allUsers = new Users(this);
            allUsers.Show();
        }


    }
}
