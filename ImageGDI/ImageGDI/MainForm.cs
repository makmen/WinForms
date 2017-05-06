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
    public partial class MainForm : Form
    {
        private string pathImage = "..//..//task.jpg";
        private int widthImage = 1000;
        private int heightImage = 600;
        private int countItems = 0;
        private int limitHints = 10;
        private DbConnect db;
        private int[] countEnabledItems = { 9, 25, 49 };

        public MainForm()
        {
            InitializeComponent();
            db = new DbConnect();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartForm startForm = new StartForm(this);
            startForm.MdiParent = this;
            startForm.Show();
        }

        private void showHintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (limitHints-- > 0)
            {
                HintForm hintForm = new HintForm(this);
                hintForm.MdiParent = this;
                hintForm.WindowState = FormWindowState.Maximized;
                hintForm.Show();
            }
            else
            {
                MessageBox.Show("No more hints");
            }
        }

        public string PathImage
        {
            get { return pathImage; }
        }
        
        public int WidthImage
        {
            get { return widthImage; }
        }

        public int HeightImage
        {
            get { return heightImage; }
        }
        public int CountItems
        {
            get { return countItems; }
            set { countItems = value; }
        }

        public int LimitHints
        {
            get { return limitHints; }
        }

        public int[] CountEnabledItems
        {
            get { return countEnabledItems; }
        }

        public DbConnect DB
        {
            get { return db; }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowResultsForm resultsForm = new ShowResultsForm(this, countEnabledItems[0]);
            resultsForm.ShowDialog();
        }

        private void results5X5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowResultsForm resultsForm = new ShowResultsForm(this, countEnabledItems[1]);
            resultsForm.ShowDialog();
        }

        private void results7X7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowResultsForm resultsForm = new ShowResultsForm(this, countEnabledItems[2]);
            resultsForm.ShowDialog();
        }

    }
}
