using Newtonsoft.Json;
using SukmaSuciyana_Laptop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SukmaSuciyana_Laptop
{
    public partial class OpenWeather : Form
    {
        public OpenWeather()
        {
            InitializeComponent();
            getWeather();
        }
        
        private void OpenWeather_Load(object sender, EventArgs e)
        {

        }
        private void getWeather()
        {
            String APIKey = "8decd3e2a8bd5210f915826411c3cb3b";
            using (WebClient web = new WebClient())
            {
                string url = string.Format($"https://api.openweathermap.org/data/2.5/weather?q={textBox1.Text}&units=metric&appid={APIKey}");
                var json = web.DownloadString(url);
                Weather.root Info = JsonConvert.DeserializeObject<Weather.root>(json);

                lblCity.Text = Info.name.ToString();

                pictureBox1.ImageLocation = "https://openweathermap.org/img/w/" + Info.weather[0].icon + ".png";
                
                lblLat.Text = Info.coord.lat.ToString();
                lblLon.Text = Info.coord.lon.ToString();

                lab_Condition.Text = Info.weather[0].main;
                lab_detail.Text = Info.weather[0].description;

                DateTime sunrise = convertDateTime(Info.sys.sunrise);
                DateTime sunset = convertDateTime(Info.sys.sunset);

                lab_sunset.Text = sunset.ToString();
                lab_sunrise.Text = sunrise.ToString();
                lab_wind.Text = Info.wind.speed.ToString();
                lab_pressure.Text = Info.main.pressure.ToString();

                lblTemp.Text = Info.main.temp.ToString();
                lblMinTemp.Text = Info.main.temp_min.ToString();
                lblMaxTemp.Text = Info.main.temp_max.ToString();
            }
        }
        DateTime convertDateTime(long milisec)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            day = day.AddSeconds(milisec).ToLocalTime();
            return day;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getWeather();
        }
    }
}
