using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMplusDazy.ViewModel
{
    using Model;
    using Databases.Encje;
    using Databases.Repozytoria;
    using System.Collections.ObjectModel;
    using System.Windows;

    class MainVM : BaseVM
    {
        #region Atrybuty
        private ObservableCollection<string> _listOfProductsInShop;
        private ObservableCollection<Product> _buyProducts;
        private ObservableCollection<Shop> _listOfShops;
        private List<User> _listOfUsers;
        //private User _owner = new User();
        #endregion

        #region GetSet
        public ObservableCollection<string> ListOfProductsInShop { get; set; }
        public ObservableCollection<Product> BuyProducts { get; set; }
        public ObservableCollection<Shop> ListOfShops { get; set; }
        public ObservableCollection<User> ListOfUsers { get; set; }
        #endregion

        #region VMy
        public StartWindowVM SW { get; set; }
        public RegisterWindowVM RW { get; set; }
        public LogOwnerVM LO { get; set; }
        public LogUserVM LU { get; set; }
        public MainModel MM { get; set; }
        #endregion


        public MainVM()
        {
            MainModel MM = new MainModel();
            SW = new StartWindowVM();
            RW = new RegisterWindowVM();          
            LO = new LogOwnerVM();
            LU = new LogUserVM();

            RW.SWVM = SW;
            RW.MM = MM;

            SW.RWVM = RW;
            SW.LOVM = LO;
            SW.LUVM = LU;

            LO.SWVM = SW;
            LO.MVM = this;

            LU.SWVM = SW;
            LU.MVM = this;
        }

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
        private ICommand _selectedProductChanged = null;
        public ICommand SelectedProductChanged
        {
            get
            {
                if (_selectedProductChanged == null)
                {
                    _selectedProductChanged = new RelayCommand(LU.LoadQuantity, arg => true);
                }
                return _selectedProductChanged;
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
                    _selectedShopChanged = new RelayCommand(LO.ChangeShop, arg => true);
                }
                return _selectedShopChanged;
            }
        }
        #endregion
    }

}
