using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace XMLWeather
{
    public partial class CurrentScreen : UserControl
    {

        public static double tempValue;
        public static double minTempValue;
        public static double maxTempValue;
        public static double conditionNum;

        public static bool citySearched = false;

        public static int weatherNum;

        Image searchIcon = Properties.Resources._711319;

        Image clearSky = Properties.Resources._01d_2x;
        Image fewClouds = Properties.Resources._02d_2x;
        Image scatteredClouds = Properties.Resources._03d_2x;
        Image brokenClouds = Properties.Resources._04d_2x;
        Image showerRain = Properties.Resources._09d_2x;
        Image rain = Properties.Resources._10d_2x;
        Image thunderstorm = Properties.Resources._11d_2x;
        Image snow = Properties.Resources._13d_2x;
        Image mist = Properties.Resources._50d_2x;

        Rectangle iconRec = new Rectangle(75, 220,100,100);
        SolidBrush recBrush = new SolidBrush(Color.White);
        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();
            ChangeBackground();
            
        }

        public void DisplayCurrent()
        {
            cityOutput.Text = $"{Form1.days[0].location}";
            tempValue = Convert.ToDouble(Form1.days[0].currentTemp);
            tempValue = Math.Round(tempValue, 0);
            currentOutput.Text = $"{tempValue} °C";
            minTempValue = Convert.ToDouble(Form1.days[0].tempLow);
            minTempValue = Math.Round(minTempValue, 0);
            minOutput.Text = $"{minTempValue} °";
            maxTempValue = Convert.ToDouble(Form1.days[0].tempHigh);
            maxTempValue = Math.Round(maxTempValue, 0);
            maxOutput.Text = $"{maxTempValue} °";
            conditionOutput.Text = $"{Form1.days[0].condition}";
            windSpeedOutput.Text = $"{Form1.days[0].windSpeed} m/s, {Form1.days[0].windDirection}";

            conditionNum = Convert.ToDouble(Form1.days[0].conditionValue);

            if (conditionNum >199 &&  conditionNum < 250)
            {
                weatherNum = 2;
            }
            else if (conditionNum >299 && conditionNum < 350)
            {
                weatherNum = 3;
            }
            else if (conditionNum > 499 &&  conditionNum < 550)
            {
                weatherNum = 5;
            }
            else if (conditionNum > 599 && conditionNum < 650)
            {
                weatherNum = 6;

            }
            else if (conditionNum > 699 && conditionNum < 790)
            {
                weatherNum = 7;
            }
            else if (conditionNum > 800 && conditionNum < 805)
            {
                weatherNum = 8;
            }
            else if (conditionNum == 800)
            {
                weatherNum = 9;
            }
        }

        public void ChangeBackground()
        {
            if (tempValue <= 3)
            {
                this.BackColor = Color.SlateBlue;
            }
            else if (tempValue >= 4 && tempValue <= 10)
            {
                this.BackColor = Color.LightSteelBlue;
            }
            else
            {
                this.BackColor = Color.DarkOrange;
            }
        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }

        private void CurrentScreen_Paint(object sender, PaintEventArgs e)
        {

            if (weatherNum == 2)
            {
                e.Graphics.DrawImage(thunderstorm, iconRec);
            }
            else if (weatherNum == 3)
            {
                e.Graphics.DrawImage(showerRain, iconRec);
            }
            else if (weatherNum == 5)
            {
                e.Graphics.DrawImage(showerRain, iconRec);
            }
            else if (weatherNum == 6)
            {
                e.Graphics.DrawImage(rain, iconRec);
            }
            else if (weatherNum == 7)
            {
                e.Graphics.DrawImage(mist, iconRec);
            }
            else if (weatherNum == 8)
            {
                e.Graphics.DrawImage(scatteredClouds, iconRec);
            }
            else
            {           
                e.Graphics.DrawImage(clearSky, iconRec);  
            }
            //Refresh();
        }

        private void cityButton_Click(object sender, EventArgs e)
        {
            Form1.city = citySearch.Text;
            Form1.days.Clear();
            Form1.ExtractForecast();
            Form1.ExtractCurrent();
            DisplayCurrent();
            ChangeBackground();
            Refresh();
            
        }
    }
}
    
