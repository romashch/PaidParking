using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace PaidParking3
{
    public partial class ParkingLoadingForm : Form
    {
        MainMenuForm form;

        public ParkingLoadingForm()
        {
            InitializeComponent();
        }

        public ParkingLoadingForm(MainMenuForm form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void ParkingLoadingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadingButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    List<Cell> cells = db.Cells.Where(c => c.ParkingName == listBox1.SelectedItem).ToList();
                    Parking parking = new Parking(cells);
                    //parking.Serialize();
                    form.Parking = parking;
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Выберите парковку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ParkingLoadingForm_Load(object sender, EventArgs e)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                HashSet<string> parkings = new HashSet<string>();
                foreach (Cell cell in db.Cells)
                {
                    parkings.Add(cell.ParkingName);
                }
                listBox1.Items.Clear();
                listBox1.Items.AddRange(parkings.ToArray());
            }
        }
    }
}
