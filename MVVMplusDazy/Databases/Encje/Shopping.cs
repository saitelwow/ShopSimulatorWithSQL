using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMplusDazy.Databases.Encje
{
    public class Shopping
    {
		public int? Id_K { get; set; }
		public int Id_T { get; set; }
		public int? Id_P { get; set; }
		public int Quantity { get; set; }


		public Shopping(MySqlDataReader reader)
		{
			Id_P = int.Parse(reader["id_produktu"].ToString());
			Id_K = int.Parse(reader["id_klienta"].ToString());
			Quantity = int.Parse(reader["ilosc"].ToString());
			Id_T = int.Parse(reader["id_transakcji"].ToString());
		}
		public Shopping(int? id_P, int? id_K, int quantity, int id_T)
        {
            Id_K = id_K;
            Id_T = id_T;
            Id_P = id_P;
            Quantity = quantity;
        }

        public string ToInsert()
		{
			return $"( {Id_P}, {Id_K}, {Quantity}, {Id_T})";
		}
	}
}
