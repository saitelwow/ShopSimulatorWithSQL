using MVVMplusDazy.Databases.Encje;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMplusDazy.Databases.Repozytoria
{
    static class RepoUser
    {
        private const string WSZYSCY_KLIENCI = "SELECT * FROM klient";
        private const string DODAJ_KLIENT = "INSERT INTO klient(`login`, `haslo`, `telefon`, `mail`) VALUES ";


        public static List<User> PobierzWszystkchKlientow()
        {
            List<User> user = new List<User>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSCY_KLIENCI, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    user.Add(new User(reader));
                connection.Close();
            }
            return user;
        }

        public static User PobierzKlientaPoID(int id)
        {
            string KONKRETNY_KLIENT = WSZYSCY_KLIENCI + $" WHERE ID = {id}";
            User user = new User();
            using(var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(KONKRETNY_KLIENT, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while(reader.Read())
                    user = new User(reader);
                connection.Close();
            }
            return user;
        }

        public static User PobierzKlientaPoLoginHaslo(string login, string haslo)
        {
            string KONKRETNY_KLIENT = WSZYSCY_KLIENCI + $" WHERE LOGIN = '{login}' AND HASLO = '{haslo}'";
            User user = new User();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(KONKRETNY_KLIENT, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    user = new User(reader);
                connection.Close();
            }
            return user;
        }

        public static bool DodajKlientaDoBazy(User user)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_KLIENT} {user.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                user.Id = (int)command.LastInsertedId;
                connection.Close();
            }
            return stan;
        }

        public static bool EdytujKlientaWBazie(User user, int? id)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDYTUJ_Usera = $"UPDATE klient SET login='{user.Login}', haslo='{user.Password}', telefon='{user.PhoneNumber}', mail='{user.MailAddress}' WHERE id={id}";
                MySqlCommand command = new MySqlCommand(EDYTUJ_Usera, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) stan = true;
                connection.Close();
            }
            return stan;
        }
    }
}
