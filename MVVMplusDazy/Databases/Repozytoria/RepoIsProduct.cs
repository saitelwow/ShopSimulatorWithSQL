using MVVMplusDazy.Databases.Encje;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMplusDazy.Databases.Repozytoria
{
    class RepoIsProduct
    {
        private const string DODAJ_PRODUKT = "INSERT INTO czy_jest_produkt(`id_produktu`, `id_sklepu`, `ilosc`) VALUES ";
        private const string WSZYSTKIE_PRODUKTYSKLEPU = "SELECT * FROM czy_jest_produkt";


        #region CRUD
        //Dodaj
        public static bool DodajProduktDoBazy(IsProduct shopProd)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_PRODUKT} {shopProd.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                connection.Close();
            }
            return stan;
        }

        //Czytaj
        public static List<IsProduct> PobierzWszystkieProduktySklepu()
        {
            List<IsProduct> shopProd = new List<IsProduct>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_PRODUKTYSKLEPU, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    shopProd.Add(new IsProduct(reader));
                connection.Close();
            }
            return shopProd;
        }

        public static List<IsProduct> PobierzWszystkieProduktySklepuZKomenda(string comm)
        {
            List<IsProduct> shopProd = new List<IsProduct>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_PRODUKTYSKLEPU + " " + comm, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    shopProd.Add(new IsProduct(reader));
                connection.Close();
            }
            return shopProd;
        }

        public static List<IsProduct> PobierzProduktySklepuZID(int id)
        {
            string KONKRET = WSZYSTKIE_PRODUKTYSKLEPU + $" WHERE id_sklepu = {id} ";
            List<IsProduct> shopProd = new List<IsProduct>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(KONKRET, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    shopProd.Add(new IsProduct(reader));
                connection.Close();
            }
            return shopProd;
        }

        //Update
        public static bool EdytujProduktWBazieAsortyment(int quantity, int? idP, int? idS)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDYTUJ_Produkt = $"UPDATE czy_jest_produkt SET ilosc=ilosc + {quantity} WHERE id_produktu={idP} AND id_sklepu = {idS}";

                MySqlCommand command = new MySqlCommand(EDYTUJ_Produkt, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) stan = true;

                connection.Close();
            }
            return stan;
        }
        public static bool EdytujProduktWBazieKupowanie(int quantity, int? idP, int? idS)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDYTUJ_Produkt = $"UPDATE czy_jest_produkt SET ilosc = {quantity} WHERE id_produktu={idP} AND id_sklepu = {idS}";

                MySqlCommand command = new MySqlCommand(EDYTUJ_Produkt, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) stan = true;

                connection.Close();
            }
            return stan;
        }
        //Usun
        public static bool UsunProduktWBazie(IsProduct shopProd)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string USUN_Produkt = $"DELETE FROM produkty WHERE id_produktu={shopProd.Id_P} and id_sklepu={shopProd.Id_S}";

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
