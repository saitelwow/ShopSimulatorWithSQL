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
    public partial class OwnerClickControl : UserControl
    {
        public OwnerClickControl()
        {
            InitializeComponent();
        }
        #region Wlasnosci
        public static readonly DependencyProperty GoToMagazProperty = DependencyProperty.Register(
            "GoToMagazCl", typeof(ICommand), typeof(OwnerClickControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty GoToListClProperty = DependencyProperty.Register(
            "GoToListCl", typeof(ICommand), typeof(OwnerClickControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty GoToAddItemClProperty = DependencyProperty.Register(
            "GoToAddItemCl", typeof(ICommand), typeof(OwnerClickControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty GoToDelItemClProperty = DependencyProperty.Register(
            "GoToDelItemCl", typeof(ICommand), typeof(OwnerClickControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty GoToAddShopClProperty = DependencyProperty.Register(
            "GoToAddShopCl", typeof(ICommand), typeof(OwnerClickControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty GoToDelShopClProperty = DependencyProperty.Register(
            "GoToDelShopCl", typeof(ICommand), typeof(OwnerClickControl), new FrameworkPropertyMetadata(null)
            );
        #endregion

        #region GetSet
        public ICommand GoToMagazCl
        {
            get { return (ICommand)GetValue(GoToMagazProperty); }
            set { SetValue(GoToMagazProperty, value); }
        }
        public ICommand GoToListCl
        {
            get { return (ICommand)GetValue(GoToListClProperty); }
            set { SetValue(GoToListClProperty, value); }
        }
        public ICommand GoToAddItemCl
        {
            get { return (ICommand)GetValue(GoToAddItemClProperty); }
            set { SetValue(GoToAddItemClProperty, value); }
        }
        public ICommand GoToDelItemCl
        {
            get { return (ICommand)GetValue(GoToDelItemClProperty); }
            set { SetValue(GoToDelItemClProperty, value); }
        }
        public ICommand GoToAddShopCl
        {
            get { return (ICommand)GetValue(GoToAddShopClProperty); }
            set { SetValue(GoToAddShopClProperty, value); }
        }
        public ICommand GoToDelShopCl
        {
            get { return (ICommand)GetValue(GoToDelShopClProperty); }
            set { SetValue(GoToDelShopClProperty, value); }
        }
        #endregion

        #region EventyClicki
        public static readonly RoutedEvent GoToMagazClickEvent =
            EventManager.RegisterRoutedEvent("OtherGoToMagazClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(OwnerClickControl));
        public event RoutedEventHandler GoToMagazClick
        {
            add { AddHandler(GoToMagazClickEvent, value); }
            remove { RemoveHandler(GoToMagazClickEvent, value); }
        }
        void RaiseGoToMagazClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(GoToMagazClickEvent);
            RaiseEvent(args);
        }
        public static readonly RoutedEvent GoToListClickEvent =
            EventManager.RegisterRoutedEvent("OtherGoToListClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(OwnerClickControl));
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

        public static readonly RoutedEvent GoToAddItemClickEvent =
            EventManager.RegisterRoutedEvent("OtherGoToAddItemClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(OwnerClickControl));
        public event RoutedEventHandler GoToAddItemClick
        {
            add { AddHandler(GoToAddItemClickEvent, value); }
            remove { RemoveHandler(GoToAddItemClickEvent, value); }
        }
        void RaiseGoToAddItemClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(GoToAddItemClickEvent);
            RaiseEvent(args);
        }
        public static readonly RoutedEvent GoToDelItemClickEvent =
            EventManager.RegisterRoutedEvent("OtherGoToDelItemClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(OwnerClickControl));
        public event RoutedEventHandler GoToDelItemClick
        {
            add { AddHandler(GoToDelItemClickEvent, value); }
            remove { RemoveHandler(GoToDelItemClickEvent, value); }
        }
        void RaiseGoToDelItemClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(GoToDelItemClickEvent);
            RaiseEvent(args);
        }

        public static readonly RoutedEvent GoToAddShopClickEvent =
            EventManager.RegisterRoutedEvent("OtherGoToAddShopClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(OwnerClickControl));
        public event RoutedEventHandler GoToAddShopClick
        {
            add { AddHandler(GoToAddShopClickEvent, value); }
            remove { RemoveHandler(GoToAddShopClickEvent, value); }
        }
        void RaiseGoToAddShopClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(GoToAddShopClickEvent);
            RaiseEvent(args);
        }
        public static readonly RoutedEvent GoToDelShopClickEvent =
            EventManager.RegisterRoutedEvent("OtherGoToDelShopClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(OwnerClickControl));
        public event RoutedEventHandler GoToDelShopClick
        {
            add { AddHandler(GoToDelShopClickEvent, value); }
            remove { RemoveHandler(GoToDelShopClickEvent, value); }
        }
        void RaiseGoToDelShopClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(GoToDelShopClickEvent);
            RaiseEvent(args);
        }
        #endregion
    }
}
