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
    public partial class EditUserControl : UserControl
    {
        public EditUserControl()
        {
            InitializeComponent();
        }
        #region Wlasnosci
        public static readonly DependencyProperty EditProperty = DependencyProperty.Register(
            "EditCl", typeof(ICommand), typeof(EditUserControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty LoginProperty = DependencyProperty.Register(
            "Login", typeof(string), typeof(EditUserControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
            "Password", typeof(string), typeof(EditUserControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty RepeatedPasswordProperty = DependencyProperty.Register(
            "RepeatedPassword", typeof(string), typeof(EditUserControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty PhoneNumberProperty = DependencyProperty.Register(
            "PhoneNumber", typeof(string), typeof(EditUserControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty MailAddressProperty = DependencyProperty.Register(
            "MailAddress", typeof(string), typeof(EditUserControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty CanEditProperty = DependencyProperty.Register(
            "CanEdit", typeof(string), typeof(EditUserControl), new FrameworkPropertyMetadata(null)
            );
        #endregion

        #region GetSet

        public ICommand EditCl
        {
            get { return (ICommand)GetValue(EditProperty); }
            set { SetValue(EditProperty, value); }
        }
        public string Login
        {
            get { return (string)GetValue(LoginProperty); }
            set { SetValue(LoginProperty, value); }
        }
        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
        public string RepeatedPassword
        {
            get { return (string)GetValue(RepeatedPasswordProperty); }
            set { SetValue(RepeatedPasswordProperty, value); }
        }
        public string PhoneNumber
        {
            get { return (string)GetValue(PhoneNumberProperty); }
            set { SetValue(PhoneNumberProperty, value); }
        }
        public string MailAddress
        {
            get { return (string)GetValue(MailAddressProperty); }
            set { SetValue(MailAddressProperty, value); }
        }
        public string CanEdit
        {
            get { return (string)GetValue(CanEditProperty); }
            set { SetValue(CanEditProperty, value); }
        }
        #endregion

        #region EventyClicki



        public static readonly RoutedEvent EditClickEvent =
            EventManager.RegisterRoutedEvent("OtherEditClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(EditUserControl));
        public event RoutedEventHandler EditClick
        {
            add { AddHandler(EditClickEvent, value); }
            remove { RemoveHandler(EditClickEvent, value); }
        }
        void RaiseEditClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(EditClickEvent);
            RaiseEvent(args);
        }
        #endregion
    }
}
