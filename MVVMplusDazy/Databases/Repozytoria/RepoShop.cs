using MVVMplusDazy.Databases.Encje;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMplusDazy.Databases.Repozytoria
{
    static class RepoShop
    {
        private const string WSZYSTKIE_SKLEPY = "SELECT * FROM sklep";
        private const string DODAJ_SKLEP = "INSERT INTO sklep(`adres`, `miasto`) VALUES ";
        public static List<Shop> PobierzWszystkieSklepy()
        {
            List<Shop> shop = new List<Shop>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_SKLEPY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    shop.Add(new Shop(reader));
                connection.Close();
            }
            return shop;
        }
        public static bool DodajSklepDoBazy(Shop shop)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_SKLEP} ('{shop.Address}', '{shop.City}')", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                shop.Id = (int)command.LastInsertedId;
                connection.Close();
            }
            return stan;
        }
    }
}
