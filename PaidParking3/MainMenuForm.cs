using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PaidParking3
{
    public partial class MainMenuForm : Form
    {
        public Parking Parking { get; set; }

        public SimulationParameters SimulationParameters { get; set; }

        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void parkingCreationButton_Click(object sender, EventArgs e)
        {
            ParkingDimensionsForm form = new ParkingDimensionsForm(this);
            Hide();
            form.Show();
        }

        private void parkingLoadingButton_Click(object sender, EventArgs e)
        {
            ParkingLoadingForm form = new ParkingLoadingForm(this);
            Hide();
            form.Show();
        }

        private void simulationParametersButton_Click(object sender, EventArgs e)
        {
            SimulationParametersForm form = new SimulationParametersForm(this);
            Hide();
            form.Show();
        }

        private void simulationButton_Click(object sender, EventArgs e)
        {
            if (Parking != null)
            {
                SimulationForm form = new SimulationForm(this);
                Hide();
                form.Show();
            }
            else
            {
                MessageBox.Show("Парковка не задана.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)e.ClickedItem;
            if (item == aboutProgramToolStripMenuItem)
            {
                //файл справки
            }
            else if (item == aboutDevToolStripMenuItem)
            {
                AboutDevForm form = new AboutDevForm(this);
                Hide();
                form.Show();
            }
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(Parking.Path))
            {
                Parking = Parking.Deserialize();
            }
            if (File.Exists(SimulationParameters.Path))
            {
                SimulationParameters = SimulationParameters.Deserialize();
            }
            else
            {
                SimulationParameters = new SimulationParameters();
            }
        }
    }
}