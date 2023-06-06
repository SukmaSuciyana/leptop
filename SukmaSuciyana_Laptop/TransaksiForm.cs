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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SukmaSuciyana_Laptop
{
    public partial class TransaksiForm : Form
    {
        public string CurrentIDLaptop;
        public string idLaptop;

        Transaksis Transaksi = new Transaksis();

        DatabaseHelpers databaseHelpers = new DatabaseHelpers();
        public List<Transaksis> listTransaksi = new List<Transaksis>();

        public List<TransaksiDetails> listDetailTransaksi = new List<TransaksiDetails>();

        ContextLaptop contextLaptop;
        ContextTransaksi contextTransaksi;
        ContextDetailTransaksi contextDetailTransaksi;
        public TransaksiForm()
        {
            InitializeComponent();
            contextTransaksi = new ContextTransaksi();
            contextDetailTransaksi = new ContextDetailTransaksi();
            DataTransaksi();
            DataDetailTransaksi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal a = Convert.ToDecimal(tbHarga.Text);
            int b = Convert.ToInt32(tbQTY.Text);
            int total = (int)(a * b);
            dataGridView1.Rows.Add(tbIDLap.Text,tbNamaLap.Text, tbHarga.Text, tbQTY.Text, total);
            HitungTotal();
            Clear();
        }

        private void tbIDLap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                MenuLaptop form = new MenuLaptop();
                form.ShowDialog();

                idLaptop = form.CurrentIDLaptop;
                tbIDLap.Text = idLaptop;

                string sql = $"Select * from laptop where id_laptop = '{idLaptop}'";
                tbNamaLap.Text = databaseHelpers.getValue(sql, "nama");
                tbHarga.Text = databaseHelpers.getValue(sql, "harga");
            }
           
        }

        private void TransaksiForm_Load(object sender, EventArgs e)
        {

        }

        private void tbIDLap_TextChanged(object sender, EventArgs e)
        {
            if (tbIDLap.Text != null)
            {
                string sql = $"select * from laptop where id_laptop = '{tbIDLap.Text}'";
                tbNamaLap.Text = databaseHelpers.getValue(sql, "nama");
                tbHarga.Text = databaseHelpers.getValue(sql, "harga");
            }
            else
            {
                MessageBox.Show("Masukkan ID Laptop");
            }
        }

        private Models.Transaksis DataTransaksi()
        {
            Transaksis transaksi = new Transaksis();
            transaksi.id_transaksi = int.Parse(tbIDTran.Text);

            return transaksi;
        }
        private List<TransaksiDetails> DataDetailTransaksi()
        {


            foreach (DataGridViewRow rw in dataGridView1.Rows)
            {
                if (rw.Cells["id_laptop"].Value == null || rw.Cells["id_laptop"].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells["id_laptop"].Value.ToString()))
                {

                }
                else
                {
                    TransaksiDetails details = new TransaksiDetails();
                    details.id_transaksi = int.Parse(tbIDTran.Text);
                    details.id_laptop = rw.Cells["id_laptop"].Value.ToString();
                    details.quantity = int.Parse(rw.Cells["qty"].Value.ToString());

                    listDetailTransaksi.Add(details);

                }
            }

            return listDetailTransaksi;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Kurangi")
            {
                int Rowsindex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(Rowsindex);
            }
            HitungTotal();
        }

        private void HitungTotal()
        {
            int total = 0;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    total += Convert.ToInt32(dataGridView1.Rows[i].Cells["total"].Value);
                }
            }
            tbTotal.Text = Convert.ToDecimal(total).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Models.Transaksis transaksi = this.DataTransaksi();
            contextTransaksi.Payment(transaksi);

            List<TransaksiDetails> detailsList = DataDetailTransaksi();
            bool paymentResult = contextDetailTransaksi.Payment(detailsList);

            MessageBox.Show("Berhasil");
            tbIDTran.Text = string.Empty;

            Clear();
            ClearTransaksi();
        }

        private void ClearTransaksi()
        {
            tbTotal.Text = "0";
            tbBayar.Text = string.Empty;
            tbKembalian.Text = "0";
            dataGridView1.Rows.Clear();
        }

        private void tbBayar_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tbBayar.Text, out int bayar) && int.TryParse(tbTotal.Text, out int total))
            {

                int kembalian = bayar - total;
                tbKembalian.Text = kembalian.ToString();
            }
            else
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            tbIDLap.Text = string.Empty;
            tbNamaLap.Text = string.Empty;
            tbHarga.Text = string.Empty;
            tbQTY.Text = string.Empty;
        }
    }
}
