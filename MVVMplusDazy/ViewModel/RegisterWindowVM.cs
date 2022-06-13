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
        public List<User> ListOfUsers { get; set; }
        #endregion

        #region VMy
        public StartWindowVM SWVM { get; set; }
        public MainVM MVM { get; set; }
        #endregion

        public RegisterWindowVM() { }

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
            if (!CheckData()) 
                 return;             
            CanRegister = "False";
            int lastId = ListOfUsers.ElementAt(ListOfUsers.Count - 1).Id;
            ListOfUsers.Add(new User(lastId + 1, Login, Password, PhoneNumber, MailAddress));
            //insert do tabelki uzytkownika
            MessageBox.Show(ListOfUsers.ElementAt(ListOfUsers.Count - 1).ToString());
        }
        public bool CheckData()
        {
            string mailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            Login = Login.Trim(); PhoneNumber = PhoneNumber.Trim(); MailAddress = MailAddress.Trim(); MailAddress = MailAddress.ToLower();
            if (Login == "" | Password == "" | RepeatedPassword == "" | PhoneNumber == "" | MailAddress == "")
                { MessageBox.Show("Uzupełnij wszystkie pola"); return false; }
            if (Login.Length > 10) 
                { MessageBox.Show("Zły Login"); return false; }
            if (Password.Length > 10 || Password == "") 
                { MessageBox.Show("Złe hasło"); return false; }
            if ((!String.Equals(Password, RepeatedPassword)) || (Password == "" & RepeatedPassword == "")) 
                { MessageBox.Show("Rozne Hasla"); return false; }
            if (!(Regex.Match(PhoneNumber, @"(?<!\w)(\(?(\+|00)?48\)?)?[ -]?\d{3}[ -]?\d{3}[ -]?\d{3}(?!\w)").Success))
                { MessageBox.Show("Zły numer"); return false; }
            if (!(Regex.Match(MailAddress, mailPattern).Success)) 
                { MessageBox.Show("Zły mail"); return false; }
            return true;
        }
        #endregion

    }
}
