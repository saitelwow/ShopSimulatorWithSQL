using MVVMplusDazy.Databases.Encje;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMplusDazy.Databases.Repozytoria
{
    static class RepoProduct
    {
        #region Zapytania
        private const string WSZYSTKIE_PRODUKTY = "SELECT * FROM produkty";
        private const string DODAJ_PRODUKT = "INSERT INTO produkty(`cena`, `kraj`, `nazwa`, `rodzaj`) VALUES ";
        #endregion

        #region Metody CRUD - create, read, update, delete
        //Create
        public static bool DodajProduktDoBazy(Product product)
        {
            bool stan = false;
            string str = product.Price.ToString().Replace(',', '.');
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_PRODUKT} ('{str}', '{product.CountryFrom}', '{product.Name}', '{product.Type}')", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                product.Id = (int)command.LastInsertedId;
                connection.Close();
            }
            return stan;
        }

        //Read
        public static List<Product> PobierzWszystkieProdukty()
        {
            List<Product> product = new List<Product>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_PRODUKTY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    product.Add(new Product(reader));
                connection.Close();
            }
            return product;
        }

        //Update
        //public static bool EdytujProduktWBazie(Product product, string name)
        //{
        //    bool stan = false;
        //    using (var connection = DBConnection.Instance.Connection)
        //    {
        //        string EDYTUJ_Produkt = $"UPDATE produkty SET ilosc='{product.Quantity}' WHERE nazwa={name}";

        //        MySqlCommand command = new MySqlCommand(EDYTUJ_Produkt, connection);
        //        connection.Open();
        //        var n = command.ExecuteNonQuery();
        //        if (n == 1) stan = true;

        //        connection.Close();
        //    }
        //    return stan;
        //}

        //Delete
        public static bool UsunProduktWBazie(Product product, string name)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string USUN_Produkt = $"DELETE FROM produkty WHERE nazwa={name}";

                MySqlCommand command = new MySqlCommand(USUN_Produkt, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) stan = true;

                connection.Close();
            }
            return stan;
        }
        #endregion
    }
}
