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
    public partial class OwnerAddShopControl : UserControl
    {
        public OwnerAddShopControl()
        {
            InitializeComponent();
        }
        #region Wlasnosci
        public static readonly DependencyProperty AddClProperty = DependencyProperty.Register(
            "AddCl", typeof(ICommand), typeof(OwnerAddShopControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty CityProperty = DependencyProperty.Register(
            "City", typeof(string), typeof(OwnerAddShopControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty CityAddressProperty = DependencyProperty.Register(
            "CityAddress", typeof(string), typeof(OwnerAddShopControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty CanAddProperty = DependencyProperty.Register(
            "CanAdd", typeof(string), typeof(OwnerAddShopControl), new FrameworkPropertyMetadata(null)
            );
        #endregion

        #region GetSet
        public ICommand AddCl
        {
            get { return (ICommand)GetValue(AddClProperty); }
            set { SetValue(AddClProperty, value); }
        }
        public string City
        {
            get { return (string)GetValue(CityProperty); }
            set { SetValue(CityProperty, value); }
        }
        public string CityAddress
        {
            get { return (string)GetValue(CityAddressProperty); }
            set { SetValue(CityAddressProperty, value); }
        }
        public string CanAdd
        {
            get { return (string)GetValue(CanAddProperty); }
            set { SetValue(CanAddProperty, value); }
        }
        #endregion

        #region EventyClicki
        public static readonly RoutedEvent AddShopClickEvent =
            EventManager.RegisterRoutedEvent("OtherAddShopClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(OwnerAddShopControl));
        public event RoutedEventHandler AddClickShop
        {
            add { AddHandler(AddShopClickEvent, value); }
            remove { RemoveHandler(AddShopClickEvent, value); }
        }
        void RaiseAddClickShop(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(AddShopClickEvent);
            RaiseEvent(args);
        }
        #endregion
    }
}
