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
    public partial class DetailTransaksiForm : Form
    {
        DatabaseHelpers databaseHelpers = new DatabaseHelpers();
        public List<TransaksiDetails> listDetailTransaksi = new List<TransaksiDetails>();
        ContextDetailTransaksi contextDetailTransaksi;
        public DetailTransaksiForm()
        {
            InitializeComponent();
            contextDetailTransaksi = new ContextDetailTransaksi();
            DataDetailTransaksi();
            SetDataGrid();
        }

        private void SetDataGrid()
        {
            dataGridView1.Columns["id_detail_transaksi"].HeaderText = "ID Detail Transaksi";
            dataGridView1.Columns["id_transaksi"].HeaderText = "ID Transaksi";
            dataGridView1.Columns["id_laptop"].HeaderText = "ID Laptop";
            dataGridView1.Columns["quantity"].HeaderText = "QTY";
        }

        private void DataDetailTransaksi()
        {
            string sql = $"Select * from detail_transaksi order by detail_transaksi";
            DataTable laptops = databaseHelpers.getData(sql);
            DataTableReader reader = laptops.CreateDataReader();
            listDetailTransaksi.Clear();
            while (reader.Read())
            {
                TransaksiDetails details = new TransaksiDetails();

                details.id_detail_transaksi = (int)reader["id_detail_transaksi"];
                details.id_transaksi = (int)reader["id_transaksi"];
                details.id_laptop = (string)reader["id_laptop"];
                details.quantity = (int)reader["qty"];
                listDetailTransaksi.Add(details);
            }

            contextDetailTransaksi.contextlisttransaksi = listDetailTransaksi;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = contextDetailTransaksi.contextlisttransaksi;

        }

        private void DetailTransaksiForm_Load(object sender, EventArgs e)
        {

        }
    }
}
