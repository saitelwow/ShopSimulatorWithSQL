using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMplusDazy.Databases.Encje
{
    public class Shop
    {
        #region GetSet
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        #endregion
        public Shop(MySqlDataReader reader)
        {
            Id = int.Parse(reader["id"].ToString());
            Address = reader["adres"].ToString();
            City = reader["miasto"].ToString();
        }
        public Shop(string city, string address) { Address = address; City = city; }
        public Shop() { }
        public override string ToString()
        {
            return $"{City}, {Address}";
        }
    }
}
