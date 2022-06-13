﻿using System;
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

namespace MVVMplusDazy.Components
{
    
    public partial class BindablePasswordBox : UserControl
    {
        public BindablePasswordBox()
        {
            InitializeComponent();
        }
        #region Wlasnosci
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(BindablePasswordBox),
                new PropertyMetadata(string.Empty, PasswordPropertyChanged));
        #endregion

        #region GetSet
        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
        #endregion

        #region Metody
        private static void PasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is BindablePasswordBox passwordBox)
            {
                passwordBox.UpdatePassword();
            }
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = passwordBox.Password;
        }
        private void UpdatePassword()
        {
            passwordBox.Password = Password;
        }
        #endregion

    }
}