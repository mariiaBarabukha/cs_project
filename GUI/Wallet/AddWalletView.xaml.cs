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

namespace GUI.Wallet
{
    /// <summary>
    /// Interaction logic for AddWalletPage.xaml
    /// </summary>
    public partial class AddWalletView : UserControl
    {
        AddWalletViewModel _view;
        public AddWalletView(Action goToAccount)
        {
            InitializeComponent();
            _view = new AddWalletViewModel(goToAccount);
            this.DataContext = _view;
        }
    }
}
