﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GUI.DataBase;
using GUI.WalletDB;
using GUI.Wallets;
using lab;
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

        public DelegateCommand ShowFromCommand { get; }

        public DelegateCommand ShowInfoCommand { get; }
        public string From 
        {
            get
            {
                return from.ToString();
            }

            set
            {
                from = Convert.ToInt16(value);
                RaisePropertyChanged(nameof(from));
            }
        }

        int from = 0;

        public TransactionsViewModel(Action goToAccount, Action goToAddTransactions)
        {
            Transactions = new ObservableCollection<TransactionInfo>();
            _goToAddTransactions = goToAddTransactions;
            _goToAccount = goToAccount;
            GoToAccountCommand = new DelegateCommand(GoToAccount);
            GoToAddTransactionsCommand = new DelegateCommand(GoToAddTransactions);
            RemoveTransactionCommand = new DelegateCommand(Remove);
            SubmitTransactionCommand = new DelegateCommand(Submit);
            ShowInfoCommand = new DelegateCommand(ShowInfo);
            ShowFromCommand = new DelegateCommand(showTr);

            int i = 0;
            //Transactions = new();
            if (CurrentInfo.Customer.GetWalletByName(CurrentInfo.Wallet.Name) == null)
            {
                MessageBox.Show("Оберіть гаманець");
            }
            else
            {

                foreach (var transaction in CurrentInfo.Customer
                    .GetWalletByName(CurrentInfo.Wallet.Name).GetTransactions())
                {
                    i++;
                    if (i + 1 < Convert.ToInt16(From))
                    {
                        continue;
                    }

                    if (i + 1 > Convert.ToInt16(From) + 10)
                    {
                        break;
                    }

                    Transactions.Add(new TransactionInfo(transaction));
                }

            }
        }


        public void showTr()
        {
            int i = 0;
            
            foreach (var transaction in CurrentInfo.Customer
                .GetWalletByName(CurrentInfo.Wallet.Name).GetTransactions())
            {
                
                if (i + 1 < Convert.ToInt16(From))
                {
                    Transactions.RemoveAt(0);
                }
                if (i + 1 >= Convert.ToInt16(From + 10))
                {
                    Transactions.RemoveAt(Transactions.Count-1);
                }
                i++;

            }
        }

        public async void Remove()
        {
            if (CurrentTransaction != null)
            {

                TransactionsHandler handler = new TransactionsHandler();
                handler.Filename = @"../../../DataBase/Transaction/transactions.json";
                await handler.Remove(_currentTransaction.Transaction.Guid);

                CurrentInfo.Wallet.RemoveTransaction(_currentTransaction.Transaction);
                Transactions.Remove(_currentTransaction);

                CurrentTransaction = null;

            }

        }

        public void ShowInfo()
        {
            if (CurrentInfo.Wallet != null)
            {
                MessageBox.Show(CurrentInfo.Wallet.ShowWalletInformation());
            }
        }

        public async void Submit()
        {
            TransactionsHandler handler = new TransactionsHandler();
            handler.Filename = @"../../../DataBase/Transaction/transactions.json";
            await handler.Change(_currentTransaction.Transaction);
            

        }
        public void GoToAccount()
        {
            SubmitW();
            _goToAccount.Invoke();
        }

        public async void SubmitW()
        {

            WalletsHandler handler = new WalletsHandler();
            handler.Filename = @"../../../DataBase/Wallet/Wallets.json";
            var n = CurrentInfo.Customer.GetWalletByName(CurrentInfo.Wallet.Name);
            await handler.Change(n, n.Name);

        }


        public void GoToAddTransactions()
        {
             _goToAddTransactions.Invoke();
        }

    }
}
