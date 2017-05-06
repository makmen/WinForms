using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageGDI
{
    public partial class HintForm : Form
    {
        private MainForm parent;
        public HintForm(MainForm parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.Text = "Count of hints: " + parent.LimitHints;
        }

        private void HintForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr1 = e.Graphics;
            Bitmap bmp = new Bitmap(parent.PathImage);
            gr1.DrawImage(bmp, new Rectangle(0, 0, parent.WidthImage, parent.HeightImage));
        }

    }
}
