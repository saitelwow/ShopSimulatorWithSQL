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
    using Databases.Encje;
    using Databases.Repozytoria;
    public partial class StartControl : UserControl
    {
        public StartControl()
        {
            InitializeComponent();
        }
        #region Wlasnosci
        public static readonly DependencyProperty LogUserProperty = DependencyProperty.Register(
            "LogUser", typeof(ICommand), typeof(StartControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty RegisterUserProperty = DependencyProperty.Register(
            "RegisterUser", typeof(ICommand), typeof(StartControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty LogOwnerProperty = DependencyProperty.Register(
            "LogOwner", typeof(ICommand), typeof(StartControl), new FrameworkPropertyMetadata(null)
            );
        #endregion

        #region Gettery i Settery
        public ICommand LogUser
        {
            get { return (ICommand)GetValue(LogUserProperty); }
            set { SetValue(LogUserProperty, value); }
        }
        public ICommand RegisterUser
        {
            get { return (ICommand)GetValue(RegisterUserProperty); }
            set { SetValue(RegisterUserProperty, value); }
        }
        public ICommand LogOwner
        {
            get { return (ICommand)GetValue(LogOwnerProperty); }
            set { SetValue(LogOwnerProperty, value); }
        }
        #endregion

        #region Eventy
        public static readonly RoutedEvent LogUserClickEvent =
            EventManager.RegisterRoutedEvent("OtherLogUserClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(StartControl));
        public event RoutedEventHandler LogUserClick
        {
            add { AddHandler(LogUserClickEvent, value); }
            remove { RemoveHandler(LogUserClickEvent, value); }
        }
        void RaiseLogUserClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(LogUserClickEvent);
            RaiseEvent(args);
        }
        public static readonly RoutedEvent RegisterUserClickEvent =
            EventManager.RegisterRoutedEvent("OtherRegisterUserClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(StartControl));
        public event RoutedEventHandler RegisterUserClick
        {
            add { AddHandler(RegisterUserClickEvent, value); }
            remove { RemoveHandler(RegisterUserClickEvent, value); }
        }
        void RaiseRegisterUserClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(RegisterUserClickEvent);
            RaiseEvent(args);
        }
        public static readonly RoutedEvent LogOwnerClickEvent =
            EventManager.RegisterRoutedEvent("OtherLogOwnerClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(StartControl));
        public event RoutedEventHandler LogOwnerClick
        {
            add { AddHandler(LogOwnerClickEvent, value); }
            remove { RemoveHandler(LogOwnerClickEvent, value); }
        }
        void RaiseLogOwnerClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(LogOwnerClickEvent);
            RaiseEvent(args);
        }
        #endregion
    }
}
