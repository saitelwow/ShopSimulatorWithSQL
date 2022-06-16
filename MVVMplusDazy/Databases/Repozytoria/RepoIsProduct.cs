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
        // tutaj jest opcja edytowania, dodawania oraz usuwanie czy jest produkt, aby to było połączonej

        //Zapytania
        private const string DODAJ_PRODUKT = "INSERT INTO 'czy_jest_produkt'('id_sklepu', 'id_produktu', 'ilosc') VALUES ";
        private const string WSZYSTKIE_PRODUKTY = "SELECT * FROM czy_jest_produkt";


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
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_PRODUKTY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    shopProd.Add(new IsProduct(reader));
                connection.Close();
            }
            return shopProd;
        }

        //Update
        public static bool EdytujProduktWBazie(IsProduct shopProd, int id)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDYTUJ_Produkt = $"UPDATE czy_jest_produkt SET ilosc='{shopProd.Quantity}' WHERE id_produktu={id}";

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


        // edytowanie produktów tutaj będzie zmienna ilość i w programie za tym będzie szła funkcja z Repozytorium ile i w jakim sklepie
        //przy edytowaniu ilości zmieniasz ilość w klasie a później tutaj wysyłasz obiekt tej klasy


    }
}
