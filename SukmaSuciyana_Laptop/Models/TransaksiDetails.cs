using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SukmaSuciyana_Laptop.Models
{
    public class TransaksiDetails
    {
        public int id_detail_transaksi{ get; set; }
        public int id_transaksi{ get; set; }
        public string id_laptop { get; set; }
        public int quantity { get; set; }
    }
}
