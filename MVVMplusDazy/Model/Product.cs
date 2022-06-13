using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMplusDazy.Model
{
    public class Product
    {
        #region Atrybuty
        private int _id;
        private double _price;
        private string _countryFrom = string.Empty;
        private int _quantity;
        private string _name = string.Empty;
        private string _type = string.Empty;
        #endregion

        #region GetSet
        public int Id { get; set; }
        public double Price { get; set; }
        public string CountryFrom { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        #endregion
        public Product() { }
        public Product(int id, int quantity, double price, string country, string name, string type)
        {
            Id = id; Quantity = quantity; Price = price; CountryFrom = country; Name = name; Type = type;
        }
        public override string ToString()
        {
            return $"{Name}, {Quantity}";
        }
        public string GetInfo()
        {
            return $"Nazwa: {Name}\nTyp: {Type}\nKraj: {CountryFrom}\nCena:{Price}";
        }
    }
}
