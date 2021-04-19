﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GUI.DataBase;
using GUI.Wallets;
using Prism.Commands;
using Prism.Mvvm;

namespace GUI.Transactions
{
    class TransactionsViewModel : BindableBase
    {
        TransactionInfo _currentTransaction;
        private Action _goToAccount;
        private Action _goToAddTransactions;
        private string prev_d = "";
        private string prev_c = "";
        private DateTime prev_date;
        private double prev_s = 0;

        public ObservableCollection<TransactionInfo> Transactions { get; set; }


        public TransactionInfo CurrentTransaction
        {
            get
            {
                CurrentInfo.TransactionInfo = _currentTransaction;
                return _currentTransaction;
            }
            set
            {
                _currentTransaction = value;

                if (_currentTransaction != null)
                {
                    prev_d = _currentTransaction.Description;
                    prev_date = CurrentTransaction.Date;
                    prev_c = CurrentTransaction.Currency;
                    prev_s = _currentTransaction.Sum;
                }

                else
                {
                    prev_d = "";
                }
                RaisePropertyChanged();
            }

        }

       

        public DelegateCommand GoToAccountCommand { get; }
        public DelegateCommand GoToAddTransactionsCommand { get; }
        public DelegateCommand RemoveTransactionCommand { get; }
        public DelegateCommand SubmitTransactionCommand { get; }
        public TransactionsViewModel(Action goToAccount, Action goToAddTransactions)
        {
            Transactions = new ObservableCollection<TransactionInfo>();
            _goToAddTransactions = goToAddTransactions;
            _goToAccount = goToAccount;
            GoToAccountCommand = new DelegateCommand(GoToAccount);
            GoToAddTransactionsCommand = new DelegateCommand(GoToAddTransactions);
            RemoveTransactionCommand = new DelegateCommand(Remove);
            SubmitTransactionCommand = new DelegateCommand(Submit);

           
            foreach (var transaction in CurrentInfo.Customer
                .GetWalletByName(CurrentInfo.Wallet.Name).GetTransactions())
            {
                Transactions.Add(new TransactionInfo(transaction));
            }


        }

        public async void Remove()
        {
            if (CurrentTransaction != null)
            {

                TransactionsHandler handler = new TransactionsHandler();
               // WalletsHandler handler = new WalletsHandler();
                handler.Filename = @"../../../DataBase/Transaction/transactions.json";
                await handler.Remove(_currentTransaction.Transaction.Guid);

                CurrentInfo.Wallet.RemoveTransaction(_currentTransaction.Transaction);
                Transactions.Remove(_currentTransaction);
                //Wallets.RemoveTr(CurrentWallet);

                //CurrentWallet = null;
                CurrentTransaction = null;

            }
           

        }

        public async void Submit()
        {

            //if (CurrentWallet != null)
            //{
            //    if (WalletAlreadyExists())
            //    {
            //        MessageBox.Show($"Wallet with name {CurrentWallet.Name} already exists!");
            //        CurrentWallet.Name = prev_n;
            //    }
            //    else
            //    {
            //        WalletsHandler handler = new WalletsHandler();
            //        handler.Filename = @"../../../DataBase/Wallet/Wallets.json";
            //        var n = CurrentInfo.Customer.GetWalletByName(CurrentWallet.Name);
            //        await handler.Change(n, prev_n);
            //    }


            //}

        }
        public void GoToAccount()
        {
            _goToAccount.Invoke();
        }

        public void GoToAddTransactions()
        {
            _goToAddTransactions.Invoke();
        }

    }
}
