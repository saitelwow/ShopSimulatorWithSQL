using System;
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
        #endregion

        #region GetSet
        public string Quantity { get { return _quantity; } set { _quantity = value; OnPropertyChanged(nameof(Quantity)); } }
        public string IsVisible { get { return isVisible; } set { isVisible = value; OnPropertyChanged(nameof(IsVisible)); } }
        public string Login { get { return _login; } set { _login = value; OnPropertyChanged(nameof(Login)); } }
        public string Password { get { return _password; } set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public User USR { get; set; }
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
        public void AddToMagazineClick(object sender)
        {
            if (!(int.TryParse(Quantity, out int value)))
            {
                MessageBox.Show("Wpisz liczbę");
                return;
            }               
            if (Convert.ToInt64(Quantity) <= 0) return;
            if (SelectedProduct == null) return;

            //ReloadProducts(true);         //reload listy po uzupelnieniu
            //do smth
        }
        public void ReloadProducts(object sender)
        {
            if(SelectedShop == null) return; 
            //MessageBox.Show("ReloadProducts");
            //ListOfProducts = SelectedShop.ShopProducts;

            //SelectedShop = null;
        }
        #endregion
    }
}
