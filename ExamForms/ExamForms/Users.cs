using System;
using System.Collections.Generic;
using System.Windows.Forms;

using ExamForms.logic;

namespace ExamForms
{
    public partial class Users : Form
    {
        private Dashboard parent;
        private Blogic logic;
        public Users(Dashboard parent_)
        {
            InitializeComponent();
            parent = parent_;
            logic = new Blogic();
            UpdateListUsers();
            if (parent.Group == 1)
            {
                button1.Show();
                button2.Show();
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewUser newUser = new NewUser(parent.ParentForm, "add", parent.Group);
            newUser.ShowDialog();
            UpdateListUsers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Account user = (Account)listBox1.SelectedItem;

            if (MessageBox.Show("Вы действительно хотите удалить запись с id = " + user.Id, "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (logic.DeleteUser(user.Id))
                {
                    UpdateListUsers();
                    MessageBox.Show("Удалено");
                }
            }
        }

        public void UpdateListUsers()
        {
            List<Account> users = logic.GetAllAccounts(parent.Group);
            if (users.Count > 0)
            {
                listBox1.DataSource = users;
                listBox1.DisplayMember = "name";
                listBox1.SelectedItem = users[0];
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            Account user = (Account)listBox1.SelectedItem;
            NewUser newUser = new NewUser(parent.ParentForm, "edit", parent.Group, user.Id);
            newUser.ShowDialog();
        }


    }
}
