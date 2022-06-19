using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMplusDazy.View
{
    public partial class UserInfoControl : UserControl
    {
        public UserInfoControl()
        {
            InitializeComponent();
        }
        #region Wlasnosci
        public static readonly DependencyProperty LoginProperty = DependencyProperty.Register(
            "Login", typeof(string), typeof(UserInfoControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty PhoneProperty = DependencyProperty.Register(
            "Phone", typeof(string), typeof(UserInfoControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty MailProperty = DependencyProperty.Register(
            "Mail", typeof(string), typeof(UserInfoControl), new FrameworkPropertyMetadata(null)
            );
        #endregion

        #region GetSet
        public string Login
        {
            get { return (string)GetValue(LoginProperty); }
            set { SetValue(LoginProperty, value); }
        }
        public string Phone
        {
            get { return (string)GetValue(PhoneProperty); }
            set { SetValue(PhoneProperty, value); }
        }
        public string Mail
        {
            get { return (string)GetValue(MailProperty); }
            set { SetValue(MailProperty, value); }
        }
        #endregion

        #region Eventy

        #endregion
    }
}
