using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMplusDazy.Model
{
    public class Shop
    {
        #region Atrybuty
        private int _id;
        public string _address = String.Empty;
        public string _city = String.Empty;
        public ObservableCollection<Product> _shopProducts;
        #endregion

        #region GetSet
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public ObservableCollection<Product> ShopProducts { get; set; }
        #endregion

        public Shop() { }
        public Shop(int id, string address, string city)
        {
            Id = id; Address = address; City = city;
            ShopProducts = new ObservableCollection<Product>();
        }
        public override string ToString()
        {
            return $"{City}, {Address}";
        }
    }
}
