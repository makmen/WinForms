using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

using ExamForms.logic;
using ExamForms.include;

namespace ExamForms
{
    public partial class NewUser : Form
    {
        private Form1 parent;
        private string mode;
        private int group;
        private Blogic logic;
        private byte[] image;

        public NewUser(Form1 parent_, string mode_ = "add", int group_ = 2, int id = 0)
        {
            InitializeComponent();
            parent = parent_;
            mode = mode_;
            group = group_;
            image = null;
            logic = new Blogic();
            if (mode == "edit")
            {
                this.Text = "Редактировать запись";
                button2.Text = "Сохранить";
                Account user = logic.GetUser(id);
                textBox1.Text = user.Name;
                textBox2.Text = user.FirstName;
                textBox3.Text = user.LastName;
                dateTimePicker1.Value = user.YearBirth;
                textBox4.Text = user.Email;
                textBox5.Text = user.Login;
                textBox6.Visible = false;
                textBox6.Text = user.Password;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int res = CheckUser();
            if (res == 0)
            {
                Account user = logic.RegisterUser(
                    textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Value,
                    textBox5.Text, textBox6.Text, textBox4.Text, image, group
                );
                if (user != null)
                {
                    this.Hide();
                    // пользователь зареген
                    if (group > 1)
                    {
                        parent.Hide();
                        Dashboard dsh = new Dashboard(parent, user.Idgroup, user.Id);
                        dsh.ShowDialog();
                    }
                }
            }
        }

        private int CheckUser() // возвращаем количество ошибок
        {
            bool check;
            int i = 0;
            check = ErrorControls.EmptyTextBox(textBox1);
            ErrorControls.CountErrors(ref i, check);

            check = ErrorControls.EmptyTextBox(textBox2);
            ErrorControls.CountErrors(ref i, check);

            check = ErrorControls.EmptyTextBox(textBox3);
            ErrorControls.CountErrors(ref i, check);

            check = ErrorControls.EmptyTextBox(textBox4);   // email
            label4.Hide();
            if (check) //если гуд проверим регуляркой на буквы латинского алфавита 
            {
                if (!Regex.IsMatch(textBox4.Text, "^[0-9a-z_\\.-]+@[0-9a-z_\\.-]+\\.[a-z]{2}?$"))
                {
                    textBox4.BackColor = Color.Red;
                    check = false;
                }
                else
                {
                    // последняя проврека на уникальность в базе
                    if (!logic.IsUniqueField("email", textBox4.Text))
                    {
                        textBox4.BackColor = Color.Red;
                        check = false;
                        label4.Show();
                    }
                }
            }
            ErrorControls.CountErrors(ref i, check);

            check = ErrorControls.EmptyTextBox(textBox5);   // login 
            label12.Hide();
            if (check) //если гуд проверим регуляркой на буквы латинского алфавита 
            {
                if (!Regex.IsMatch(textBox5.Text, "^[a-z]+$"))
                {
                    textBox5.BackColor = Color.Red;
                    check = false;
                }
                else // последняя проврека на уникальность в базе
                {
                    if (!logic.IsUniqueField("login", textBox5.Text))
                    {
                        textBox5.BackColor = Color.Red;
                        check = false;
                        label12.Show();
                    }
                }
            }
            ErrorControls.CountErrors(ref i, check);

            check = ErrorControls.EmptyTextBox(textBox6);
            ErrorControls.CountErrors(ref i, check);

            if (image != null)  // image
            {
                button3.BackColor = Color.White;
            }
            else
            {
                button3.BackColor = Color.Red;
                check = false;
            }
            ErrorControls.CountErrors(ref i, check);

            return i;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Jpeg Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                Bitmap myBmp = new Bitmap(dlg.FileName);
                Image.GetThumbnailImageAbort myCallBack = new Image.GetThumbnailImageAbort(ThumbnailCallBack);
                Image imgPreview = myBmp.GetThumbnailImage(200, 200, myCallBack, IntPtr.Zero);
                MemoryStream ms = new MemoryStream();
                imgPreview.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                ms.Flush();
                ms.Seek(0, SeekOrigin.Begin);
                BinaryReader br = new BinaryReader(ms);
                image = br.ReadBytes((int)ms.Length);
                label14.Text = Path.GetFileName(dlg.FileName);
                label14.Show();
            }
        }

        public bool ThumbnailCallBack()
        {
            return false;
        }


    }
}
