using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMplusDazy.ViewModel
{
    using View;
    using Model;
    using System.Windows;
    using System.Collections.ObjectModel;

    class LogUserVM : BaseVM
    {
        #region Atrybuty
        private string _isVisible = "Hidden";
        private string _login = string.Empty;
        private string _password = string.Empty;
        private ObservableCollection<Product> _listOfProductsInShop;
        private ObservableCollection<Product> _listOfProductsToBuy;
        private Product _selectedProductInShop = null;
        private Product _selectedProductToBuy = null;
        #endregion

        #region GetSet
        public string IsVisible { get { return _isVisible; } set { _isVisible = value; OnPropertyChanged(nameof(IsVisible)); } }
        public string Login { get { return _login; } set { _login = value; OnPropertyChanged(nameof(Login)); } }
        public string Password { get { return _password; } set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public List<User> ListOfUsers { get; set; }
        public ObservableCollection<Product> ListOfProductsInShop
        {
            get { return _listOfProductsInShop; }
            set { _listOfProductsInShop = value; OnPropertyChanged(nameof(ListOfProductsInShop)); }
        }
        public ObservableCollection<Product> ListOfProductsToBuy
        {
            get { return _listOfProductsToBuy; }
            set { _listOfProductsToBuy = value; OnPropertyChanged(nameof(ListOfProductsToBuy)); }
        }
        public Product SelectedProductInShop
        {
            get { return _selectedProductInShop; }
            set { _selectedProductInShop = value; OnPropertyChanged(nameof(SelectedProductInShop)); }
        }
        public Product SelectedProductToBuy
        {
            get { return _selectedProductToBuy; }
            set { _selectedProductToBuy = value; OnPropertyChanged(nameof(SelectedProductToBuy)); }
        }
        public User ActUSR { get; set; }
        #endregion

        #region VMy i Windows
        public MainVM MVM { get; set; }
        public UserWindow US { get; set; }
        public StartWindowVM SWVM { get; set; }
        #endregion

        public LogUserVM() 
        { 
            ListOfProductsToBuy = new ObservableCollection<Product>();
        }

        #region Metody Kontrolki
        public void ClearAll()
        {
            Login = string.Empty; Password = string.Empty;
        }
        public bool CheckInfo()
        {
            foreach (User usr in ListOfUsers)
            {
                if (usr.Login == Login && usr.Password == Password)
                {
                    ActUSR = usr;
                    return true;
                }
            }
            return false;
        }
        public void LogUser(object sender)
        {
            if (!CheckInfo())
            {
                ClearAll();
                return;
            }
            US = new UserWindow();
            US.DataContext = this;
            US.Show();
            ClearAll();
        }
        public void GoBackLogUser(object sender)
        {
            ClearAll();
            SWVM.IsVisible = "Visible";
            IsVisible = "Hidden";
        }
        #endregion

        #region Metody Okna
        public void AddClick(object sender)
        {
            if (SelectedProductInShop == null) return;
            if (SelectedProductInShop != null && SelectedProductToBuy != null)
            {
                SelectedProductToBuy = null;
            }
            ListOfProductsToBuy.Add(SelectedProductInShop);
            ListOfProductsInShop.Remove(SelectedProductInShop);

            SelectedProductInShop = null; SelectedProductToBuy = null;
        }
        public void InfoClick(object sender)
        {
            if (SelectedProductInShop != null && SelectedProductToBuy != null) SelectedProductToBuy = null;
            if (SelectedProductInShop != null)
            {
                MessageBox.Show(SelectedProductInShop.GetInfo());
            }
            if(SelectedProductToBuy != null)
            {
                MessageBox.Show(SelectedProductToBuy.GetInfo());
            }

            SelectedProductInShop = null; SelectedProductToBuy = null;
        }
        public void DelClick(object sender)
        {
            if(SelectedProductToBuy == null) return;
            if (SelectedProductInShop != null && SelectedProductToBuy != null)
            {
                SelectedProductInShop = null;
            }
            ListOfProductsInShop.Add(SelectedProductToBuy);
            ListOfProductsToBuy.Remove(SelectedProductToBuy);

            SelectedProductInShop = null; SelectedProductToBuy = null;
        }
        public void BuyClick(object sender)
        {
            //MessageBox.Show(ListOfProductsToBuy.Count.ToString());
            foreach(Product pr in ListOfProductsToBuy.ToList())
            {
                if(pr.Quantity > 0)
                    pr.Quantity -= 1;

                ListOfProductsInShop.Add(pr);
                ListOfProductsToBuy.Remove(pr);
            }


            SelectedProductInShop = null; SelectedProductToBuy = null;
        }
        #endregion
    }
}
