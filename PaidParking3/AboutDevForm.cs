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

        private void AboutDevForm_Load(object sender, EventArgs e)
        {
            string s = "О РАЗРАБОТЧИКАХ" + "\n"
                     + "Самарский университет" + "\n"
                     + "Кафедра программных систем" + "\n"
                     + "Курсовой проект по дисциплине \"Программная инженерия\"" + "\n"
                     + "Тема проекта: \"Система моделирования работы платной парковки\"" + "\n"
                     + "Разработчики: студенты группы 6414-020302D" + "\n"
                     + "Щелоков Роман Сергеевич" + "\n"
                     + "Чупахин Николай Викторович" + "\n"
                     + "Самара 2021";
            label1.Text = s;
        }
    }
}
