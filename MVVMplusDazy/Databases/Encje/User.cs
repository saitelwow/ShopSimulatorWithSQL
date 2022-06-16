using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMplusDazy.Databases.Encje
{
    public class User
    {
        public int? Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public User(MySqlDataReader reader)
        {
            Id = int.Parse(reader["id"].ToString());
            Login = reader["login"].ToString();
            Password = reader["haslo"].ToString();
            PhoneNumber = reader["telefon"].ToString();
            MailAddress = reader["mail"].ToString();
        }
        public User(string login, string password, string phone, string mail)
        {
            Id = null;
            Login = login;
            Password = password;
            PhoneNumber = phone;
            MailAddress = mail;
        }
        public User() { }

        public string ToInsert()
        {
            return $"('{Login}', '{Password}', {PhoneNumber},'{MailAddress}')";
        }
    }
}
