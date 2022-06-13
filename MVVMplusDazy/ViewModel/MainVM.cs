using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMplusDazy.ViewModel
{
    using Model;
    using System.Collections.ObjectModel;
    using System.Windows;

    class MainVM : BaseVM
    {
        #region Atrybuty
        private ObservableCollection<Product> _listOfProductsInShop;
        private ObservableCollection<Product> _buyProducts;
        private ObservableCollection<Shop> _listOfShops;
        private List<User> _listOfUsers;
        private User _owner = new User();
        #endregion

        #region GetSet
        public ObservableCollection<Product> ListOfProductsInShop { get; set; }
        public ObservableCollection<Product> BuyProducts { get; set; }
        public ObservableCollection<Shop> ListOfShops { get; set; }
        public List<User> ListOfUsers { get; set; }
        public User Owner { get;}
        #endregion

        #region VMy
        public StartWindowVM SW { get; set; }
        public RegisterWindowVM RW { get; set; }
        public LogOwnerVM LO { get; set; }
        public LogUserVM LU { get; set; }
        #endregion


        public MainVM()
        {
            ListOfProductsInShop = new ObservableCollection<Product>();
            ListOfShops = new ObservableCollection<Shop>();
            ListOfUsers = new List<User>();
            RW = new RegisterWindowVM();
            SW = new StartWindowVM();
            LO = new LogOwnerVM();
            LU = new LogUserVM();

            //admin do testu, wyjebac potem
            Owner = new User(1, "admin", "admin", "123456789", "admin@admin.pl");
            ListOfUsers.Add(Owner);
            LoadFromDataBase();
            foreach (Shop sp in ListOfShops)
                foreach (Product pr in sp.ShopProducts)
                    ListOfProductsInShop.Add(pr); 
            //do kontrolek, logowanie, rejestracja
            RW.SWVM = SW;
            RW.ListOfUsers = ListOfUsers;

            SW.RWVM = RW;
            SW.LOVM = LO;
            SW.LUVM = LU;

            //do okien, kupowanie, uzupelnianie magazynu
            LO.SWVM = SW;
            LO.USR = Owner;
            LO.ListOfShops = ListOfShops;
            //LO.ListOfProducts = ListOfProductsInShop;
            LO.MVM = this;

            LU.SWVM = SW;
            LU.ListOfProductsInShop = ListOfProductsInShop;
            LU.ListOfUsers = ListOfUsers;
            LU.MVM = this;
        }

        #region Metody
        public void LoadFromDataBase() 
        {
            //selecty ze wszystkich tabelek
            //to jest do testow, wypierdolcie to potem
            //add user from user table
            ListOfUsers.Add(new User(2, "Kamil", "   ", "999999999", "kamil@wp.pl"));
            ListOfUsers.Add(new User(3, "Jan", "   ", "999999999", "jano@wp.pl"));
            ListOfUsers.Add(new User(4, "Michu", "   ", "999999999", "michu@wp.pl"));

            // add shops from shops table
            ListOfShops.Add(new Shop(1, "Ul. Polska 2", "Psia Wólka"));
            ListOfShops.Add(new Shop(2, "Ul. Ziemna 23", "Owocowo"));

            //add products to each shops from tables
            ListOfShops.ElementAt(0).ShopProducts.Add(new Product(1, 20, 15.5, "Polska", "Ogorek", "Warzywo"));
            ListOfShops.ElementAt(0).ShopProducts.Add(new Product(2, 10, 11.5, "Niemcy", "Jablko", "Owoc"));
            ListOfShops.ElementAt(0).ShopProducts.Add(new Product(3, 14, 12.5, "Hiszpania", "Papryka", "Warzywo"));
            ListOfShops.ElementAt(0).ShopProducts.Add(new Product(4, 11, 22.5, "Wlochy", "Czeresnie", "Owoc"));

            ListOfShops.ElementAt(1).ShopProducts.Add(new Product(5, 11, 15.5, "Polska", "Ogorek", "Warzywo"));
            ListOfShops.ElementAt(1).ShopProducts.Add(new Product(6, 14, 11.5, "Niemcy", "Jablko", "Owoc"));
            ListOfShops.ElementAt(1).ShopProducts.Add(new Product(7, 9, 12.5, "Hiszpania", "Papryka", "Warzywo"));
            ListOfShops.ElementAt(1).ShopProducts.Add(new Product(8, 4, 22.5, "Wlochy", "Czeresnie", "Owoc"));
        }
        #endregion

        #region ICommandy StartControl
        private ICommand _registerUserClick = null;
        public ICommand RegisterUserClick
        {
            get
            {
                if (_registerUserClick == null)
                {
                    _registerUserClick = new RelayCommand(SW.Register, arg => true);
                }
                return _registerUserClick;
            }
        }
        private ICommand _loginUserClick = null;
        public ICommand LoginUserClick
        {
            get
            {
                if (_loginUserClick == null)
                {
                    _loginUserClick = new RelayCommand(SW.LoginUser, arg => true);
                }
                return _loginUserClick;
            }
        }
        private ICommand _loginOwnerClick = null;
        public ICommand LoginOwnerClick
        {
            get
            {
                if (_loginOwnerClick == null)
                {
                    _loginOwnerClick = new RelayCommand(SW.LoginOwner, arg => true);
                }
                return _loginOwnerClick;
            }
        }
        #endregion

        #region ICommandy RegisterControl
        private ICommand _goBackRegisterClick = null;
        public ICommand GoBackRegisterClick
        {
            get
            {
                if (_goBackRegisterClick == null)
                {
                    _goBackRegisterClick = new RelayCommand(RW.GoBackRegister, arg => true);
                }
                return _goBackRegisterClick;
            }
        }

        private ICommand _registerClick = null;
        public ICommand RegisterClick
        {
            get
            {
                if (_registerClick == null)
                {
                    _registerClick = new RelayCommand(RW.Register, arg => true);
                }
                return _registerClick;
            }
        }
        #endregion

        #region ICommandy OwnerLoginControl
        private ICommand _logOwner = null;
        public ICommand LogOwner
        {
            get
            {
                if (_logOwner == null)
                {
                    _logOwner = new RelayCommand(LO.LogOwner, arg => true);
                }
                return _logOwner;
            }
        }
        private ICommand _goBackLogOwnerClick = null;
        public ICommand GoBackLogOwnerClick
        {
            get
            {
                if (_goBackLogOwnerClick == null)
                {
                    _goBackLogOwnerClick = new RelayCommand(LO.GoBackLogOwner, arg => true);
                }
                return _goBackLogOwnerClick;
            }
        }
        #endregion

        #region ICommandy UserLoginControl
        private ICommand _logUser = null;
        public ICommand LogUser
        {
            get
            {
                if (_logUser == null)
                {
                    _logUser = new RelayCommand(LU.LogUser, arg => true);
                }
                return _logUser;
            }
        }
        private ICommand _goBackLogUserClick = null;
        public ICommand GoBackLogUserClick
        {
            get
            {
                if (_goBackLogUserClick == null)
                {
                    _goBackLogUserClick = new RelayCommand(LU.GoBackLogUser, arg => true);
                }
                return _goBackLogUserClick;
            }
        }
        #endregion

        #region ICommandy GoShoppingControl
        private ICommand _addClick = null;
        public ICommand AddClick
        {
            get
            {
                if (_addClick == null)
                {
                    _addClick = new RelayCommand(LU.AddClick, arg => true);
                }
                return _addClick;
            }
        }
        private ICommand _infoClick = null;
        public ICommand InfoClick
        {
            get
            {
                if (_infoClick == null)
                {
                    _infoClick = new RelayCommand(LU.InfoClick, arg => true);
                }
                return _infoClick;
            }
        }
        private ICommand _delClick = null;
        public ICommand DelClick
        {
            get
            {
                if (_delClick == null)
                {
                    _delClick = new RelayCommand(LU.DelClick, arg => true);
                }
                return _delClick;
            }
        }
        private ICommand _buyClick = null;
        public ICommand BuyClick
        {
            get
            {
                if (_buyClick == null)
                {
                    _buyClick = new RelayCommand(LU.BuyClick, arg => true);
                }
                return _buyClick;
            }
        }
        #endregion

        #region ICommandy AddToMagazineControl
        private ICommand _addToMagazineClick = null;
        public ICommand AddToMagazineClick
        {
            get
            {
                if (_addToMagazineClick == null)
                {
                    _addToMagazineClick = new RelayCommand(LO.AddToMagazineClick, arg => true);
                }
                return _addToMagazineClick;
            }
        }
        private ICommand _selectedShopChanged = null;
        public ICommand SelectedShopChanged
        {
            get
            {
                if (_selectedShopChanged == null)
                {
                    _selectedShopChanged = new RelayCommand(LO.ReloadProducts, arg => true);
                }
                return _selectedShopChanged;
            }
        }
        #endregion
    }

}
