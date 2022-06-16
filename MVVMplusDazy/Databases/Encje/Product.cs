using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMplusDazy.Databases.Encje
{
    public class Product
    {
        #region GetSet
        public int? Id { get; set; }
        public double Price { get; set; }
        public string CountryFrom { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        #endregion

        #region Konstruktory
        public Product(MySqlDataReader reader)
        {
            Id = int.Parse(reader["id"].ToString());
            Price = double.Parse(reader["cena"].ToString());
            CountryFrom = reader["kraj"].ToString();
            Name = reader["nazwa"].ToString();
            Type = reader["rodzaj"].ToString();
        }
        public Product(Product product)
        {
            Id = product.Id;
            Price = product.Price;
            CountryFrom = product.CountryFrom;
            Name = product.Name;
            Type = product.Type;
        }
        public Product(double price, string country, string name, string type)
        {
            Id = null;
            Price = price;
            CountryFrom = country;
            Name = name;
            Type = type;
        }
        #endregion

        #region Metody
        public override string ToString()
        {
            return $"{Name}";
        }
        public string ToInsert()
        {
            return $"('{Name}', '{Type}','{CountryFrom}', '{Price}')";
        }
        //aby sprawdzić czy istnieje taki product w naszym zbiorze
        public override bool Equals(object obj)
        {
            //nie porównujemy ID
            var product = obj as Product;
            if (product is null) return false;
            if (Name.ToLower() != product.Name.ToLower()) return false;
            if (CountryFrom.ToLower() != product.CountryFrom.ToLower()) return false;
            return true;
        }
        #endregion
    }
}
