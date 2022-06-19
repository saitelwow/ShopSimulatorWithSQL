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
    public partial class UserClickControl : UserControl
    {
        public UserClickControl()
        {
            InitializeComponent();
        }
        #region Wlasnosci
        public static readonly DependencyProperty GoToShoppingClProperty = DependencyProperty.Register(
            "GoToShoppingCl", typeof(ICommand), typeof(UserClickControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty GoToEditClProperty = DependencyProperty.Register(
            "GoToEditCl", typeof(ICommand), typeof(UserClickControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty GoToListClProperty = DependencyProperty.Register(
            "GoToListCl", typeof(ICommand), typeof(UserClickControl), new FrameworkPropertyMetadata(null)
            );
        #endregion

        #region GetSet
        public ICommand GoToShoppingCl
        {
            get { return (ICommand)GetValue(GoToShoppingClProperty); }
            set { SetValue(GoToShoppingClProperty, value); }
        }
        public ICommand GoToEditCl
        {
            get { return (ICommand)GetValue(GoToEditClProperty); }
            set { SetValue(GoToEditClProperty, value); }
        }
        public ICommand GoToListCl
        {
            get { return (ICommand)GetValue(GoToListClProperty); }
            set { SetValue(GoToListClProperty, value); }
        }
        #endregion

        #region EventyClicki
        public static readonly RoutedEvent GoToShoppingClickEvent =
            EventManager.RegisterRoutedEvent("OtherGoToShoppingClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserClickControl));
        public event RoutedEventHandler GoToShoppingClick
        {
            add { AddHandler(GoToShoppingClickEvent, value); }
            remove { RemoveHandler(GoToShoppingClickEvent, value); }
        }
        void RaiseGoToShoppingClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(GoToShoppingClickEvent);
            RaiseEvent(args);
        }

        public static readonly RoutedEvent GoToListClickEvent =
            EventManager.RegisterRoutedEvent("OtherGoToListClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserClickControl));
        public event RoutedEventHandler GoToListClick
        {
            add { AddHandler(GoToListClickEvent, value); }
            remove { RemoveHandler(GoToListClickEvent, value); }
        }
        void RaiseGoToListClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(GoToListClickEvent);
            RaiseEvent(args);
        }
        public static readonly RoutedEvent EditClickEvent =
            EventManager.RegisterRoutedEvent("OtherEditGoShoppingClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserClickControl));
        public event RoutedEventHandler EditClick
        {
            add { AddHandler(EditClickEvent, value); }
            remove { RemoveHandler(EditClickEvent, value); }
        }
        void RaiseEditClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(EditClickEvent);
            RaiseEvent(args);
        }
        #endregion
    }
}
