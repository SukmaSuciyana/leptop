using SukmaSuciyana_Laptop.Helper;
using SukmaSuciyana_Laptop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SukmaSuciyana_Laptop.Context
{
    internal class ContextDetailTransaksi
    {
        DatabaseHelpers database = new DatabaseHelpers();
        public List<TransaksiDetails> contextlisttransaksi = new List<TransaksiDetails>();
        Models.Transaksis transaksi = new Transaksis();

        public bool Payment(List<TransaksiDetails> detailsList)
        {
            bool isActive = false;

            foreach (TransaksiDetails details in detailsList)
            {
                string sql = $"INSERT INTO detail_transaksi (id_transaksi, id_laptop, qty) VALUES ({details.id_transaksi}, '{details.id_laptop}', {details.quantity})";
                database.exc(sql);
                string sql2 = $"UPDATE laptop SET stok = stok - ({details.quantity}) WHERE id_laptop = '{details.id_laptop}'";
                database.exc(sql2);
                isActive = true;
            }

            return isActive;
        }
    }
}
