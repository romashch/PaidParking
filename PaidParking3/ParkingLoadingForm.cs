using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
            Close();
        }
    }
}
