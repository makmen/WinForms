using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace ExamForms.include
{
    static class ErrorControls
    {
        static public bool EmptyTextBox(TextBox textBox)
        {
            bool check = true;
            if (textBox.Text == "")
            {
                check = false;
                textBox.BackColor = Color.Red;
            }
            else
            {
                textBox.BackColor = Color.White;
            }

            return check;
        }

        static public void CountErrors(ref int i, bool check)
        {
            if (!check)
            {
                ++i;
            }
        }

    }
}
