using System;
using System.Windows.Forms;

using DbBank;

namespace SearchBanks
{
    public partial class MainForm : Form
    {
        private BankDb dbConnect;
        public int Num { get; set; } // количество объетов показываемое в поиске
        private MapForm mapForm;
        public string SearchMinMaxRates { get; set; }


        public MapForm MapForm
        {
            get { return mapForm; }
            set { mapForm = value; }
        }

        public BankDb DBConnect
        {
            get { return dbConnect; }
        }

        public MainForm()
        {
            InitializeComponent();
            dbConnect = new BankDb();
            Num = 5;
            // нужно обновить данные xml при каждом запуске
            ParseXml parseXml = new ParseXml(dbConnect);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool show = true;
            AddAtmForm addAtmForm = new AddAtmForm();
            foreach (Form item in this.MdiChildren)
            {
                if (item is AddAtmForm)
                {
                    show = false;
                    item.Focus();
                }
            }
            if (show)
            {
                addAtmForm.MdiParent = this;
                addAtmForm.Show();
            }
        }

        private void openMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mapForm == null)
            {
                mapForm = new MapForm();
                mapForm.MdiParent = this;
                mapForm.Show();
            }
            else
            {
                mapForm.Focus();
            }
        }

        private void searchMinmaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mapForm == null)
            {
                mapForm = new MapForm();
                mapForm.MdiParent = this;
                mapForm.Show();
            }
            bool show = true;
            MinMaxForm minmax = new MinMaxForm();
            foreach (Form item in this.MdiChildren)
            {
                if (item is MinMaxForm)
                {
                    show = false;
                    item.Focus();
                }
            }
            if (show)
            {
                minmax.MdiParent = this;
                minmax.Show();
            }
        }

        private void searchTheCloserstObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mapForm == null)
            {
                mapForm = new MapForm();
                mapForm.MdiParent = this;
                mapForm.Show();
            }
            mapForm.ClosestObjects();
        }

        private void showAllObjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mapForm == null)
            {
                mapForm = new MapForm();
                mapForm.MdiParent = this;
                mapForm.Show();
            }
            mapForm.ShowAllRedMarkers();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool show = true;
            ShowAllAtmForm allAtmForm = new ShowAllAtmForm();
            foreach (Form item in this.MdiChildren)
            {
                if (item is ShowAllAtmForm)
                {
                    show = false;
                    item.Focus();
                }
            }
            if (show)
            {
                allAtmForm.MdiParent = this;
                allAtmForm.Show();
            }
        }

        private void addFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mapForm == null)
            {
                mapForm = new MapForm();
                mapForm.MdiParent = this;
                mapForm.Show();
            }
            bool show = true;
            FilterForm filterForm = new FilterForm();
            foreach (Form item in this.MdiChildren)
            {
                if (item is FilterForm)
                {
                    show = false;
                    item.Focus();
                }
            }
            if (show)
            {
                filterForm.MdiParent = this;
                filterForm.Show();
            }
        }
    }
}
