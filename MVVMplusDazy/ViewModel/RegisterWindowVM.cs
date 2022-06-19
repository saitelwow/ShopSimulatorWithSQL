using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMplusDazy.ViewModel
{
    using Model;
    using Databases.Encje;
    using Databases.Repozytoria;
    using System.Collections.ObjectModel;

    internal class RegisterWindowVM : BaseVM
    {
        #region Atrybuty
        private string isVisible = "Hidden";
        private string _login = string.Empty;
        private string _password = string.Empty;
        private string _repeatedPassword = string.Empty;
        private string _phoneNumber = string.Empty;
        private string _mailAddress = string.Empty;
        private string _canRegister = "True";
        #endregion

        #region GetSet
        public string IsVisible { get { return isVisible; } set { isVisible = value; OnPropertyChanged(nameof(IsVisible)); } }
        public string Login { get { return _login; } set { _login = value; OnPropertyChanged(nameof(Login)); } }
        public string Password { get { return _password; } set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string RepeatedPassword { get { return _repeatedPassword; } set { _repeatedPassword = value; OnPropertyChanged(nameof(RepeatedPassword)); } }
        public string PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); } }
        public string MailAddress { get { return _mailAddress; } set { _mailAddress = value; OnPropertyChanged(nameof(MailAddress)); } }
        public string CanRegister { get { return _canRegister; } set { _canRegister = value;OnPropertyChanged(nameof(CanRegister)); } }
        public ObservableCollection<User> ListOfUsers { get; set; }
        public MainModel MM { get; set; }
        #endregion

        #region VMy
        public StartWindowVM SWVM { get; set; }
        public MainVM MVM { get; set; }
        #endregion

        public RegisterWindowVM() 
        {
            MM = new MainModel();
            ListOfUsers = MM.ListOfUsers; 
        }

        #region Metody
        public void ClearAll()
        {
            Login = string.Empty;
            Password = string.Empty;
            RepeatedPassword = string.Empty;
            PhoneNumber = string.Empty; 
            MailAddress = string.Empty;
        }
        public void GoBackRegister(object sender)
        {
            ClearAll();
            CanRegister = "True";
            SWVM.IsVisible = "Visible";
            IsVisible = "Hidden";
        }
        public void Register(object sender)
        {
            User user = new User(Login, Password, PhoneNumber, MailAddress);
            if (!CheckData(user, RepeatedPassword)) 
                 return;             
            CanRegister = "False";
            if(MM.DodajUseraDoBazy(user))
            {
                ClearAll();
                MessageBox.Show("User dodany");
                return;
            }
            ClearAll();
            MessageBox.Show("Cos poszlo nie tak");
        }
        public bool CheckData(User user, string repeatedpassword)
        {
            string mailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            user.Login = user.Login.Trim(); user.PhoneNumber = user.PhoneNumber.Trim(); 
            user.MailAddress = user.MailAddress.Trim(); user.MailAddress = user.MailAddress.ToLower();
            if (user.Login == "" | user.Password == "" | repeatedpassword == "" | user.PhoneNumber == "" | user.MailAddress == "")
                { MessageBox.Show("Uzupełnij wszystkie pola"); return false; }
            if (user.Login.Length > 15) 
                { MessageBox.Show("Zły Login"); return false; }
            if (user.Password.Length > 20 || user.Password == "") 
                { MessageBox.Show("Złe hasło"); return false; }
            if ((!String.Equals(user.Password, repeatedpassword)) || (user.Password == "" & repeatedpassword == "")) 
                { MessageBox.Show("Rozne Hasla"); return false; }
            if (user.PhoneNumber.Length > 15) return false;
            if (!(Regex.Match(user.PhoneNumber, @"(?<!\w)(\(?(\+|00)?48\)?)?[ -]?\d{3}[ -]?\d{3}[ -]?\d{3}(?!\w)").Success))
                { MessageBox.Show("Zły numer"); return false; }
            if (user.MailAddress.Length > 40) return false;
            if (!(Regex.Match(user.MailAddress, mailPattern).Success)) 
                { MessageBox.Show("Zły mail"); return false; }
            return true;
        }
        #endregion

    }
}
