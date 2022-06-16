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
    using Model;
    using System.Collections.ObjectModel;
    using Databases.Encje;
    using Databases.Repozytoria;

    public partial class GoShoppingControl : UserControl
    {
        public GoShoppingControl()
        {
            InitializeComponent();
        }
        #region Wlasnosci
        public static readonly DependencyProperty AddClProperty = DependencyProperty.Register(
            "AddCl", typeof(ICommand), typeof(GoShoppingControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty InfoClProperty = DependencyProperty.Register(
            "InfoCl", typeof(ICommand), typeof(GoShoppingControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty DelClProperty = DependencyProperty.Register(
            "DelCl", typeof(ICommand), typeof(GoShoppingControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty BuyClProperty = DependencyProperty.Register(
            "BuyCl", typeof(ICommand), typeof(GoShoppingControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty ProductsInShopProperty = DependencyProperty.Register(
            "ProductsInShop", typeof(ObservableCollection<string>), typeof(GoShoppingControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty SelectedProductInShopProperty = DependencyProperty.Register(
            "SelectedProductInShop", typeof(string), typeof(GoShoppingControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty ProductsToBuyProperty = DependencyProperty.Register(
            "ProductsToBuy", typeof(ObservableCollection<string>), typeof(GoShoppingControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty SelectedProductToBuyProperty = DependencyProperty.Register(
            "SelectedProductToBuy", typeof(string), typeof(GoShoppingControl), new FrameworkPropertyMetadata(null)
            );
        #endregion

        #region GetSet
        public ICommand AddCl
        {
            get { return (ICommand)GetValue(AddClProperty); }
            set { SetValue(AddClProperty, value); }
        }
        public ICommand InfoCl
        {
            get { return (ICommand)GetValue(InfoClProperty); }
            set { SetValue(InfoClProperty, value); }
        }
        public ICommand DelCl
        {
            get { return (ICommand)GetValue(DelClProperty); }
            set { SetValue(DelClProperty, value); }
        }
        public ICommand BuyCl
        {
            get { return (ICommand)GetValue(BuyClProperty); }
            set { SetValue(BuyClProperty, value); }
        }
        public ObservableCollection<string> ProductsInShop
        {
            get { return (ObservableCollection<string>)GetValue(ProductsInShopProperty); }
            set { SetValue(ProductsInShopProperty, value); }
        }
        public string SelectedProductInShop
        {
            get { return (string)GetValue(SelectedProductInShopProperty); }
            set { SetValue(SelectedProductInShopProperty, value); }
        }
        public ObservableCollection<string> ProductsToBuy
        {
            get { return (ObservableCollection<string>)GetValue(ProductsToBuyProperty); }
            set { SetValue(ProductsToBuyProperty, value); }
        }       
        public string SelectedProductToBuy
        {
            get { return (string)GetValue(SelectedProductToBuyProperty); }
            set { SetValue(SelectedProductToBuyProperty, value); }
        }
        #endregion


        #region EventyClicki
        public static readonly RoutedEvent AddClickEvent =
            EventManager.RegisterRoutedEvent("OtherAddClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(GoShoppingControl));
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

        public static readonly RoutedEvent InfoClickEvent =
            EventManager.RegisterRoutedEvent("OtherInfoClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(GoShoppingControl));
        public event RoutedEventHandler InfoClick
        {
            add { AddHandler(InfoClickEvent, value); }
            remove { RemoveHandler(InfoClickEvent, value); }
        }
        void RaiseInfoClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(InfoClickEvent);
            RaiseEvent(args);
        }

        public static readonly RoutedEvent DelClickEvent =
            EventManager.RegisterRoutedEvent("OtherDelClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(GoShoppingControl));
        public event RoutedEventHandler DelClick
        {
            add { AddHandler(DelClickEvent, value); }
            remove { RemoveHandler(DelClickEvent, value); }
        }
        void RaiseDelClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(DelClickEvent);
            RaiseEvent(args);
        }

        public static readonly RoutedEvent BuyClickEvent =
            EventManager.RegisterRoutedEvent("OtherBuyClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(GoShoppingControl));
        public event RoutedEventHandler BuyClick
        {
            add { AddHandler(BuyClickEvent, value); }
            remove { RemoveHandler(BuyClickEvent, value); }
        }
        void RaiseBuyClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(BuyClickEvent);
            RaiseEvent(args);
        }
        #endregion

        #region EventyListBox
        public static readonly RoutedEvent ProdutcInShopChangedEvent =
            EventManager.RegisterRoutedEvent("OtherProductInShopSelected", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(GoShoppingControl));
        public event RoutedEventHandler ProdutcInShopChanged
        {
            add { AddHandler(ProdutcInShopChangedEvent, value); }
            remove { RemoveHandler(ProdutcInShopChangedEvent, value); }
        }
        void RaiseProdutcInShopChanged(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(ProdutcInShopChangedEvent);
            RaiseEvent(args);
        }

        public static readonly RoutedEvent ProdutcToBuyChangedEvent =
            EventManager.RegisterRoutedEvent("OtherProductToBuySelected", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(GoShoppingControl));
        public event RoutedEventHandler ProdutcToBuyChanged
        {
            add { AddHandler(ProdutcToBuyChangedEvent, value); }
            remove { RemoveHandler(ProdutcToBuyChangedEvent, value); }
        }
        void RaiseProdutcToBuyChanged(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(ProdutcToBuyChangedEvent);
            RaiseEvent(args);
        }
        #endregion
    }
}
