using System;
using System.Windows.Forms;

namespace ImageGDI
{
    public partial class StartForm : Form
    {
        private MainForm parent;
        public StartForm(MainForm parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (rad3.Checked) 
            {
                parent.CountItems = parent.CountEnabledItems[0];
            }
            else if (rad5.Checked)
            {
                parent.CountItems = parent.CountEnabledItems[1];
            }
            else
            {
                parent.CountItems = parent.CountEnabledItems[2];
            }
            GameForm gameForm = new GameForm(parent);
            gameForm.MdiParent = parent;
            gameForm.WindowState = FormWindowState.Maximized;
            gameForm.Show();
            this.Close();
        }
    }
}
