using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SukmaSuciyana_Laptop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void laptopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaptopForm laptopForm = new LaptopForm();
            laptopForm.TopLevel = false;
            panelContent.Controls.Add(laptopForm);
            laptopForm.BringToFront();
            laptopForm.Show();
        }

        private void transaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransaksiForm TransaksiForm = new TransaksiForm();
            TransaksiForm.TopLevel = false;
            panelContent.Controls.Add(TransaksiForm);
            TransaksiForm.BringToFront();
            TransaksiForm.Show();
        }

        private void detailTransaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetailTransaksiForm detailForm = new DetailTransaksiForm();
            detailForm.TopLevel = false;
            panelContent.Controls.Add(detailForm);
            detailForm.BringToFront();
            detailForm.Show();
        }

        private void weatherAPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWeather openWeather = new OpenWeather();
            openWeather.TopLevel = false;
            panelContent.Controls.Add(openWeather);
            openWeather.BringToFront();
            openWeather.Show();
        }
    }
}
