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
    using Model;
    public partial class AddToMagazineControl : UserControl
    {    
        public AddToMagazineControl()
        {
            InitializeComponent();
        }
        #region Wlasnosci
        public static readonly DependencyProperty AddClProperty = DependencyProperty.Register(
            "AddCl", typeof(ICommand), typeof(AddToMagazineControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty ShopsProperty = DependencyProperty.Register(
            "Shops", typeof(ObservableCollection<Shop>), typeof(AddToMagazineControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty SelectedShopProperty = DependencyProperty.Register(
            "SelectedShop", typeof(Shop), typeof(AddToMagazineControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty ProductsProperty = DependencyProperty.Register(
            "Products", typeof(ObservableCollection<Product>), typeof(AddToMagazineControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty SelectedProductProperty = DependencyProperty.Register(
            "SelectedProduct", typeof(Product), typeof(AddToMagazineControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty QuantityTextProperty = DependencyProperty.Register(
            "QuantityText", typeof(string), typeof(AddToMagazineControl), new FrameworkPropertyMetadata(null)
            );
        #endregion

        #region GetSet
        public ICommand AddCl
        {
            get { return (ICommand)GetValue(AddClProperty); }
            set { SetValue(AddClProperty, value); }
        }
        public ObservableCollection<Shop> Shops
        {
            get { return (ObservableCollection<Shop>)GetValue(ShopsProperty); }
            set { SetValue(ShopsProperty, value); }
        }
        public Shop SelectedShop
        {
            get { return (Shop)GetValue(SelectedShopProperty); }
            set { SetValue(SelectedShopProperty, value); }
        }
        public ObservableCollection<Product> Products
        {
            get { return (ObservableCollection<Product>)GetValue(ProductsProperty); }
            set { SetValue(ProductsProperty, value); }
        }
        public Product SelectedProduct
        {
            get { return (Product)GetValue(SelectedProductProperty); }
            set { SetValue(SelectedProductProperty, value); }
        }
        public string QuantityText
        {
            get { return (string)GetValue(QuantityTextProperty); }
            set { SetValue(QuantityTextProperty, value); }
        }
        #endregion

        #region EventyClicki
        public static readonly RoutedEvent AddClickEvent =
            EventManager.RegisterRoutedEvent("OtherAddClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(AddToMagazineControl));
        public event RoutedEventHandler AddClick
        {
            add { AddHandler(AddClickEvent, value); }
            remove { RemoveHandler(AddClickEvent, value); }
        }
        void RaiseAddClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(AddClickEvent);
            RaiseEvent(args);
        }
        #endregion

        #region EventyListbox
        public static readonly RoutedEvent ShopChangedEvent =
            EventManager.RegisterRoutedEvent("OtherShopSelected", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(AddToMagazineControl));
        public event RoutedEventHandler ShopChanged
        {
            add { AddHandler(ShopChangedEvent, value); }
            remove { RemoveHandler(ShopChangedEvent, value); }
        }
        void RaiseShopChanged(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(ShopChangedEvent);
            RaiseEvent(args);
        }

        public static readonly RoutedEvent ProductChangedEvent =
            EventManager.RegisterRoutedEvent("OtherProductSelected", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(AddToMagazineControl));
        public event RoutedEventHandler ProductChanged
        {
            add { AddHandler(ProductChangedEvent, value); }
            remove { RemoveHandler(ProductChangedEvent, value); }
        }
        void RaiseProductChanged(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(ProductChangedEvent);
            RaiseEvent(args);
        }
        #endregion
    }
}
