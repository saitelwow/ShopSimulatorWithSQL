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
		public int Id_K { get; set; }
		public int Id_S { get; set; }
		public int Id_P { get; set; }
		public int Quantity { get; set; }


	public Shopping(MySqlDataReader reader)
		{
			Id_K = int.Parse(reader["id_klienta "].ToString());
			Id_S = int.Parse(reader["id_sklepu "].ToString());
			Id_P = int.Parse(reader["id_produktu"].ToString());
			Quantity = int.Parse(reader["ilosc"].ToString());

		}

		public string ToInsert()
		{
			return $"('{Id_K}', '{Id_S}', {Id_P},'{Quantity}')";
		}
	}
}
