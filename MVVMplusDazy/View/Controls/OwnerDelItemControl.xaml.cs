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
    public partial class OwnerDelItemControl : UserControl
    {
        public OwnerDelItemControl()
        {
            InitializeComponent();
        }
        #region Wlasnosci
        public static readonly DependencyProperty ListOfProductsToDelProperty = DependencyProperty.Register(
            "ListOfProductsToDel", typeof(ObservableCollection<string>), typeof(OwnerDelItemControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty SelectedProductToDelProperty = DependencyProperty.Register(
            "SelectedProductToDel", typeof(string), typeof(OwnerDelItemControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty DelEnableProperty = DependencyProperty.Register(
            "DelEnable", typeof(string), typeof(OwnerDelItemControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty RestockEnableProperty = DependencyProperty.Register(
            "RestockEnable", typeof(string), typeof(OwnerDelItemControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty DelItemClProperty = DependencyProperty.Register(
            "DelItemCl", typeof(ICommand), typeof(OwnerDelItemControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty RestockClProperty = DependencyProperty.Register(
            "RestockCl", typeof(ICommand), typeof(OwnerDelItemControl), new FrameworkPropertyMetadata(null)
            );
        #endregion

        #region GetSet
        public ObservableCollection<string> ListOfProductsToDel
        {
            get { return (ObservableCollection<string>)GetValue(ListOfProductsToDelProperty); }
            set { SetValue(ListOfProductsToDelProperty, value); }
        }
        public string SelectedProductToDel
        {
            get { return (string)GetValue(SelectedProductToDelProperty); }
            set { SetValue(SelectedProductToDelProperty, value); }
        }
        public string DelEnable
        {
            get { return (string)GetValue(DelEnableProperty); }
            set { SetValue(DelEnableProperty, value); }
        }
        public string RestockEnable
        {
            get { return (string)GetValue(RestockEnableProperty); }
            set { SetValue(RestockEnableProperty, value); }
        }
        public ICommand DelItemCl
        {
            get { return (ICommand)GetValue(DelItemClProperty); }
            set { SetValue(DelItemClProperty, value); }
        }
        public ICommand RestockCl
        {
            get { return (ICommand)GetValue(RestockClProperty); }
            set { SetValue(RestockClProperty, value); }
        }
        #endregion

        #region Eventy Clicki
        public static readonly RoutedEvent DelItemClickEvent =
            EventManager.RegisterRoutedEvent("OtherDelItemClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(OwnerDelItemControl));
        public event RoutedEventHandler DelItemClick
        {
            add { AddHandler(DelItemClickEvent, value); }
            remove { RemoveHandler(DelItemClickEvent, value); }
        }
        void RaiseDelItemClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(DelItemClickEvent);
            RaiseEvent(args);
        }
        public static readonly RoutedEvent RestockItemClickEvent =
            EventManager.RegisterRoutedEvent("OtherRestockItemClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(OwnerDelItemControl));
        public event RoutedEventHandler RestockItemClick
        {
            add { AddHandler(RestockItemClickEvent, value); }
            remove { RemoveHandler(RestockItemClickEvent, value); }
        }
        void RaiseRestockItemClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(RestockItemClickEvent);
            RaiseEvent(args);
        }
        #endregion

        #region Eventy ListBox
        public static readonly RoutedEvent SelectedItemToDelChangedEvent =
            EventManager.RegisterRoutedEvent("OtherSelectedItemToDelChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(OwnerDelItemControl));
        public event RoutedEventHandler SelectedItemToDelChanged
        {
            add { AddHandler(SelectedItemToDelChangedEvent, value); }
            remove { RemoveHandler(SelectedItemToDelChangedEvent, value); }
        }
        void RaiseSelectedItemToDelChanged(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(SelectedItemToDelChangedEvent);
            RaiseEvent(args);
        }
        #endregion
    }
}
