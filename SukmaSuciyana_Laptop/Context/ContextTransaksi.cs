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
    internal class ContextTransaksi
    {
        DatabaseHelpers database = new DatabaseHelpers();
        List<ContextTransaksi> contextlisttransaksi = new List<ContextTransaksi>();
        Models.Transaksis transaksi = new Transaksis();

        public bool Payment(Transaksis transaksi)
        {
            bool isActive = false;

            string sql = $"Insert into transaksi (id_transaksi) VALUES ({transaksi.id_transaksi})";
            database.exc(sql);

            return isActive;
        }
    }
}
