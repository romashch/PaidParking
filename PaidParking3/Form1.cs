using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaidParking3
{
    public partial class SimulationParametersForm : Form
    {
        SimulationParameters simulationParameters;
        MainMenuForm form;

        public SimulationParametersForm()
        {
            InitializeComponent();
        }

        public SimulationParametersForm(MainMenuForm form)
        {
            InitializeComponent();
            this.form = form;
            simulationParameters = form.SimulationParameters;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            intervalLabel.Text = string.Format("Интервал ({0}-{1})", (int)SimulationParameters.TFIntervalMin, (int)SimulationParameters.TFIntervalMax);
            interval2Label.Text = string.Format("Интервал ({0}-{1})", (int)SimulationParameters.PTIntervalMin, (int)SimulationParameters.PTIntervalMax);
            dayPriceLabel.Text = string.Format("Тариф дневной ({0}-{1})", (int)SimulationParameters.DayMinPrice, (int)SimulationParameters.DayMaxPrice);
            nightPriceLabel.Text = string.Format("Тариф ночной (22:00-6:00, {0}-{1})", (int)SimulationParameters.NightMinPrice, (int)SimulationParameters.NightMaxPrice);
            intervalTextBox.Text = simulationParameters.Interval.ToString();
            distributionLawComboBox.SelectedItem = "Нормальный";
            firstParamTextBox.Text = simulationParameters.Mx.ToString();
            secondParamTextBox.Text = simulationParameters.Dx.ToString();
            interval2TextBox.Text = simulationParameters.Interval2.ToString();
            distributionLaw2ComboBox.SelectedItem = "Нормальный";
            firstParam2TextBox.Text = simulationParameters.Mx2.ToString();
            secondParam2TextBox.Text = simulationParameters.Dx2.ToString();
            setDefaultValues();
        }

        private void setDefaultValues()
        {
            likelihoodTextBox.Text = simulationParameters.EnteringProbability.ToString();
            percentageOfTrucksTextBox.Text = simulationParameters.TrucksPercentage.ToString();
            dayPriceTextBox.Text = simulationParameters.DayTariffPrice.ToString();
            nightPriceTextBox.Text = simulationParameters.NightTariffPrice.ToString();
            if (simulationParameters.TrafficFlowType == SimulationParameters.DetRan.Random)
            {
                randomRadioButton.Checked = true;
                SimulationParameters.DistributionLaw law = simulationParameters.Law;
                switch (law)
                {
                    case SimulationParameters.DistributionLaw.Normal:
                        {
                            //distributionLawComboBox.SelectedItem = "Нормальный";
                            //firstParamTextBox.Text = simulationParameters.Mx.ToString();
                            //secondParamTextBox.Text = simulationParameters.Dx.ToString();
                            break;
                        }
                    case SimulationParameters.DistributionLaw.Uniform:
                        {
                            distributionLawComboBox.SelectedItem = "Равномерный";
                            firstParamTextBox.Text = simulationParameters.Min.ToString();
                            secondParamTextBox.Text = simulationParameters.Max.ToString();
                            break;
                        }
                    case SimulationParameters.DistributionLaw.Exponential:
                        {
                            distributionLawComboBox.SelectedItem = "Экспоненциальный";
                            firstParamTextBox.Text = simulationParameters.Lambda.ToString();
                            break;
                        }
                }
            }
            else
            {
                deterministicRadioButton.Checked = true;
                //intervalTextBox.Text = simulationParameters.Interval.ToString();
            }
            if (simulationParameters.ParkingTimeType == SimulationParameters.DetRan.Random)
            {
                random2RadioButton.Checked = true;
                SimulationParameters.DistributionLaw law2 = simulationParameters.Law2;
                switch (law2)
                {
                    case SimulationParameters.DistributionLaw.Normal:
                        {
                            //distributionLaw2ComboBox.SelectedItem = "Нормальный";
                            //firstParam2TextBox.Text = simulationParameters.Mx2.ToString();
                            //secondParam2TextBox.Text = simulationParameters.Dx2.ToString();
                            break;
                        }
                    case SimulationParameters.DistributionLaw.Uniform:
                        {
                            distributionLaw2ComboBox.SelectedItem = "Равномерный";
                            firstParam2TextBox.Text = simulationParameters.Min2.ToString();
                            secondParam2TextBox.Text = simulationParameters.Max2.ToString();
                            break;
                        }
                    case SimulationParameters.DistributionLaw.Exponential:
                        {
                            distributionLaw2ComboBox.SelectedItem = "Экспоненциальный";
                            firstParam2TextBox.Text = simulationParameters.Lambda2.ToString();
                            break;
                        }
                }
            }
            else
            {
                deterministic2RadioButton.Checked = true;
                //interval2TextBox.Text = simulationParameters.Interval2.ToString();
            }
            startTimeHoursTextBox.Text = simulationParameters.StartHour.ToString();
            startTimeMinutesTextBox.Text = simulationParameters.StartMinute.ToString();
        }

        private void deterministicRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox1.Enabled = true;
        }

        private void randomRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
        }

        private void deterministic2RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Enabled = true;
            groupBox5.Enabled = false;
        }

        private void random2RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Enabled = false;
            groupBox5.Enabled = true;
        }

        private void distributionLawComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = distributionLawComboBox.SelectedItem.ToString();
            switch (selectedItem)
            {
                case "Нормальный":
                    {
                        panel3.Visible = true;
                        firstParamNameLabel.Text = string.Format("MX ({0}-{1})", (int)SimulationParameters.TFMxMin, (int)SimulationParameters.TFMxMax);
                        secondParamNameLabel.Text = string.Format("DX ({0}-{1})", (int)SimulationParameters.TFDxMin, SimulationParameters.TFDxMax);
                        firstParamTextBox.Text = simulationParameters.Mx.ToString();
                        secondParamTextBox.Text = simulationParameters.Dx.ToString();
                        break;
                    }
                case "Равномерный":
                    {
                        panel3.Visible = true;
                        firstParamNameLabel.Text = string.Format("min ({0}-{1})", (int)SimulationParameters.TFMinMin, (int)SimulationParameters.TFMinMax);
                        secondParamNameLabel.Text = string.Format("max ({0}-{1})", (int)SimulationParameters.TFMaxMin, (int)SimulationParameters.TFMaxMax);
                        firstParamTextBox.Text = simulationParameters.Min.ToString();
                        secondParamTextBox.Text = simulationParameters.Max.ToString();
                        break;
                    }
                case "Экспоненциальный":
                    {
                        panel3.Visible = false;
                        firstParamNameLabel.Text = string.Format("λ ({0}-{1})", SimulationParameters.TFLambdaMin, SimulationParameters.TFLambdaMax);
                        firstParamTextBox.Text = simulationParameters.Lambda.ToString();
                        break;
                    }
            }
        }

        private void distributionLaw2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = distributionLaw2ComboBox.SelectedItem.ToString();
            switch (selectedItem)
            {
                case "Нормальный":
                    {
                        panel4.Visible = true;
                        firstParam2NameLabel.Text = string.Format("MX ({0}-{1})", (int)SimulationParameters.PTMxMin, (int)SimulationParameters.PTMxMax);
                        secondParam2NameLabel.Text = string.Format("DX ({0}-{1})", (int)SimulationParameters.PTDxMin, SimulationParameters.PTDxMax);
                        firstParam2TextBox.Text = simulationParameters.Mx2.ToString();
                        secondParam2TextBox.Text = simulationParameters.Dx2.ToString();
                        break;
                    }
                case "Равномерный":
                    {
                        panel4.Visible = true;
                        firstParam2NameLabel.Text = string.Format("min ({0}-{1})", (int)SimulationParameters.PTMinMin, (int)SimulationParameters.PTMinMax);
                        secondParam2NameLabel.Text = string.Format("max ({0}-{1})", (int)SimulationParameters.PTMaxMin, (int)SimulationParameters.PTMaxMax);
                        firstParam2TextBox.Text = simulationParameters.Min2.ToString();
                        secondParam2TextBox.Text = simulationParameters.Max2.ToString();
                        break;
                    }
                case "Экспоненциальный":
                    {
                        panel4.Visible = false;
                        firstParam2NameLabel.Text = string.Format("λ ({0}-{1})", SimulationParameters.PTLambdaMin, SimulationParameters.PTLambdaMax);
                        firstParam2TextBox.Text = simulationParameters.Lambda2.ToString();
                        break;
                    }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SimulationParameters simulationParameters = new SimulationParameters();
            string value0 = likelihoodTextBox.Text.Replace('.', ',');
            double value;
            if (!double.TryParse(value0, out value) || value < 0 || value > 1)
            {
                MessageBox.Show("Некорректное значение вероятности заезда.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                simulationParameters.EnteringProbability = value;
            }
            value0 = percentageOfTrucksTextBox.Text.Replace('.', ',');
            if (!double.TryParse(value0, out value) || value < 0 || value > 100)
            {
                MessageBox.Show("Некорректное значение процента грузовых автомобилей.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                simulationParameters.TrucksPercentage = value;
            }
            value0 = dayPriceTextBox.Text.Replace('.', ',');
            if (!double.TryParse(value0, out value) || value < SimulationParameters.DayMinPrice || value > SimulationParameters.DayMaxPrice)
            {
                MessageBox.Show("Некорректное значение дневного тарифа.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                simulationParameters.DayTariffPrice = value;
            }
            value0 = nightPriceTextBox.Text.Replace('.', ',');
            if (!double.TryParse(value0, out value) || value < SimulationParameters.NightMinPrice || value > SimulationParameters.NightMaxPrice)
            {
                MessageBox.Show("Некорректное значение ночного тарифа.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                simulationParameters.NightTariffPrice = value;
            }
            if (deterministicRadioButton.Checked)
            {
                simulationParameters.TrafficFlowType = SimulationParameters.DetRan.Deterministic;
                value0 = intervalTextBox.Text.Replace('.', ',');
                if (!double.TryParse(value0, out value) || value < SimulationParameters.TFIntervalMin || value > SimulationParameters.TFIntervalMax)
                {
                    MessageBox.Show("Некорректное значение интервала транспортного потока.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    simulationParameters.Interval = value;
                }
            }
            else
            {
                simulationParameters.TrafficFlowType = SimulationParameters.DetRan.Random;
                switch (distributionLawComboBox.SelectedItem.ToString())
                {
                    case "Нормальный":
                        {
                            simulationParameters.Law = SimulationParameters.DistributionLaw.Normal;
                            value0 = firstParamTextBox.Text.Replace('.', ',');
                            if (!double.TryParse(value0, out value) || value < SimulationParameters.TFMxMin || value > SimulationParameters.TFMxMax)
                            {
                                MessageBox.Show("Некорректное значение MX транспортного потока.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                simulationParameters.Mx = value;
                            }
                            value0 = secondParamTextBox.Text.Replace('.', ',');
                            if (!double.TryParse(value0, out value) || value < SimulationParameters.TFDxMin || value > SimulationParameters.TFDxMax)
                            {
                                MessageBox.Show("Некорректное значение DX транспортного потока.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                simulationParameters.Dx = value;
                            }
                            break;
                        }
                    case "Равномерный":
                        {
                            simulationParameters.Law = SimulationParameters.DistributionLaw.Uniform;
                            value0 = firstParamTextBox.Text.Replace('.', ',');
                            if (!double.TryParse(value0, out value) || value < SimulationParameters.TFMinMin || value > SimulationParameters.TFMinMax)
                            {
                                MessageBox.Show("Некорректное значение min транспортного потока.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                try
                                {
                                    simulationParameters.Min = value;
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    MessageBox.Show("Некорректное значение min и max транспортного потока.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            value0 = secondParamTextBox.Text.Replace('.', ',');
                            if (!double.TryParse(value0, out value) || value < SimulationParameters.TFMaxMin || value > SimulationParameters.TFMaxMax)
                            {
                                MessageBox.Show("Некорректное значение max транспортного потока.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                try
                                {
                                    simulationParameters.Max = value;
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    MessageBox.Show("Некорректное значение min и max транспортного потока.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            break;
                        }
                    case "Экспоненциальный":
                        {
                            simulationParameters.Law = SimulationParameters.DistributionLaw.Exponential;
                            value0 = firstParamTextBox.Text.Replace('.', ',');
                            if (!double.TryParse(value0, out value) || value < SimulationParameters.TFLambdaMin || value > SimulationParameters.TFLambdaMax)
                            {
                                MessageBox.Show("Некорректное значение λ транспортного потока.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                simulationParameters.Lambda = value;
                            }
                            break;
                        }
                }
            }
            if (deterministic2RadioButton.Checked)
            {
                simulationParameters.ParkingTimeType = SimulationParameters.DetRan.Deterministic;
                value0 = interval2TextBox.Text.Replace('.', ',');
                if (!double.TryParse(value0, out value) || value < SimulationParameters.PTIntervalMin || value > SimulationParameters.PTIntervalMax)
                {
                    MessageBox.Show("Некорректное значение интервала времени стоянки.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    simulationParameters.Interval2 = value;
                }
            }
            else
            {
                simulationParameters.ParkingTimeType = SimulationParameters.DetRan.Random;
                switch (distributionLaw2ComboBox.SelectedItem.ToString())
                {
                    case "Нормальный":
                        {
                            simulationParameters.Law2 = SimulationParameters.DistributionLaw.Normal;
                            value0 = firstParam2TextBox.Text.Replace('.', ',');
                            if (!double.TryParse(value0, out value) || value < SimulationParameters.PTMxMin || value > SimulationParameters.PTMxMax)
                            {
                                MessageBox.Show("Некорректное значение MX времени стоянки.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                simulationParameters.Mx2 = value;
                            }
                            value0 = secondParam2TextBox.Text.Replace('.', ',');
                            if (!double.TryParse(value0, out value) || value < SimulationParameters.PTDxMin || value > SimulationParameters.PTDxMax)
                            {
                                MessageBox.Show("Некорректное значение DX времени стоянки.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                simulationParameters.Dx2 = value;
                            }
                            break;
                        }
                    case "Равномерный":
                        {
                            simulationParameters.Law2 = SimulationParameters.DistributionLaw.Uniform;
                            value0 = firstParam2TextBox.Text.Replace('.', ',');
                            if (!double.TryParse(value0, out value) || value < SimulationParameters.PTMinMin || value > SimulationParameters.PTMinMax)
                            {
                                MessageBox.Show("Некорректное значение min времени стоянки.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                try
                                {
                                    simulationParameters.Min2 = value;
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    MessageBox.Show("Некорректное значение min и max времени стоянки.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            value0 = secondParam2TextBox.Text.Replace('.', ',');
                            if (!double.TryParse(value0, out value) || value < SimulationParameters.PTMaxMin || value > SimulationParameters.PTMaxMax)
                            {
                                MessageBox.Show("Некорректное значение max времени стоянки.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                try
                                {
                                    simulationParameters.Max2 = value;
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    MessageBox.Show("Некорректное значение min и max времени стоянки.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            break;
                        }
                    case "Экспоненциальный":
                        {
                            simulationParameters.Law2 = SimulationParameters.DistributionLaw.Exponential;
                            value0 = firstParam2TextBox.Text.Replace('.', ',');
                            if (!double.TryParse(value0, out value) || value < SimulationParameters.PTLambdaMin || value > SimulationParameters.PTLambdaMax)
                            {
                                MessageBox.Show("Некорректное значение λ времени стоянки.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                simulationParameters.Lambda2 = value;
                            }
                            break;
                        }
                }
            }
            value0 = startTimeHoursTextBox.Text;
            int value2;
            if (!int.TryParse(value0, out value2) || value2 < 0 || value2 > 23)
            {
                MessageBox.Show("Некорректное значение времени начала.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                simulationParameters.StartHour = value2;
            }
            value0 = startTimeMinutesTextBox.Text;
            if (!int.TryParse(value0, out value2) || value2 < 0 || value2 > 59)
            {
                MessageBox.Show("Некорректное значение времени начала.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                simulationParameters.StartMinute = value2;
            }
            //MessageBox.Show("Параметры моделирования заданы успешно.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            form.SimulationParameters = simulationParameters;
            simulationParameters.Serialize();
            Close();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SimulationParametersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Show();
        }
    }
}