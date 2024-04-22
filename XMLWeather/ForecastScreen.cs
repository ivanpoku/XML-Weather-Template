using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class ForecastScreen : UserControl
    {

        double GlMinTemp;
        double GlMaxTemp;
        public ForecastScreen()
        {
            InitializeComponent();
            displayForecast();
            ChangeBackground();
        }

        public void displayForecast()
        {
            foreach (Day d in Form1.days)
            {
                date1.Text = $"{Form1.days[0].date}";
                GlMaxTemp = Convert.ToDouble(Form1.days[0].tempHigh);
                GlMaxTemp = Math.Round(GlMaxTemp, 0);
                max1.Text = $"H: {GlMaxTemp}°";
                GlMinTemp = Convert.ToDouble(Form1.days[0].tempLow);
                GlMinTemp = Math.Round(GlMinTemp, 0);
                min1.Text = $"L: {GlMinTemp}°";
                conditionLabel1.Text = $"{Form1.days[0].condition}";

                date2.Text = $"{Form1.days[1].date}";
                GlMaxTemp = Convert.ToDouble(Form1.days[1].tempHigh);
                GlMaxTemp = Math.Round(GlMaxTemp, 0);
                max2.Text = $"H: {GlMaxTemp}°";
                GlMinTemp = Convert.ToDouble(Form1.days[1].tempLow);
                GlMinTemp = Math.Round(GlMinTemp, 0);
                min2.Text = $"L: {GlMinTemp}°";
                conditionLabel2.Text = $"{Form1.days[1].condition}";

                date3.Text = $"{Form1.days[2].date}";
                GlMaxTemp = Convert.ToDouble(Form1.days[2].tempHigh);
                GlMaxTemp = Math.Round(GlMaxTemp, 0);
                max3.Text = $"H: {GlMaxTemp}°";
                GlMinTemp = Convert.ToDouble(Form1.days[2].tempLow);
                GlMinTemp = Math.Round(GlMinTemp, 0);
                min3.Text = $"L: {GlMinTemp}°";
                conditionLabel3.Text = $"{Form1.days[2].condition}";

                /*date4.Text = $"{Form1.days[3].date}";
                GlMaxTemp = Convert.ToDouble(Form1.days[3].tempHigh);
                GlMaxTemp = Math.Round(GlMaxTemp, 0);
                max4.Text = $"H: {GlMaxTemp}°";
                GlMinTemp = Convert.ToDouble(Form1.days[3].tempLow);
                GlMinTemp = Math.Round(GlMinTemp, 0);
                min4.Text = $"L: {GlMinTemp}°";
                conditionLabel4.Text = $"{Form1.days[3].condition}";*/
            }

        }

        public void ChangeBackground()
        {
            if (CurrentScreen.tempValue <= 3)
            {
                this.BackColor = Color.SlateBlue;
            }
            else if (CurrentScreen.tempValue >= 4 && CurrentScreen.tempValue <= 10)
            {
                this.BackColor = Color.LightSteelBlue;
            }
            else
            {
                this.BackColor = Color.DarkOrange;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }
    }
}
