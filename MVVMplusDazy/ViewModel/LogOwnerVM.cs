﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMplusDazy.ViewModel
{
    using Model;
    using System.Collections.ObjectModel;
    using View;
    using Databases.Encje;
    using Databases.Repozytoria;
    class LogOwnerVM : BaseVM
    {
        #region Atrybuty
        private string isVisible = "Hidden";
        private string _login = string.Empty;
        private string _password = string.Empty;
        private ObservableCollection<Shop> _listOfShops;
        private Shop _selectedShop = null;
        private ObservableCollection<Product> _listOfProducts;
        private Product _selectedProduct = null;
        private string _quantity;
        private string _canAdd = "True";
        #endregion

        #region GetSet
        public string Quantity { get { return _quantity; } set { _quantity = value; OnPropertyChanged(nameof(Quantity)); } }
        public string IsVisible { get { return isVisible; } set { isVisible = value; OnPropertyChanged(nameof(IsVisible)); } }
        public string Login { get { return _login; } set { _login = value; OnPropertyChanged(nameof(Login)); } }
        public string Password { get { return _password; } set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public ObservableCollection<Product> ListOfProducts {
            get { return _listOfProducts; }
            set { _listOfProducts = value; OnPropertyChanged(nameof(ListOfProducts)); }
        }
        public ObservableCollection<Shop> ListOfShops {
            get { return _listOfShops; }
            set { _listOfShops = value; OnPropertyChanged(nameof(ListOfShops)); }
        }
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; OnPropertyChanged(nameof(SelectedProduct)); }
        }
        public Shop SelectedShop
        {
            get { return _selectedShop; }
            set { _selectedShop = value; OnPropertyChanged(nameof(SelectedShop)); }
        }
        public User USR { get; set; } = new User();
        public int ActualShopId { get; set; }
        public int ActualProductId { get; set; }
        public string CanAdd
        {
            get { return _canAdd; }
            set { _canAdd = value; OnPropertyChanged(nameof(CanAdd)); }
        }
        #endregion

        #region VMy i Windows
        public MainVM MVM { get; set; }
        public OwnerWindow OW { get; set; }
        public StartWindowVM SWVM { get; set; }
        
        #endregion


        public LogOwnerVM() { }

        #region Metody Kontrolki
        void ClearAll()
        {
            Login = string.Empty;
            Password = string.Empty;
        }
        public bool CheckInfo()
        {
            USR = RepoUser.PobierzKlientaPoID(1);
            if (USR.Login == this.Login && USR.Password == this.Password)
                return true;
            return false;
        }
        public void LogOwner(object sender)
        {
            if (!CheckInfo())
            {
                ClearAll();
                return;
            }
            Load();
            OW = new OwnerWindow();
            OW.DataContext = this;
            OW.Show();
            ClearAll();
        }
        public void GoBackLogOwner(object sender)
        {
            ClearAll();
            SWVM.IsVisible = "Visible";
            IsVisible = "Hidden";
        }
        #endregion

        #region Metody Okna
        public void Load()
        {
            ListOfShops = new ObservableCollection<Shop>(RepoShop.PobierzWszystkieSklepy());
            ListOfProducts = new ObservableCollection<Product>(RepoProduct.PobierzWszystkieProdukty());
            //ListOfShops = RepoShop.PobierzWszystkieSklepy();
            //ListOfProducts = new ObservableCollection<Product>(RepoIsProduct.PobierzWszystkieProduktySklepu());
        }
        public void AddToMagazineClick(object sender)
        {
            if (!(int.TryParse(Quantity, out int value)))
            {
                MessageBox.Show("Wpisz liczbę");
                return;
            }               
            if (Convert.ToInt32(Quantity) <= 0) return;
            if (SelectedProduct == null) return;
            ActualProductId = (int)SelectedProduct.Id;
            if (RepoIsProduct.EdytujProduktWBazie(Convert.ToInt32(Quantity), ActualProductId, ActualShopId));
            {
                MessageBox.Show("Udalo sie");
            }

            Quantity = string.Empty;
            CanAdd = "False";
            //ReloadProducts(true);         //reload listy po uzupelnieniu
            //do smth
        }
        public void ChangeShop(object sender)
        {
            if(SelectedShop == null) return;          
            ActualShopId = SelectedShop.Id;            
            List<IsProduct> temp = new List<IsProduct>();
            temp = RepoIsProduct.PobierzProduktySklepuZID(ActualShopId);
            CanAdd = "True";
            //MessageBox.Show(temp.ElementAt(1).Quantity.ToString());
            //MessageBox.Show("ReloadProducts");
            //ListOfProducts = SelectedShop.ShopProducts;
            //MessageBox.Show(SelectedShop.Id.ToString());

            //CHANGE jest_produkt SET ilosc = {wartosc} WHERE id_sklepu = selectedshop.id and id_produktu = selectedproduct.td

            //SelectedShop = null;
        }
        #endregion
    }
}
