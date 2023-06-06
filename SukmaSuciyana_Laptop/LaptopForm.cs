using SukmaSuciyana_Laptop.Context;
using SukmaSuciyana_Laptop.Helper;
using SukmaSuciyana_Laptop.Models;
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
    public partial class LaptopForm : Form
    {
        public string CurrentIDLaptop;

        DatabaseHelpers databaseHelpers = new DatabaseHelpers();
        Laptops laptop = new Laptops();
        public List<Laptops> listLaptops = new List<Laptops>();

        ContextLaptop contextLaptop;

        public LaptopForm()
        {
            InitializeComponent();
            contextLaptop = new ContextLaptop();

            DataLaptop();
            ReadDataLaptops();
            SetDataGrid();
        }

        private void SetDataGrid()
        {
            dataGridView1.Columns["id_laptop"].HeaderText = "ID Laptop";
            dataGridView1.Columns["nama"].HeaderText = "Nama";
            dataGridView1.Columns["harga"].HeaderText = "Harga";
            dataGridView1.Columns["stok"].HeaderText = "Stok";
            dataGridView1.Columns["Edit"].DisplayIndex = 4;
        }

        private void ResetForm()
        {
            tbID.Enabled = true;
            tbID.Text = string.Empty;
            tbNama.Text = string.Empty;
            tbHarga.Text = "0";
            tbStok.Text = "0";
            button1.Enabled = true;
            button2.Enabled = false;
            CurrentIDLaptop = null;

        }

        private void LaptopForm_Load(object sender, EventArgs e)
        {
            
        }

        private void ReadDataLaptops()
        {
            string sql = $"Select * from laptop order by id_laptop";
            DataTable laptops = databaseHelpers.getData(sql);
            DataTableReader reader = laptops.CreateDataReader();
            listLaptops.Clear();
            while (reader.Read())
            {
                Laptops newLaptop = new Laptops();

                newLaptop.id_laptop = (string)reader["id_laptop"];
                newLaptop.nama = (string)reader["nama"];
                newLaptop.harga = (decimal)reader["harga"];
                newLaptop.stok = (int)reader["stok"];
                listLaptops.Add(newLaptop);
            }

            contextLaptop.ctxlistLaptop = listLaptops;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = contextLaptop.ctxlistLaptop;

        }

        private Models.Laptops DataLaptop()
        {
            laptop.id_laptop = tbID.Text;
            laptop.nama = tbNama.Text;
            laptop.harga = decimal.Parse(tbHarga.Text);
            laptop.stok = int.Parse(tbStok.Text);

            return laptop;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CurrentIDLaptop == null)
            {
                Models.Laptops laptops = this.DataLaptop();
                contextLaptop.WriteDataLaptop(laptops);
                
            }
            else
            {
                Models.Laptops laptops = this.DataLaptop();
                contextLaptop.UpdateDataLaptop(laptops);
            }
            dataGridView1.DataSource = null;
            ReadDataLaptops();
            ResetForm();
            SetDataGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                tbID.Enabled = false;
                button2.Enabled = true;
                Laptops laptop = listLaptops[e.RowIndex];
                CurrentIDLaptop = laptop.id_laptop;
                tbID.Text = laptop.id_laptop;
                tbNama.Text = laptop.nama;
                tbHarga.Text = laptop.harga.ToString();
                tbStok.Text = laptop.stok.ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Models.Laptops laptops = this.DataLaptop();
            contextLaptop.DeleteDataLaptop(laptops);
            dataGridView1.DataSource = null;
            ReadDataLaptops();
            ResetForm();
            SetDataGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResetForm();
        } 
    }
}
