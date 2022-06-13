using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMplusDazy.Model
{
    public class User
    {
        #region Atrybuty
        private int _id;
        private string _login = string.Empty;
        private string _password = string.Empty;
        private string _phoneNumber = string.Empty;
        private string _mailAddress = string.Empty;
        #endregion

        #region GetSet
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }           
        #endregion

        public User() { }
        public User(int id, string login, string password, string phoneNumber, string mailAddress)
        {
            Id = id; Login = login; Password = password; PhoneNumber = phoneNumber; MailAddress = mailAddress;
        }
        public override string ToString()
        {
            return $"{Id}, {Login}, {Password}, {PhoneNumber}, {MailAddress}";
        }
    }
}
