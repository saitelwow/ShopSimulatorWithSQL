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
    using System.Windows;

    class MainModel
    {
        #region GetSet
        public ObservableCollection<Product> ListOfProducts { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<Shop> ListOfShops { get; set; } = new ObservableCollection<Shop>();
        public ObservableCollection<User> ListOfUsers { get; set; } = new ObservableCollection<User>();
        public ObservableCollection<IsProduct> ListOfIsProduct { get; set; } = new ObservableCollection<IsProduct>();
        public ObservableCollection<Shopping> ListOfShopping { get; set; } = new ObservableCollection<Shopping>();
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
            var ispro = RepoIsProduct.PobierzWszystkieProduktySklepu();
            foreach (var item in ispro)
                ListOfIsProduct.Add(item);
            var shopping = RepoShopping.PobierzWszystkieZakupy();
            foreach (var item in shopping)
                ListOfShopping.Add(item);
        }

        #region MetodyUser
        public User OddajUseraPoId(int id)
        {
            foreach(var user in ListOfUsers)
            {
                if (user.Id == id)
                    return user;
            }
            return null;
        }
        public User OddajUseraPoLoginie(string login)
        {
            foreach (var usr in ListOfUsers)
            {
                if (usr.Login == login)
                    return usr;
            }
            return null;
        }
        public User OddajUseraPoLoginHaslo(string login, string haslo)
        {
            foreach(var usr in ListOfUsers)
            {
                if (usr.Login == login && usr.Password == haslo)
                    return usr;
            }
            return null;
        }
        public bool CzyJestTakiUser(User user)
        {
            foreach(User usr in ListOfUsers)
            {
                if (user.Login == usr.Login) return true;
                if (user.PhoneNumber == usr.PhoneNumber) return true;
                if (user.MailAddress == usr.MailAddress) return true;
            }
            return false;
        }
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
        public bool EdytujUseraWBazie(User user, int? id)
        {
            if (RepoUser.EdytujKlientaWBazie(user, id))
            {
                for(int i = 0; i < ListOfUsers.Count; i ++)
                {
                    if(ListOfUsers[i].Id == id)
                    {
                        user.Id = id;
                        ListOfUsers[i] = new User(user);
                    }
                }
                return true;
            }
            return false;
        }
        #endregion

        #region MetodyShop
        public Shop OddajSklepPoId(int id)
        {
            foreach(Shop shop in ListOfShops)
            {
                if (shop.Id == id)
                    return shop;
            }
            return null;
        }
        //Czy jest taki sklep
        public bool CzyJestTakiSklepAdres(Shop shop)
        {
            foreach(Shop sh in ListOfShops)
            {
                if (sh.Address == shop.Address) return true;
            }
            return false;
        }
        public bool DodajSklepDoBazy(Shop shop)
        {
            if (CzyJestTakiSklepAdres(shop)) return false;
            if(RepoShop.DodajSklepDoBazy(shop))
            {
                ListOfShops.Add(shop); return true;
            }
            return false;
        }
        #endregion

        #region MetodyProduct
        public Product OddajProduktPoId(int id)
        {
            foreach(var product in ListOfProducts)
            {
                if (product.Id == id)
                    return product;
            }
            return null;
        }
        public ObservableCollection<Product> OddajProduktyWiecejNizZero()
        {
            ObservableCollection<Product> products = new ObservableCollection<Product>();
            foreach(Product pr in ListOfProducts)
            {
                bool isIn = false;
                foreach(IsProduct ip in ListOfIsProduct)
                {
                    if(pr.Id == ip.Id_P && ip.Quantity > 0)
                    {
                        products.Add(pr);
                        isIn = true;
                    }
                    if (isIn) break;
                }
            }
            return products;
        }
        public Product OddajProduktPoNazwie(string name)
        {
            foreach(Product pr in ListOfProducts)
            {
                if (pr.Name == name)
                    return pr;
            }
            return null;
        }
        public bool CzyJestTakiProdukt(Product product)
        {
            foreach(Product pr in ListOfProducts)
            {
                if (pr.Name == product.Name) return true;
            }
            return false;
        }
        public bool DodajProduktDoBazy(Product product)
        {
            if (CzyJestTakiProdukt(product)) return false;
            if(RepoProduct.DodajProduktDoBazy(product))
            {
                ListOfProducts.Add(product);
                return true;
            }
            return false;
        }
        #endregion

        #region MetodyIsProduct
        public ObservableCollection<IsProduct> OddajIsProductPoIdProduktu(int? idP)
        {
            ObservableCollection<IsProduct> isProducts = new ObservableCollection<IsProduct>();
            foreach(IsProduct ip in ListOfIsProduct)
            {
                if(ip.Id_P == idP) isProducts.Add(ip);
            }
            return isProducts;
        }
        public ObservableCollection<IsProduct> OddajIsProductPoIdSklepu(int? idS)
        {
            ObservableCollection<IsProduct> isProducts = new ObservableCollection<IsProduct>();
            foreach (IsProduct ip in ListOfIsProduct)
            {
                if (ip.Id_S == idS) isProducts.Add(ip);
            }
            return isProducts;
        }
        public bool ZmniejszQuantityIsProduct(int quantity, int? idP, int? idS)
        {
            if(RepoIsProduct.EdytujProduktWBazieKupowanie(quantity, idP, idS))
            {
                foreach(var item in ListOfIsProduct)
                {
                    if(item.Id_P == idP && item.Id_S == idS)
                    {
                        item.Quantity = quantity;
                        return true;
                    }
                }
            }
            return false;
        }
        public bool ZwiekszQuantityIsProduct(int quantity, int? idP, int? idS)
        {
            if (RepoIsProduct.EdytujProduktWBazieAsortyment(quantity, idP, idS))
            {
                foreach (var item in ListOfIsProduct)
                {
                    if (item.Id_P == idP && item.Id_S == idS)
                    {
                        item.Quantity += quantity;
                        return true;
                    }
                }
            }
            return false;
        }
        public bool PodlaczProduktPodSklepy(Product product)
        {
            foreach(Shop sh in ListOfShops)
            {
                IsProduct ip = new IsProduct(sh.Id, product.Id, 0);
                if(!RepoIsProduct.DodajProduktDoBazy(ip))
                {
                    return false;
                }
                ListOfIsProduct.Add(ip);
            }
            return true;
        }
        public bool PodlaczSklepPodProdukty(Shop shop)
        {
            foreach(Product pr in ListOfProducts)
            {
                IsProduct ip = new IsProduct(shop.Id, pr.Id, 0);
                if(!RepoIsProduct.DodajProduktDoBazy(ip))
                {
                    return false;
                }
                ListOfIsProduct.Add(ip);
            }
            return true;
        }
        #endregion

        #region MetodyShopping
        public int OddajIdOstatniejTransakcji()
        {
            return ListOfShopping.Max(Shopping => Shopping.Id_T);
        }
        public bool DodajDoBazyTransakcji(int? idP, int? idK, int quantity, int idT)
        {
            Shopping shopping = new Shopping(idP, idK, quantity, idT);
            if(RepoShopping.DodajZakupyaDoBazy(shopping))
            {
                ListOfShopping.Add(shopping);
                return true;
            }
            return false;
        }
        public ObservableCollection<Shopping> OddajZakupyKlienta(int? id)
        {
            ObservableCollection<Shopping> res = new ObservableCollection<Shopping>();
            foreach (var item in ListOfShopping)
            {
                if (item.Id_K == id)
                    res.Add(item);
            }
            return res;
        }
        public ObservableCollection<Shopping> OddajUnikalneZakupyKlienta(int? id)
        {
            ObservableCollection<Shopping> res = new ObservableCollection<Shopping>();
            List<int> listOfIdT = new List<int>();
            foreach(Shopping sh in ListOfShopping)
            {
                if (sh.Id_K != id) continue;
                if (listOfIdT.Contains(sh.Id_T))
                    continue;
                listOfIdT.Add(sh.Id_T);
                res.Add(sh);
            }
            return res;
        }
        public ObservableCollection<Shopping> OddajZakupyPoIdTransakcji(int? id, int? userId)
        {
            ObservableCollection<Shopping> res = new ObservableCollection<Shopping>();
            foreach(Shopping sh in ListOfShopping)
            {
                if (sh.Id_T == id && sh.Id_K == userId)
                    res.Add(sh);
            }
            return res;
        }
        #endregion
    }
}
