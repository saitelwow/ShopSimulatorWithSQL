using MVVMplusDazy.Databases.Encje;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMplusDazy.Databases.Repozytoria
{
    class RepoShopping
    {
        private const string WSZYSTKIE_ZAMOWIENIA = "SELECT * FROM zakupy";
        private const string DODAJ_ZAKUP = "INSERT INTO zakupy(`id_produktu`, `id_klienta`, `ilosc`, `id_transakcji`) VALUES ";
        private const string ZAMOWIENIE = "SELECT * FROM zakupy WHERE id_klienta=";

        public static List<Shopping> PobierzZakupyKlienta(int id)
        {
            List<Shopping> order = new List<Shopping>();
            using (var connection = DBConnection.Instance.Connection)
            {
                string ZAKUPY_OSOBY = $"SELECT * FROM zakupy WHERE id_klienta={id}";
                MySqlCommand command = new MySqlCommand(ZAKUPY_OSOBY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    order.Add(new Shopping(reader));
                connection.Close();
            }
            return order;
        }

        public static List<Shopping> PobierzWszystkieZakupy()
        {
            List<Shopping> order = new List<Shopping>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_ZAMOWIENIA, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    order.Add(new Shopping(reader));
                connection.Close();
            }
            return order;
        }

        // dodawanie zamowienia

        public static bool DodajZakupyaDoBazy(Shopping order)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_ZAKUP} {order.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                connection.Close();
            }
            return stan;
        }
    }
}
