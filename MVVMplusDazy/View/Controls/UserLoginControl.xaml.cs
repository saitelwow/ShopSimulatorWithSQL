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
    public partial class UserLoginControl : UserControl
    {
        public UserLoginControl()
        {
            InitializeComponent();
        }
        #region Wlasnosci
        public static readonly DependencyProperty GoBackProperty = DependencyProperty.Register(
            "GoBack", typeof(ICommand), typeof(UserLoginControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty LogProperty = DependencyProperty.Register(
            "Log", typeof(ICommand), typeof(UserLoginControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty LoginProperty = DependencyProperty.Register(
            "Login", typeof(string), typeof(UserLoginControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
            "Password", typeof(string), typeof(UserLoginControl), new FrameworkPropertyMetadata(null)
            );
        #endregion

        #region GetSet
        public ICommand GoBack
        {
            get { return (ICommand)GetValue(GoBackProperty); }
            set { SetValue(GoBackProperty, value); }
        }
        public ICommand Log
        {
            get { return (ICommand)GetValue(LogProperty); }
            set { SetValue(LogProperty, value); }
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
        #endregion

        #region Eventy
        public static readonly RoutedEvent GoBackClickEvent =
            EventManager.RegisterRoutedEvent("OtherGoBackClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserLoginControl));
        public event RoutedEventHandler GoBackClick
        {
            add { AddHandler(GoBackClickEvent, value); }
            remove { RemoveHandler(GoBackClickEvent, value); }
        }
        public static readonly RoutedEvent LogClickEvent =
            EventManager.RegisterRoutedEvent("OtherLogClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserLoginControl));
        public event RoutedEventHandler LogClick
        {
            add { AddHandler(LogClickEvent, value); }
            remove { RemoveHandler(LogClickEvent, value); }
        }
        void RaiseLogClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(LogClickEvent);
            RaiseEvent(args);
        }
        #endregion
    }
}
