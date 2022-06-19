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
    using System.Globalization;
    using System.Threading;

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
        private ObservableCollection<string> _listOfNamesAndQuantities = new ObservableCollection<string>();
        private string _selecNameAndQua = string.Empty;

        private string _actualLogin = string.Empty;
        private string _actualPhone = string.Empty;
        private string _actualMail = string.Empty;

        private string _magazineVisible = "Visible";
        private string _listVisible = "Hidden";
        private string _addItemVisible = "Hidden";
        private string _delItemVisible = "Hidden";
        private string _addShopVisible = "Hidden";
        private string _delShopVisible = "Hidden";

        private ObservableCollection<string> _listOfUsers = new ObservableCollection<string>();
        private string _selectedUser = string.Empty;
        private ObservableCollection<string> _listOfOrders = new ObservableCollection<string>();
        private string _selectedOrder = string.Empty;
        private ObservableCollection<string> _listOfDetails = new ObservableCollection<string>();
        private string _selectedDetails = string.Empty;
        private string _price = string.Empty;

        private string _addNameOf = string.Empty;
        private string _addPrice = string.Empty;
        private string _addCountryFrom = string.Empty;
        private string _addType = string.Empty;
        private string _canAddItem = "True";
        #endregion

        #region GetSet
        public string Quantity { get { return _quantity; } set { _quantity = value; OnPropertyChanged(nameof(Quantity)); } }
        public string IsVisible { get { return isVisible; } set { isVisible = value; OnPropertyChanged(nameof(IsVisible)); } }
        public string Login { get { return _login; } set { _login = value; OnPropertyChanged(nameof(Login)); } }
        public string Password { get { return _password; } set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public ObservableCollection<Product> ListOfProducts { get { return _listOfProducts; } set { _listOfProducts = value; OnPropertyChanged(nameof(ListOfProducts)); } }
        public ObservableCollection<Shop> ListOfShops { get { return _listOfShops; } set { _listOfShops = value; OnPropertyChanged(nameof(ListOfShops)); } }
        public Product SelectedProduct { get { return _selectedProduct; } set { _selectedProduct = value; OnPropertyChanged(nameof(SelectedProduct)); } }
        public Shop SelectedShop { get { return _selectedShop; } set { _selectedShop = value; OnPropertyChanged(nameof(SelectedShop)); } }
        public User USR { get; set; } = new User();
        public int ActualShopId { get; set; }
        public int ActualProductId { get; set; }
        public string CanAdd { get { return _canAdd; } set { _canAdd = value; OnPropertyChanged(nameof(CanAdd)); } }
        public ObservableCollection<string> ListOfNamesAndQuantities { get { return _listOfNamesAndQuantities; } set { _listOfNamesAndQuantities = value; OnPropertyChanged(nameof(ListOfNamesAndQuantities)); } }
        public string SelecNameAndQua { get { return _selecNameAndQua; } set { _selecNameAndQua = value; OnPropertyChanged(nameof(SelecNameAndQua)); } }
        public string ActualLogin { get { return _actualLogin; } set { _actualLogin = value; OnPropertyChanged(nameof(ActualLogin)); } }
        public string ActualPhone { get { return _actualPhone; } set { _actualPhone = value; OnPropertyChanged(nameof(ActualPhone)); } }
        public string ActualMail { get { return _actualMail; } set { _actualMail = value; OnPropertyChanged(nameof(ActualMail)); } }

        public string MagazineVisible { get { return _magazineVisible; } set { _magazineVisible = value; OnPropertyChanged(nameof(MagazineVisible)); } }
        public string ListVisible { get { return _listVisible; } set { _listVisible = value; OnPropertyChanged(nameof(ListVisible)); } }
        public string AddItemVisible { get { return _addItemVisible; } set { _addItemVisible = value; OnPropertyChanged(nameof(AddItemVisible)); } }
        public string DelItemVisible { get { return _delItemVisible; } set { _delItemVisible = value; OnPropertyChanged(nameof(DelItemVisible)); } }
        public string AddShopVisible { get { return _addShopVisible; } set { _addShopVisible = value; OnPropertyChanged(nameof(AddShopVisible)); } }
        public string DelShopVisible { get { return _delShopVisible; } set { _delShopVisible = value; OnPropertyChanged(nameof(DelShopVisible)); } }

        public ObservableCollection<string> ListOfUsers { get { return _listOfUsers; } set { _listOfUsers = value; OnPropertyChanged(nameof(ListOfUsers)); } }
        public string SelectedUser { get { return _selectedUser; } set { _selectedUser = value; OnPropertyChanged(nameof(SelectedUser)); } }
        public ObservableCollection<string> ListOfOrders { get { return _listOfOrders; } set { _listOfOrders = value; OnPropertyChanged(nameof(ListOfOrders)); } }
        public string SelectedOrder { get { return _selectedOrder; } set { _selectedOrder = value; OnPropertyChanged(nameof(SelectedOrder)); } }
        public ObservableCollection<string> ListOfDetails { get { return _listOfDetails; } set { _listOfDetails = value; OnPropertyChanged(nameof(ListOfDetails)); } }
        public string SelectedDetails { get { return _selectedDetails; } set { _selectedDetails = value; OnPropertyChanged(nameof(SelectedDetails)); } }
        public string Price { get { return _price; } set { _price = value; OnPropertyChanged(nameof(Price)); } }

        public string AddNameOf { get { return _addNameOf; } set { _addNameOf = value; OnPropertyChanged(nameof(AddNameOf)); } }
        public string AddPrice { get { return _addPrice; } set { _addPrice = value; OnPropertyChanged(nameof(AddPrice)); } }
        public string AddCountryFrom { get { return _addCountryFrom; } set { _addCountryFrom = value; OnPropertyChanged(nameof(AddCountryFrom)); } }
        public string AddType { get { return _addType; } set { _addType = value; OnPropertyChanged(nameof(AddType)); } }
        public string CanAddItem { get { return _canAddItem; } set { _canAddItem = value; OnPropertyChanged(nameof(CanAddItem)); } }
        #endregion

        #region VMy i Windows
        public MainVM MVM { get; set; }
        public OwnerWindow OW { get; set; }
        public StartWindowVM SWVM { get; set; }
        public MainModel MM { get; set; } = new MainModel();
        #endregion


        public LogOwnerVM() 
        {
            ListOfShops = new ObservableCollection<Shop>(MM.ListOfShops);
            ListOfProducts = new ObservableCollection<Product>(MM.ListOfProducts);
            SelectedShop = ListOfShops.ElementAt(0);
        }

        #region Metody Kontrolki
        void ClearAll()
        {
            Login = string.Empty;
            Password = string.Empty;
        }
        public bool CheckInfo()
        {
            USR = MM.OddajUseraPoId(1);
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
            ActualLogin = USR.Login;
            ActualMail = USR.MailAddress;
            ActualPhone = USR.PhoneNumber;
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
            if(OW != null)
                OW.Close();
        }
        #endregion

        #region MetodyOkna - otwieranie zakladek
        public void GoToListClick(object sender)
        {
            ListVisible = "Visible";
            MagazineVisible = "Hidden";
            AddItemVisible = "Hidden";
            DelItemVisible = "Hidden";
            AddShopVisible = "Hidden";
            DelShopVisible = "Hidden";
            LoadListOfUsers();
        }
        public void GoToMagazineClick(object sender)
        {
            ListVisible = "Hidden";
            MagazineVisible = "Visible";
            AddItemVisible = "Hidden";
            DelItemVisible = "Hidden";
            AddShopVisible = "Hidden";
            DelShopVisible = "Hidden";
            LoadShops();
            Load();
        }
        public void GoToAddItemClick(object sender)
        {
            ListVisible = "Hidden";
            MagazineVisible = "Hidden";
            AddItemVisible = "Visible";
            DelItemVisible = "Hidden";
            AddShopVisible = "Hidden";
            DelShopVisible = "Hidden";
            ClearAddData();
            CanAddItem = "True";
        }
        public void GoToDelItemClick(object sender)
        {
            return;
            ListVisible = "Hidden";
            MagazineVisible = "Hidden";
            AddItemVisible = "Hidden";
            DelItemVisible = "Visible";
            AddShopVisible = "Hidden";
            DelShopVisible = "Hidden";
        }
        public void GoToDelShopClick(object sender)
        {
            return;
            ListVisible = "Hidden";
            MagazineVisible = "Hidden";
            AddItemVisible = "Hidden";
            DelItemVisible = "Hidden";
            AddShopVisible = "Hidden";
            DelShopVisible = "Visible";
        }
        public void GoToAddShopClick(object sender)
        {
            return;
            ListVisible = "Hidden";
            MagazineVisible = "Hidden";
            AddItemVisible = "Hidden";
            DelItemVisible = "Hidden";
            AddShopVisible = "Visible";
            DelShopVisible = "Hidden";
        }
        #endregion

        #region Metody OknaUzupelniania
        public void LoadShops()
        {
            ListOfShops.Clear();
            ListOfShops = new ObservableCollection<Shop>(MM.ListOfShops);
            SelectedShop = ListOfShops.ElementAt(0);
        }
        public void Load()
        {
            if (SelectedShop == null) return;
            ListOfNamesAndQuantities.Clear();
            ObservableCollection<IsProduct> temp = MM.OddajIsProductPoIdSklepu(SelectedShop.Id);
            int i = 0;
            foreach (IsProduct ip in temp)
            {
                ListOfNamesAndQuantities.Add($"{ListOfProducts.ElementAt(i)}, {ip.Quantity}");
                i += 1;
            }
        }
        public void AddToMagazineClick(object sender)
        {
            if (!(int.TryParse(Quantity, out int value)))
            {
                MessageBox.Show("Wpisz liczbę");
                return;
            }               
            if (Convert.ToInt32(Quantity) <= 0) return;
            if (SelecNameAndQua == null) return;
            ActualProductId = ListOfNamesAndQuantities.IndexOf(SelecNameAndQua) + 1;
            ActualShopId = SelectedShop.Id;
            
            if(MM.ZwiekszQuantityIsProduct(Convert.ToInt32(Quantity), ActualProductId, ActualShopId)) ;
            {
                MessageBox.Show("Udalo sie");
            }

            Quantity = string.Empty;
            CanAdd = "False";
            Load();
        }
        public void ChangeShop(object sender)
        {
            if(SelectedShop == null) return;          
            CanAdd = "True";
            Load();
        }
        public void ChangeItem(object sender)
        {
            if (SelecNameAndQua == null) return;
            CanAdd = "True";
        }
        #endregion

        #region Metody OknaLista
        public void LoadListOfUsers()
        {
            ListOfUsers.Clear(); SelectedUser = null;
            ListOfOrders.Clear(); SelectedOrder = null;
            ListOfDetails.Clear(); SelectedDetails = null;
            Price = string.Empty;
            foreach(User usr in MM.ListOfUsers)
            {
                if (usr.Id == 1) continue;
                ListOfUsers.Add(usr.Login);
            }
        }
        public void LoadOrdersOfUser(object sender)
        {
            if (SelectedUser == null) return;
            ListOfOrders.Clear(); SelectedOrder = null;
            ListOfDetails.Clear(); SelectedDetails = null;
            Price = string.Empty;
            User tempUser = MM.OddajUseraPoLoginie(SelectedUser);
            ObservableCollection<Shopping> temp = MM.OddajUnikalneZakupyKlienta(tempUser.Id);
            for (int i = 0; i < temp.Count; i++)
            {
                ListOfOrders.Add($"Transakcja nr: {temp[i].Id_T}");
            }
        }
        public void LoadOrderDetails(object sender)
        {
            if(SelectedOrder == null) return;
            ListOfDetails.Clear(); SelectedDetails = null;
            Price = string.Empty;
            User tempUser = MM.OddajUseraPoLoginie(SelectedUser);
            int transacitonId = Convert.ToInt32(SelectedOrder.Split(' ')[2]);
            ObservableCollection<Shopping> temp = MM.OddajZakupyPoIdTransakcji(transacitonId, tempUser.Id);
            ObservableCollection<Product> tempProducts = MM.ListOfProducts;
            double res = 0;
            foreach (Shopping sh in temp)
            {
                foreach (Product pr in tempProducts)
                {
                    if (pr.Id == sh.Id_P)
                    {
                        ListOfDetails.Add($"{pr.Name}: {sh.Quantity}");
                        res += (pr.Price * sh.Quantity);
                    }
                }
            }
            res = Math.Round(res, 5);
            Price = res.ToString();
        }
        #endregion

        #region Metody OknaDodawaniaItem
        public void AddItemClick(object sender)
        {
            if (!CheckAddData()) return;


            CanAddItem = "False";
        }

        public void ClearAddData()
        {
            AddNameOf = String.Empty; AddPrice = String.Empty; AddCountryFrom = string.Empty; AddType = String.Empty;
        }
        public bool CheckAddData()
        {
            AddNameOf = AddNameOf.Trim(); AddPrice = AddPrice.Trim(); AddCountryFrom = AddCountryFrom.Trim(); AddType = AddType.Trim();
            if(AddNameOf == "" | AddPrice == "" | AddCountryFrom == "" | AddType == "") { MessageBox.Show("Uzupelnij pola"); return false; }
            if (AddNameOf.Length > 40) return false;
            if (AddCountryFrom.Length > 40) return false;
            if (AddType.Length > 40) return false;
            if(Convert.ToInt32(AddPrice) <= 0 ) { MessageBox.Show("Cena musi byc dodatnia"); return false; }
            return true;
        }
        #endregion

        #region Metody OknaUsuwaniaItem

        #endregion

        #region Metody OknaDodawaniaSklep

        #endregion

        #region Metody OknaUsuwaniaShop

        #endregion

        
    }
}
