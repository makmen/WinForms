using System.Drawing;
using System.Windows.Forms;

namespace books
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

        static public void CountErrors(ref int i, bool check)
        {
            if (!check)
            {
                ++i;
            }
        }

    }
}
