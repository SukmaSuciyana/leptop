using SukmaSuciyana_Laptop.Helper;
using SukmaSuciyana_Laptop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SukmaSuciyana_Laptop.Context 
{
    
    internal class ContextLaptop
    {
        private string CurrentIDLaptop;

        DatabaseHelpers DatabaseHelpers = new DatabaseHelpers();
        #region
        public List<Laptops> ctxlistLaptop = new List<Laptops>();
        #endregion

        public bool WriteDataLaptop(Laptops laptop) 
        { 
            bool isActive = false;

            string sql = $"insert into laptop (id_laptop,nama,harga,stok) values ({laptop.id_laptop},'{laptop.nama}',{laptop.harga},{laptop.stok})";
            DatabaseHelpers.exc(sql);

            return isActive;
        }

        public bool UpdateDataLaptop(Laptops laptop)
        {
            bool isActive = false;
            CurrentIDLaptop = laptop.id_laptop;
            string sql = $"update laptop set nama = '{laptop.nama}', harga = '{laptop.harga}', stok = {laptop.stok} where id_laptop = '{CurrentIDLaptop}'";
            DatabaseHelpers.exc(sql);

            return isActive;
        }

        public bool DeleteDataLaptop(Laptops laptop)
        {
            bool isActive = false;

            CurrentIDLaptop = laptop.id_laptop;

            string sql = $"DELETE FROM public.laptop WHERE id_laptop = '{CurrentIDLaptop}';";
            DatabaseHelpers.exc(sql);

            return isActive;
        }
    }
}
