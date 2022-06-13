using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
    public partial class RegisterControl : UserControl
    {
        // login haslo powtorz telefon mail registerClick
        public RegisterControl()
        {
            InitializeComponent();
        }
        #region Wlasnosci
        public static readonly DependencyProperty GoBackProperty = DependencyProperty.Register(
            "GoBack", typeof(ICommand), typeof(RegisterControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty RegisterProperty = DependencyProperty.Register(
            "Register", typeof(ICommand), typeof(RegisterControl), new FrameworkPropertyMetadata(null)
            );

        public static readonly DependencyProperty LoginProperty = DependencyProperty.Register(
            "Login", typeof(string), typeof(RegisterControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
            "Password", typeof(string), typeof(RegisterControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty RepeatedPasswordProperty = DependencyProperty.Register(
            "RepeatedPassword", typeof(string), typeof(RegisterControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty PhoneNumberProperty = DependencyProperty.Register(
            "PhoneNumber", typeof(string), typeof(RegisterControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty MailAddressProperty = DependencyProperty.Register(
            "MailAddress", typeof(string), typeof(RegisterControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty CanRegisterProperty = DependencyProperty.Register(
            "CanRegister", typeof(string), typeof(RegisterControl), new FrameworkPropertyMetadata(null)
            );
        #endregion

        #region Gettery i Settery
        public ICommand GoBack
        {
            get { return (ICommand)GetValue(GoBackProperty); }
            set { SetValue(GoBackProperty, value); }
        }
        public ICommand Register
        {
            get { return (ICommand)GetValue(RegisterProperty); }
            set { SetValue(RegisterProperty, value); }
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
        public string CanRegister
        {
            get { return (string)GetValue(CanRegisterProperty); }
            set { SetValue(CanRegisterProperty, value); }
        }
        #endregion

        #region Eventy
        public static readonly RoutedEvent GoBackClickEvent =
            EventManager.RegisterRoutedEvent("OtherGoBackClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RegisterControl));
        public event RoutedEventHandler GoBackClick
        {
            add { AddHandler(GoBackClickEvent, value); }
            remove { RemoveHandler(GoBackClickEvent, value); }
        }
        void RaiseGoBackClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(GoBackClickEvent);
            RaiseEvent(args);
        }
        
        public static readonly RoutedEvent RegisterClickEvent =
            EventManager.RegisterRoutedEvent("OtherRegisterClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RegisterControl));
        public event RoutedEventHandler RegisterClick
        {
            add { AddHandler(RegisterClickEvent, value); }
            remove { RemoveHandler(RegisterClickEvent, value); }
        }
        void RaiseRegisterClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(RegisterClickEvent);
            RaiseEvent(args);
        }  
        #endregion

    }
}
