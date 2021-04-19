using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using GUI.DataBase;
using GUI.Wallets;
using lab;
using Prism.Commands;

namespace GUI.Account
{
    public partial class AccountViewModel
    {
        Customer customer;
        WalletInfo wallet;
        private Action _goToAddWallet;
        private Action _goToSignIn;
        private Action _goToTransactions;

        public string FirstName { get { return customer.FirstName; } }
        public string LastName { get { return customer.LastName; } }
        
        //public WalletInfo currentTest()
        //{
        //    MessageBox.Show(CurrentInfo.Customer.Email);
        //    return currentTest();
        //}

        public List<lab.Wallet> Wallets { get { return customer.GetWallets(); } }

        public DelegateCommand AccountCommand { get;  }

        public DelegateCommand test { get; }

        public DelegateCommand GoToAddWalletCommand { get; }
        public DelegateCommand GoToSignIn { get; }
        public AccountViewModel(Action goToAddWallet, Action goToSignIn, Action goToTransactions)
        {
            GoToAddWalletCommand = new DelegateCommand(GoToAddWallet);
            customer = CurrentInfo.Customer;

            test = new DelegateCommand(GoToTransactions);
            
            
            _goToAddWallet = goToAddWallet;
            _goToSignIn = goToSignIn;
            _goToTransactions = goToTransactions;
            GoToSignIn = new DelegateCommand(_goToSignIn);
          
        }

        public void GoToAddWallet()
        {
            _goToAddWallet.Invoke();
        }

        public void GoToTransactions()
        {
            if (CurrentInfo.WalletInfo == null)
            {
                MessageBox.Show("Оберіть гаманець.");
            }
            else
            {
                _goToTransactions.Invoke();
                
            }
        }
       
       
    }
}
