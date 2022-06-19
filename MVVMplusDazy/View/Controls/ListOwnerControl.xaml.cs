using MVVMplusDazy.Databases.Encje;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ListOwnerControl : UserControl
    {
        public ListOwnerControl()
        {
            InitializeComponent();
        }

        #region Wlasnosci
        public static readonly DependencyProperty UsersProperty = DependencyProperty.Register(
            "Users", typeof(ObservableCollection<string>), typeof(ListOwnerControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty SelectedUserProperty = DependencyProperty.Register(
            "SelectedUser", typeof(string), typeof(ListOwnerControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty OrdersProperty = DependencyProperty.Register(
            "Orders", typeof(ObservableCollection<string>), typeof(ListOwnerControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty SelectedOrderProperty = DependencyProperty.Register(
            "SelectedOrder", typeof(string), typeof(ListOwnerControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty OrderDetailsProperty = DependencyProperty.Register(
            "OrderDetails", typeof(ObservableCollection<string>), typeof(ListOwnerControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty SelectedOrderDetailsProperty = DependencyProperty.Register(
            "SelectedOrderDetails", typeof(string), typeof(ListOwnerControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty PriceProperty = DependencyProperty.Register(
            "Price", typeof(string), typeof(ListOwnerControl), new FrameworkPropertyMetadata(null)
            );
        #endregion

        #region GetSet
        public ObservableCollection<string> Users
        {
            get { return (ObservableCollection<string>)GetValue(UsersProperty); }
            set { SetValue(UsersProperty, value); }
        }
        public string SelectedUser
        {
            get { return (string)GetValue(SelectedUserProperty); }
            set { SetValue(SelectedUserProperty, value); }
        }
        public ObservableCollection<string> Orders
        {
            get { return (ObservableCollection<string>)GetValue(OrdersProperty); }
            set { SetValue(OrdersProperty, value); }
        }
        public string SelectedOrder
        {
            get { return (string)GetValue(SelectedOrderProperty); }
            set { SetValue(SelectedOrderProperty, value); }
        }
        public ObservableCollection<string> OrderDetails
        {
            get { return (ObservableCollection<string>)GetValue(OrderDetailsProperty); }
            set { SetValue(OrderDetailsProperty, value); }
        }
        public string SelectedOrderDetails
        {
            get { return (string)GetValue(SelectedOrderDetailsProperty); }
            set { SetValue(SelectedOrderDetailsProperty, value); }
        }
        public string Price
        {
            get { return (string)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }
        #endregion

        #region Eventy Listbox
        public static readonly RoutedEvent UserChangedEvent =
            EventManager.RegisterRoutedEvent("OtherSelectedUserChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ListOwnerControl));
        public event RoutedEventHandler UserChanged
        {
            add { AddHandler(UserChangedEvent, value); }
            remove { RemoveHandler(UserChangedEvent, value); }
        }
        void RaiseUserChanged(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(UserChangedEvent);
            RaiseEvent(args);
        }

        public static readonly RoutedEvent OrderChangedEvent =
            EventManager.RegisterRoutedEvent("OtherSelectedOrderChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ListOwnerControl));
        public event RoutedEventHandler OrderChanged
        {
            add { AddHandler(OrderChangedEvent, value); }
            remove { RemoveHandler(OrderChangedEvent, value); }
        }
        void RaiseOrderChanged(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(OrderChangedEvent);
            RaiseEvent(args);
        }
        #endregion
    }
}
