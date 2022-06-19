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
    public partial class GoToListControl : UserControl
    {
        public GoToListControl()
        {
            InitializeComponent();
        }
        #region Wlasnosci
        public static readonly DependencyProperty PriceProperty = DependencyProperty.Register(
            "Price", typeof(string), typeof(GoToListControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty ListOfTransactionsProperty = DependencyProperty.Register(
            "ListOfTransactions", typeof(ObservableCollection<string>), typeof(GoToListControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty SelectedTransactionProperty = DependencyProperty.Register(
            "SelectedTransaction", typeof(string), typeof(GoToListControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty ListOfProductsProperty = DependencyProperty.Register(
            "ListOfProducts", typeof(ObservableCollection<string>), typeof(GoToListControl), new FrameworkPropertyMetadata(null)
            );
        #endregion

        #region GetSet
        public string Price
        {
            get { return (string)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }
        public ObservableCollection<string> ListOfTransactions
        {
            get { return (ObservableCollection<string>)GetValue(ListOfTransactionsProperty); }
            set { SetValue(ListOfTransactionsProperty, value); }
        }
        public string SelectedTransaction
        {
            get { return (string)GetValue(SelectedTransactionProperty); }
            set { SetValue(SelectedTransactionProperty, value); }
        }
        public ObservableCollection<string> ListOfProducts
        {
            get { return (ObservableCollection<string>)GetValue(ListOfProductsProperty); }
            set { SetValue(ListOfProductsProperty, value); }
        }
        #endregion


        #region EventyLB
        public static readonly RoutedEvent SelectedTransactionChangedEvent =
            EventManager.RegisterRoutedEvent("OtherSelectedTransactionChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(GoToListControl));
        public event RoutedEventHandler SelectedTransactionChanged
        {
            add { AddHandler(SelectedTransactionChangedEvent, value); }
            remove { RemoveHandler(SelectedTransactionChangedEvent, value); }
        }
        void RaiseSelectedTransactionChanged(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(SelectedTransactionChangedEvent);
            RaiseEvent(args);
        }
        
        #endregion
    }
}
