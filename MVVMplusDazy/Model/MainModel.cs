using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMplusDazy.Model
{
    using Databases.Encje;
    using Databases.Repozytoria;
    using System.Collections.ObjectModel;

    class MainModel
    {
        #region GetSet
        public ObservableCollection<Product> ListOfProducts { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<Shop> ListOfShops { get; set; } = new ObservableCollection<Shop>();
        public ObservableCollection<User> ListOfUsers { get; set; } = new ObservableCollection<User>();
        #endregion

        public MainModel()
        {
            var products = RepoProduct.PobierzWszystkieProdukty();
            foreach (var item in products)
                ListOfProducts.Add(item);
            var shops = RepoShop.PobierzWszystkieSklepy();
            foreach(var item in shops)
                ListOfShops.Add(item);
            var users = RepoUser.PobierzWszystkchKlientow();
            foreach( var item in users)
                ListOfUsers.Add(item);
        }

        #region Metody


        public bool CzyJestTakiUser(User user) => ListOfUsers.Contains(user);

        public bool DodajUseraDoBazy(User user)
        {
            if (!CzyJestTakiUser(user))
            {
                if (RepoUser.DodajKlientaDoBazy(user))
                {
                    ListOfUsers.Add(user);
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
