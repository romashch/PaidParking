using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PaidParking3
{
    public partial class AboutDevForm : Form
    {
        MainMenuForm form;

        public AboutDevForm()
        {
            InitializeComponent();
        }

        public AboutDevForm(MainMenuForm form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void AboutDevForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
