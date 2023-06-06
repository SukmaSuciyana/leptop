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
    public partial class MenuLaptop : Form
    {
        public List<Laptops> listLaptops = new List<Laptops>();

        DatabaseHelpers database = new DatabaseHelpers();
        public string idLaptop;
        public string CurrentIDLaptop
        {
            get;set;
        }

        public void SetCurrentIDLaptop(string value)
        {
            CurrentIDLaptop = value;
        }

        ContextLaptop contextLaptop;

        public MenuLaptop()
        {
            InitializeComponent();
            contextLaptop = new ContextLaptop();
            ReadDataLaptops();
        }

        private void MenuLaptop_Load(object sender, EventArgs e)
        {

        }

        private void ReadDataLaptops()
        {
            string sql = $"Select * from laptop order by id_laptop";
            DataTable laptops = database.getData(sql);
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Laptops laptop = listLaptops[e.RowIndex];
            SetCurrentIDLaptop(laptop.id_laptop);

            MessageBox.Show(CurrentIDLaptop);
            this.Close();
        }
    }
}
