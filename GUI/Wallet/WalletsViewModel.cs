﻿using GUI.Navigation;
using GUI.Services;
using lab;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUI.Wallets
{
    class WalletsViewModel : BindableBase, INavigatable<WalletNavigatableTypes>, INotifyPropertyChanged
    {
        WalletInfo _currentWallet;
        public ObservableCollection<WalletInfo> Wallets { get; set; }
        public WalletInfo CurrentWallet {
            get
            {
                return _currentWallet;
            }
            set
            {
                _currentWallet = value;
                RaisePropertyChanged();
            }
        }
        public Customer Customer { get => customer; set => customer = value; }

        public WalletNavigatableTypes Type
        {
            get
            {
                return WalletNavigatableTypes.Wallets;
            }
        }

        private Customer customer;

        public DelegateCommand RemoveWalletCommand { get; }
        public WalletsViewModel()
        {
            //_service = new WalletService();
            UserForTest user = new UserForTest();
            customer = user.Customer;
            customer.AddWallet("w1", 100, "first", "USD");
            customer.AddWallet("w2", 110, "Second", "USD");
            Wallets = new ObservableCollection<WalletInfo>();
            RemoveWalletCommand = new DelegateCommand(Remove);
            foreach (var wallet in customer.GetWallets())
            {
                Wallets.Add(new WalletInfo(wallet));
            }
        }

        public void Remove()
        {
            Wallets.Remove(CurrentWallet);
        }

        public void ClearSensitiveData()
        {
            throw new NotImplementedException();
        }
    }
}