using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PaidParking3
{
    public partial class MainMenuForm : Form
    {
        public const string PathHelpFile = @"aboutSystem.html";

        public Parking Parking { get; set; }

        public SimulationParameters SimulationParameters { get; set; }

        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void parkingCreationButton_Click(object sender, EventArgs e)
        {
            ParkingDimensionsForm form2 = new ParkingDimensionsForm(this);
            Hide();
            if (Parking == null)
            {
                form2.Show();
            }
            else
            {
                Form form = new ParkingCreationForm(this, form2, Parking.Length, Parking.Width);
                form.Show();
            }
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
                OpenHelpFile();
            }
            else if (item == aboutDevToolStripMenuItem)
            {
                AboutDevForm form = new AboutDevForm(this);
                Hide();
                form.Show();
            }
        }

        static int filehc = 10279;

        public static void OpenHelpFile()
        {
            if (File.Exists(PathHelpFile))
            {
                try
                {
                    int fhc = File.ReadAllText(PathHelpFile).Length;
                    //filehc = fhc;
                    if (fhc != filehc)
                        throw new Exception();
                    Process p = Process.Start(new ProcessStartInfo(PathHelpFile) { UseShellExecute = true });
                    if (p == null)
                        throw new Exception();
                }
                catch (Exception)
                {
                    MessageBox.Show("Файл справки повреждён.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Файл справки не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            //if (File.Exists(Parking.Path))
            //{
            //    Parking = Parking.Deserialize();
            //}
            if (File.Exists(SimulationParameters.Path))
            {
                SimulationParameters = SimulationParameters.Deserialize();
            }
            if (SimulationParameters == null)
            {
                SimulationParameters = new SimulationParameters();
            }
        }
    }
}