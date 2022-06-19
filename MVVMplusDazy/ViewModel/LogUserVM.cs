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

        private string _shoppingVisible = "Visible";
        private string _transactionsVisible = "Hidden";
        private string _editVisible = "Hidden";
        private string _price = string.Empty;
        private ObservableCollection<string> _listOfTransactions = new ObservableCollection<string>();
        private string _selectedTransaction = null;
        private ObservableCollection<string> _listOfInfo = new ObservableCollection<string>();

        private string _editPassword = string.Empty;
        private string _editRepeatedPassword = string.Empty;
        private string _editPhoneNumber = string.Empty;
        private string _editMailAddress = string.Empty;
        private string _canEdit = "True";

        private string _actualLogin = string.Empty;
        private string _actualPhone = string.Empty;
        private string _actualMail = string.Empty;
        #endregion

        #region GetSet
        public string IsVisible { get { return _isVisible; } set { _isVisible = value; OnPropertyChanged(nameof(IsVisible)); } }
        public string Login { get { return _login; } set { _login = value; OnPropertyChanged(nameof(Login)); } }
        public string Password { get { return _password; } set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public ObservableCollection<User> ListOfUsers { get; set; }
        public ObservableCollection<Product> ListOfProductsInShop{ get { return _listOfProductsInShop; }set { _listOfProductsInShop = value; OnPropertyChanged(nameof(ListOfProductsInShop)); }}
        public ObservableCollection<Product> ListOfProductsToBuy {get { return _listOfProductsToBuy; }set { _listOfProductsToBuy = value; OnPropertyChanged(nameof(ListOfProductsToBuy)); }}
        public ObservableCollection<Shop> ListOfShops { get { return _listOfShops; } set { _listOfShops = value; OnPropertyChanged(nameof(ListOfShops)); } }
        public Product SelectedProductInShop {get { return _selectedProductInShop; }set { _selectedProductInShop = value; OnPropertyChanged(nameof(SelectedProductInShop)); }}
        public Product SelectedProductToBuy{ get { return _selectedProductToBuy; }set { _selectedProductToBuy = value; OnPropertyChanged(nameof(SelectedProductToBuy)); } }
        public User ActUSR { get; set; }
        public User testUser { get; set; } = new User();
        public ObservableCollection<int> QuantityOfProduct { get { return _quantityOfProduct; }set { _quantityOfProduct = value; OnPropertyChanged(nameof(QuantityOfProduct)); } }
        public int? SelectedQuantity{get { return _selectedQuantity; }set { _selectedQuantity = value; OnPropertyChanged(nameof(SelectedQuantity)); }}
        public ObservableCollection<string> StrListOfProductsToBuy {get { return _strListOfProductsToBuy; }set { _strListOfProductsToBuy = value; OnPropertyChanged(nameof(StrListOfProductsToBuy)); }}
        public string SelectedStrProductToBuy
        {
            get { return _selectedStrProductToBuy; }
            set { _selectedStrProductToBuy = value; OnPropertyChanged(nameof(SelectedStrProductToBuy)); }
        }

        public string ShoppingVisible { get { return _shoppingVisible; } set { _shoppingVisible = value; OnPropertyChanged(nameof(ShoppingVisible)); } }
        public string TransactionsVisible { get { return _transactionsVisible; } set { _transactionsVisible = value; OnPropertyChanged(nameof(TransactionsVisible)); } }
        public string EditVisible { get { return _editVisible; } set { _editVisible = value; OnPropertyChanged(nameof(EditVisible)); } }
        public string Price { get { return _price; } set { _price = value; OnPropertyChanged(nameof(Price)); } }
        public ObservableCollection<string> ListOfTransactions { get { return _listOfTransactions; } set { _listOfTransactions = value; OnPropertyChanged(nameof(ListOfTransactions)); } }
        public string SelectedTransaction { get { return _selectedTransaction; } set { _selectedTransaction = value; OnPropertyChanged(nameof(SelectedTransaction)); } }
        public ObservableCollection<string> ListOfInfo { get { return _listOfInfo; } set { _listOfInfo = value; OnPropertyChanged(nameof(ListOfInfo)); } }
        public string EditPassword { get { return _editPassword; } set { _editPassword = value; OnPropertyChanged(nameof(EditPassword)); } }
        public string EditRepeatedPassword { get { return _editRepeatedPassword; } set { _editRepeatedPassword = value; OnPropertyChanged(nameof(EditRepeatedPassword)); } }
        public string EditPhoneNumber { get { return _editPhoneNumber; } set { _editPhoneNumber = value; OnPropertyChanged(nameof(EditPhoneNumber)); } }
        public string EditMailAddress { get { return _editMailAddress; } set { _editMailAddress = value; OnPropertyChanged(nameof(EditMailAddress)); } }
        public string CanEdit { get { return _canEdit; } set { _canEdit = value; OnPropertyChanged(nameof(CanEdit)); } }

        public string ActualLogin { get { return _actualLogin; } set { _actualLogin = value; OnPropertyChanged(nameof(ActualLogin)); } }
        public string ActualPhone { get { return _actualPhone; } set { _actualPhone = value; OnPropertyChanged(nameof(ActualPhone)); } }
        public string ActualMail { get { return _actualMail; } set { _actualMail = value; OnPropertyChanged(nameof(ActualMail)); } }


        #endregion

        #region VMy i Windows
        public MainVM MVM { get; set; }
        public UserWindow US { get; set; } 
        public StartWindowVM SWVM { get; set; }
        public RegisterWindowVM RWVM { get; set; } 
        public MainModel MM { get; set; } = new MainModel();
        #endregion

        public LogUserVM() { }

        #region Metody Kontrolki
        public void ClearAll()
        {
            Login = string.Empty; Password = string.Empty;
        }
        public bool CheckInfo()
        {
            if (Login == "admin") return false;
            testUser = MM.OddajUseraPoLoginHaslo(Login, Password);
            if(testUser == null) return false;
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
            Load();
            ShoppingVisible = "Visible";
            EditVisible = "Hidden";
            CanEdit = "True";
            TransactionsVisible = "Hidden";
            ActualLogin = ActUSR.Login;
            ActualPhone = ActUSR.PhoneNumber;
            ActualMail = ActUSR.MailAddress;
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
            if(US != null)
                US.Close(); 
        }
        #endregion

        #region MetodyOkna - otwieranie zakladek
        public void GoToList(object sender)
        {
            ListOfInfo.Clear();
            TransactionsVisible = "Visible";
            ShoppingVisible = "Hidden";
            EditVisible = "Hidden";
            CanEdit = "True";
            LoadAllTransatcions(true);
        }
        public void GoToShopping(object sender)
        {
            ListOfInfo.Clear();
            //MessageBox.Show("ShowShopping"); 
            ShoppingVisible = "Visible";
            TransactionsVisible = "Hidden";
            EditVisible = "Hidden";
            CanEdit = "True";
            Load();
        }
        public void GoToEditClick(object sender)
        {
            ListOfInfo.Clear();
            //MessageBox.Show("EditClick");
            ShoppingVisible = "Hidden";
            TransactionsVisible = "Hidden";
            EditVisible = "Visible";
            CanEdit = "True";
        }
        #endregion

        #region MetodyKupowania
        private void Load()
        {
            ListOfProductsInShop = MM.OddajProduktyWiecejNizZero();
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
            ObservableCollection<IsProduct> temp = MM.OddajIsProductPoIdProduktu(SelectedProductInShop.Id);
            int qua = 0;
            foreach(IsProduct ip in temp)
            {
                qua += ip.Quantity;
            }
            for (int i = 1; i <= qua; i++)
                QuantityOfProduct.Add(i);
            SelectedQuantity = QuantityOfProduct.ElementAt(0);
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
            if (SelectedProductInShop != null && SelectedProductToBuy != null) SelectedProductToBuy = null;
            if (SelectedProductInShop != null)
            {
                MessageBox.Show(SelectedProductInShop.GetInfo());
            }

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
            int lastTransaction = MM.OddajIdOstatniejTransakcji();

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
                //ObservableCollection<IsProduct> temp = MM.OddajIsProductZKomenda($"WHERE id_produktu = {pr.Id}");
                ObservableCollection<IsProduct> temp = MM.OddajIsProductPoIdProduktu(pr.Id);

                bool isGood = false;
                res += pr.Name + ": " + (pr.Price * tableOfQuantity[i]) + "\n";
                overall += (pr.Price * tableOfQuantity[i]);
                if(!MM.DodajDoBazyTransakcji(pr.Id, ActUSR.Id, tableOfQuantity[i], (lastTransaction + 1)))
                {
                    MessageBox.Show("Blad"); return;
                }
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
                    MM.ZmniejszQuantityIsProduct(ip.Quantity, ip.Id_P, ip.Id_S);                   
                    if (isGood) break;
                }
                i += 1;
            }
            res += "Calosc: " + overall.ToString();
            MessageBox.Show(res);
            Load();
        }
        #endregion

        #region MetodyTransakcji
        public void LoadAllTransatcions(object sender)
        {
            ListOfTransactions.Clear();
            ObservableCollection<Shopping> temp = MM.OddajUnikalneZakupyKlienta(ActUSR.Id);
            for(int i = 0; i < temp.Count; i++)
            {
                ListOfTransactions.Add($"Transakcja nr: {temp[i].Id_T}");
            }
        }
        public void LoadTransactionInfo(object sender)
        {
            if (SelectedTransaction == null) return;
            ListOfInfo.Clear();
            Price = string.Empty;
            int transacitonId = Convert.ToInt32(SelectedTransaction.Split(' ')[2]);      
            ObservableCollection<Shopping> temp = MM.OddajZakupyPoIdTransakcji(transacitonId, ActUSR.Id);
            ObservableCollection<Product> tempProducts = MM.ListOfProducts;
            double res = 0;
            foreach(Shopping sh in temp)
            {
                foreach(Product pr in tempProducts)
                {
                    if (pr.Id == sh.Id_P)
                    {
                        ListOfInfo.Add($"{pr.Name}: {sh.Quantity}");
                        res += (pr.Price * sh.Quantity);
                    }
                }
            }
            res = Math.Round(res, 5);
            Price = res.ToString();
        }

        #endregion

        #region MetodyEdycji
        public void EditClick(object sender)
        {
            //MessageBox.Show("EditClick");
            User user = new User(ActUSR.Login, EditPassword, EditPhoneNumber, EditMailAddress);
            if(!RWVM.CheckData(user, EditRepeatedPassword))
            {
                MessageBox.Show($"{ActUSR.Login}, {EditPassword}, {EditRepeatedPassword},{EditPhoneNumber}, {EditMailAddress}");
                return;
            }
            if(MM.EdytujUseraWBazie(user, ActUSR.Id))
            {
                EditClearAll();
                CanEdit = "False";
                ActUSR = user;
                ActualLogin = ActUSR.Login;
                ActualPhone = ActUSR.PhoneNumber;
                ActualMail = ActUSR.MailAddress;
                //US.DataContext = this;
                return;
            }
            EditClearAll();
        }
        public void EditClearAll()
        {
            EditPassword = string.Empty;
            EditRepeatedPassword = string.Empty;
            EditPhoneNumber = string.Empty;
            EditMailAddress = string.Empty;
        }
        #endregion
    }
}
