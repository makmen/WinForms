using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System;

namespace SearchBanks
{
    static class ErrorControls
    {
        static public bool EmptyComboBox(ComboBox cmb)
        {
            bool check = true;
            if (cmb.Text == "")
            {
                check = false;
                cmb.BackColor = Color.Red;
            }
            else
            {
                cmb.BackColor = Color.White;
            }

            return check;
        }

        static public bool EmptyTextBox(TextBox tb)
        {
            bool check = true;
            if (tb.Text == "")
            {
                check = false;
                tb.BackColor = Color.Red;
            }
            else
            {
                tb.BackColor = Color.White;
            }

            return check;
        }

        static public bool TextBoxToDouble(TextBox tb)
        {
            bool check = true;
            double res = 0;
            try
            {
                res = double.Parse(tb.Text);
                tb.BackColor = Color.White;
            }
            catch(Exception)
            {
                check = false;
                tb.BackColor = Color.Red;
            }

            return check;
        }

        static public bool RegexTextBox(TextBox tb, string pattern)
        {
            bool check = true;
            if (!Regex.IsMatch(tb.Text, pattern))
            {
                check = false;
                tb.BackColor = Color.Red;
            }
            else
            {
                tb.BackColor = Color.White;
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
