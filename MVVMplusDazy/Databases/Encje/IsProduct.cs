using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMplusDazy.Databases.Encje
{
    public class IsProduct
    {
		public int? Id_S { get; set; }
		public int? Id_P { get; set; }
		public int Quantity { get; set; }

		public IsProduct(MySqlDataReader reader)
		{
			Id_P = int.Parse(reader["id_produktu"].ToString());
			Id_S = int.Parse(reader["id_sklepu"].ToString());		
			Quantity = int.Parse(reader["ilosc"].ToString());
		}
		public IsProduct(int? id_S, int? id_P, int quantity)
        {
            Id_S = id_S;
            Id_P = id_P;
            Quantity = quantity;
        }

        public string ToInsert()
		{
			return $"({Id_P}, {Id_S}, {Quantity})";
		}
	}
}
