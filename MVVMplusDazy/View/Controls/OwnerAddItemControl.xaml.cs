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
    public partial class OwnerAddItemControl : UserControl
    {
        public OwnerAddItemControl()
        {
            InitializeComponent();
        }
        #region Wlasnosci
        public static readonly DependencyProperty AddClProperty = DependencyProperty.Register(
            "AddCl", typeof(ICommand), typeof(OwnerAddItemControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty NameOfProperty = DependencyProperty.Register(
            "NameOf", typeof(string), typeof(OwnerAddItemControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty PriceProperty = DependencyProperty.Register(
            "Price", typeof(string), typeof(OwnerAddItemControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty CountryFromProperty = DependencyProperty.Register(
            "CountryFrom", typeof(string), typeof(OwnerAddItemControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty TypeProperty = DependencyProperty.Register(
            "Type", typeof(string), typeof(OwnerAddItemControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty CanAddProperty = DependencyProperty.Register(
            "CanAdd", typeof(string), typeof(OwnerAddItemControl), new FrameworkPropertyMetadata(null)
            );
        #endregion

        #region GetSet
        public ICommand AddCl
        {
            get { return (ICommand)GetValue(AddClProperty); }
            set { SetValue(AddClProperty, value); }
        }
        public string NameOf
        {
            get { return (string)GetValue(NameOfProperty); }
            set { SetValue(NameOfProperty, value); }
        }
        public string Price
        {
            get { return (string)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }
        public string CountryFrom
        {
            get { return (string)GetValue(CountryFromProperty); }
            set { SetValue(CountryFromProperty, value); }
        }
        public string Type
        {
            get { return (string)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }
        public string CanAdd
        {
            get { return (string)GetValue(CanAddProperty); }
            set { SetValue(CanAddProperty, value); }
        }
        #endregion

        #region EventyClicki
        public static readonly RoutedEvent AddClickEvent =
            EventManager.RegisterRoutedEvent("OtherAddItemClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(OwnerAddItemControl));
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
    }
}
