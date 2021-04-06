using System;
using System.Collections.Generic;
using System.Linq;
using GUI.DataBase;
using GUI.Services;
using lab;
using Prism.Commands;

namespace GUI.Account
{
    public partial class AccountViewModel
    {
        Customer customer;
        private Action _goToAddWallet;

        public string FirstName { get { return customer.FirstName; } }
        public string LastName { get { return customer.LastName; } }

        public List<lab.Wallet> Wallets { get { return customer.GetWallets(); } }

        public DelegateCommand AccountCommand { get;  }

        public DelegateCommand GoToAddWalletCommand { get; }
        public AccountViewModel(Action goToAddWallet)
        {
            GoToAddWalletCommand = new DelegateCommand(GoToAddWallet);
            //UserForTest c = new UserForTest();
            customer = CurrentInfo.Customer;
            //customer.AddWallet("w1", 100, "the first wallet", "USD");
            // _wallets.Add();
            _goToAddWallet = goToAddWallet;
        }

        public void GoToAddWallet()
        {
            _goToAddWallet.Invoke();
        }
    }
}
