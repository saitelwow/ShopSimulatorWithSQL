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
    public partial class OwnerDelShopControl : UserControl
    {
        public OwnerDelShopControl()
        {
            InitializeComponent();
        }
        #region Wlasnosci
        public static readonly DependencyProperty ListOfProductsToDelProperty = DependencyProperty.Register(
            "ListOfShopsToDel", typeof(ObservableCollection<string>), typeof(OwnerDelShopControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty SelectedProductToDelProperty = DependencyProperty.Register(
            "SelectedShopToDel", typeof(string), typeof(OwnerDelShopControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty DelEnableProperty = DependencyProperty.Register(
            "DelEnable", typeof(string), typeof(OwnerDelShopControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty DelShopClProperty = DependencyProperty.Register(
            "DelShopCl", typeof(ICommand), typeof(OwnerDelShopControl), new FrameworkPropertyMetadata(null)
            );
        #endregion

        #region GetSet
        public string ListOfShopsToDel
        {
            get { return (string)GetValue(ListOfProductsToDelProperty); }
            set { SetValue(ListOfProductsToDelProperty, value); }
        }
        public string SelectedShopToDel
        {
            get { return (string)GetValue(SelectedProductToDelProperty); }
            set { SetValue(SelectedProductToDelProperty, value); }
        }
        public string DelEnable
        {
            get { return (string)GetValue(DelEnableProperty); }
            set { SetValue(DelEnableProperty, value); }
        }
        public ICommand DelShopCl
        {
            get { return (ICommand)GetValue(DelShopClProperty); }
            set { SetValue(DelShopClProperty, value); }
        }
        #endregion

        #region EventyClicki
        public static readonly RoutedEvent DelShopClickEvent =
            EventManager.RegisterRoutedEvent("OtherDelShopClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(OwnerDelShopControl));
        public event RoutedEventHandler DelShopClick
        {
            add { AddHandler(DelShopClickEvent, value); }
            remove { RemoveHandler(DelShopClickEvent, value); }
        }
        void RaiseDelShopClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(DelShopClickEvent);
            RaiseEvent(args);
        }
        #endregion
    }
}
