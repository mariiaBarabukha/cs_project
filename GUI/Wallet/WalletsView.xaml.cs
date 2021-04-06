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

namespace GUI.Wallets
{
    /// <summary>
    /// Interaction logic for WalletsView.xaml
    /// </summary>
    public partial class WalletsView : UserControl
    {
        WalletsViewModel walletsViewModel;
        public WalletsView()
        {
            InitializeComponent();
            walletsViewModel = new WalletsViewModel();
            this.DataContext = walletsViewModel;
        }
    }
}
