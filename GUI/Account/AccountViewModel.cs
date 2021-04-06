using System;
using System.Collections.Generic;
using System.Linq;
using GUI.Services;
using lab;
using Prism.Commands;

namespace GUI.Account
{
    public partial class AccountViewModel
    {
        Customer customer;

        public string FirstName { get { return customer.FirstName; } }
        public string LastName { get { return customer.LastName; } }

        public List<Wallet> Wallets { get { return customer.GetWallets(); } }

        public DelegateCommand AccountCommand { get;  }


        public AccountViewModel()
        {
            UserForTest c = new UserForTest();
            customer = c.Customer;
            customer.AddWallet("w1", 100, "the first wallet", "USD");
           // _wallets.Add();
        }

        private async void ShowName()
        {
            
        }
    }
}
