﻿
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

namespace GUI.Account
{
    /// <summary>
    /// Interaction logic for AccountView.xaml
    /// </summary>
   
    public partial class AccountView : UserControl
    {
        AccountViewModel accountViewModel;
        public AccountView()
        {
            InitializeComponent();
            accountViewModel = new AccountViewModel();
            this.DataContext = accountViewModel;
        }
    }
}