using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ExamForms.logic;
using ExamForms.include;

namespace ExamForms
{
    public partial class Form1 : Form
    {
        private Blogic logic;

        public Form1()
        {
            InitializeComponent();
            logic = new Blogic();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            NewUser newUser = new NewUser(this);
            newUser.ShowDialog();
        }

        private void label3_Hover(object sender, EventArgs e)
        {
            label3.Font = new Font(label3.Font, FontStyle.Underline);
        }
        private void label3_Leave(object sender, EventArgs e)
        {
            label3.Font = new Font("Microsoft Sans Serif", (float)9.75);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int res = CheckFields();
            label5.Hide();
            if (res == 0)
            {
                Account user = logic.CheckUser(textBox1.Text, textBox2.Text);
                // проверяем через базу вход пользователя
                if (user != null)
                {
                    this.Hide();
                    // пользователь вошел
                    Dashboard dsh = new Dashboard(this, user.Idgroup, user.Id);
                    dsh.ShowDialog();
                }
                else
                {
                    label5.Show();
                }
            }
        }

        private int CheckFields() // возвращаем количество ошибок
        {
            bool check;
            int i = 0;
            check = ErrorControls.EmptyTextBox(textBox1); // Логин
            ErrorControls.CountErrors(ref i, check);

            check = ErrorControls.EmptyTextBox(textBox2); // Пароль
            ErrorControls.CountErrors(ref i, check);

            return i;
        }



    }
}
