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
    using Databases.Encje;
    using Databases.Repozytoria;
    class LogUserVM : BaseVM
    {
        #region Atrybuty
        private string _isVisible = "Hidden";
        private string _login = string.Empty;
        private string _password = string.Empty;
        private ObservableCollection<Product> _listOfProductsInShop = new ObservableCollection<Product>();
        private ObservableCollection<Product> _listOfProductsToBuy = new ObservableCollection<Product>();
        private ObservableCollection<string> _strListOfProductsToBuy = new ObservableCollection<string>();
        private ObservableCollection<Shop> _listOfShops = new ObservableCollection<Shop>();
        private Product _selectedProductInShop = null;
        private Product _selectedProductToBuy = null;
        private string _selectedStrProductToBuy = null;
        private ObservableCollection<int> _quantityOfProduct = new ObservableCollection<int>();
        private int? _selectedQuantity;
        #endregion

        #region GetSet
        public string IsVisible { get { return _isVisible; } set { _isVisible = value; OnPropertyChanged(nameof(IsVisible)); } }
        public string Login { get { return _login; } set { _login = value; OnPropertyChanged(nameof(Login)); } }
        public string Password { get { return _password; } set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public ObservableCollection<User> ListOfUsers { get; set; }
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
        public ObservableCollection<Shop> ListOfShops
        {
            get { return _listOfShops; }
            set { _listOfShops = value; OnPropertyChanged(nameof(ListOfShops)); }
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
        public User testUser { get; set; } = new User();
        public ObservableCollection<int> QuantityOfProduct
        {
            get { return _quantityOfProduct; }
            set { _quantityOfProduct = value; OnPropertyChanged(nameof(QuantityOfProduct)); }
        }
        public int? SelectedQuantity
        {
            get { return _selectedQuantity; }
            set { _selectedQuantity = value; OnPropertyChanged(nameof(SelectedQuantity)); }
        }
        public ObservableCollection<string> StrListOfProductsToBuy
        {
            get { return _strListOfProductsToBuy; }
            set { _strListOfProductsToBuy = value; OnPropertyChanged(nameof(StrListOfProductsToBuy)); }
        }
        public string SelectedStrProductToBuy
        {
            get { return _selectedStrProductToBuy; }
            set { _selectedStrProductToBuy = value; OnPropertyChanged(nameof(SelectedStrProductToBuy)); }
        }
        #endregion

        #region VMy i Windows
        public MainVM MVM { get; set; }
        public UserWindow US { get; set; }
        public StartWindowVM SWVM { get; set; }
        #endregion

        public LogUserVM() 
        {
            //ListOfProductsToBuy = new ObservableCollection<Product>();
            
        }

        #region Metody Kontrolki
        public void ClearAll()
        {
            Login = string.Empty; Password = string.Empty;
        }
        public bool CheckInfo()
        {
            if (Login == "admin") return false;
            //ListOfUsers = new ObservableCollection<User>(RepoUser.PobierzWszystkchKlientow());
            testUser = RepoUser.PobierzKlientaPoLoginHaslo(Login, Password);
            
            if (testUser.Login == Login && testUser.Password == Password)
            {
                ActUSR = testUser;
                return true;
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
            //MessageBox.Show("Good");
            Load();
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
        private void Load()
        {
            ListOfProductsInShop = new ObservableCollection<Product>(RepoProduct.PobierzWszystkieProdukty());
            StrListOfProductsToBuy.Clear();
            SelectedStrProductToBuy = null;
            ListOfProductsToBuy.Clear();
            SelectedProductToBuy = null;
            SelectedQuantity = null;
        }
        public void LoadQuantity(object sender)
        {
            if (SelectedProductInShop == null) return;
            QuantityOfProduct.Clear();
            SelectedQuantity = null;
            string command = $"WHERE id_produktu = {SelectedProductInShop.Id}";
            List<IsProduct> temp = RepoIsProduct.PobierzWszystkieProduktySklepuZKomenda(command);
            int qua = 0;
            foreach(IsProduct ip in temp)
            {
                qua += ip.Quantity;
            }
            for (int i = 1; i <= qua; i++)
                QuantityOfProduct.Add(i);
            SelectedQuantity = QuantityOfProduct.ElementAt(0);
            //SelectedProductInShop = null;
        }
        public void AddClick(object sender)
        {
            if (SelectedProductInShop == null) return;
            if (SelectedProductInShop != null && SelectedProductToBuy != null) SelectedProductToBuy = null;

            ListOfProductsToBuy.Add(SelectedProductInShop);
            StrListOfProductsToBuy.Add(SelectedProductInShop.Name + ", " + SelectedQuantity.ToString());

            ListOfProductsInShop.Remove(SelectedProductInShop);
            SelectedProductInShop = null;
        }
        public void InfoClick(object sender)
        {
            //MessageBox.Show("InfoCl");
            if (SelectedProductInShop != null && SelectedProductToBuy != null) SelectedProductToBuy = null;
            if (SelectedProductInShop != null)
            {
                MessageBox.Show(SelectedProductInShop.GetInfo());
            }
            //if(SelectedProductToBuy != null)
            //{
            //    //MessageBox.Show(SelectedProductToBuy.GetInfo());
            //}

            SelectedProductInShop = null; SelectedProductToBuy = null;
        }
        public void DelClick(object sender)
        {           
            if (SelectedStrProductToBuy == null) return;
            if (SelectedProductInShop != null && SelectedProductToBuy != null) SelectedProductInShop = null;

            int index = StrListOfProductsToBuy.IndexOf(SelectedStrProductToBuy);
            StrListOfProductsToBuy.Remove(StrListOfProductsToBuy.ElementAt(index));

            ListOfProductsInShop.Add(ListOfProductsToBuy.ElementAt(index));
            ListOfProductsToBuy.Remove(ListOfProductsToBuy.ElementAt(index));
            
        }
        public void BuyClick(object sender)
        {
            int[] tableOfQuantity = new int[StrListOfProductsToBuy.Count];
            int i = 0;
            foreach(string str in StrListOfProductsToBuy)
            {
                tableOfQuantity[i] = Convert.ToInt32(str.Split(",").ElementAt(1));
                i += 1;
            }
            i = 0;
            string res = string.Empty;
            double overall = 0;
            foreach (Product pr in ListOfProductsToBuy)
            {
                List<IsProduct> temp = RepoIsProduct.PobierzWszystkieProduktySklepuZKomenda($"WHERE id_produktu = {pr.Id}");
                bool isGood = false;
                res += pr.Name + ": " + (pr.Price * tableOfQuantity[i]) + "\n";
                overall += (pr.Price * tableOfQuantity[i]);
                foreach (IsProduct ip in temp)
                {     
                    if (ip.Quantity >= tableOfQuantity[i])
                    {
                        ip.Quantity -= tableOfQuantity[i];
                        tableOfQuantity[i] = 0;
                        isGood = true;
                    }
                    else if(ip.Quantity < tableOfQuantity[i])
                    {
                        tableOfQuantity[i] -= ip.Quantity;
                        ip.Quantity = 0;
                    }
                    RepoIsProduct.EdytujProduktWBazieKupowanie(ip.Quantity, ip.Id_P, ip.Id_S);
                    if (isGood) break;
                }
                i += 1;
            }
            res += "Calosc: " + overall.ToString();
            MessageBox.Show(res);
            Load();
        }
        #endregion
    }
}
