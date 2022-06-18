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
        //public bool EdytujUseraWBazie(User user)
        //{
        //    if(RepoUser.EdytujKlientaWBazie(user.Id, user.Login, user.Password, user.MailAddress, user.PhoneNumber))
        //    {
        //        for(int i = 0; i< ListOfUsers.Count; i++)
        //        {
        //            if (ListOfUsers[i].Id == user.Id)
        //            {
        //                user.Id = user.Id;
        //                ListOfUsers[i] = new User(user);
        //            }
        //        }
        //    }
        //    return false;
        //}
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
        //Dodaj sklep do bazy
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
        //Czy jest taki produkt
        //dodaj produkt do bazy

        #endregion

        #region MetodyIsProduct
        public ObservableCollection<IsProduct> OddajIsProductZKomenda(string command)
        {
            return new ObservableCollection<IsProduct>(RepoIsProduct.PobierzWszystkieProduktySklepuZKomenda(command));
        }
        public bool ZmniejszQuantityIsProduct(int quantity, int idP, int idS)
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
        public bool ZwiekszQuantityIsProduct(int quantity, int idP, int idS)
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
        public ObservableCollection<Shopping> OddajZakupyKlienta(int id)
        {
            //ObservableCollection<Shopping> res = new ObservableCollection<Shopping>();
            //foreach(var item in ListOfShopping)
            //{
            //    if (item.Id_K == id)
            //        res.Add(item);
            //}
            //return res;
            return new ObservableCollection<Shopping>(RepoShopping.PobierzZakupyKlienta(id));
        }
        #endregion
    }
}
