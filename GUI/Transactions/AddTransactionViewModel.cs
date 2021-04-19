using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GUI.DataBase;
using GUI.WalletDB;
using lab;
using Prism.Commands;

namespace GUI.Transactions
{
    class AddTransactionViewModel
    {
        lab.Transaction transaction = new lab.Transaction(0, "UAH", DateTime.Now, "");
        private Action _goToTransaction;

        public double Sum
        {
            get
            {
                return transaction.Sum;
            }
            set
            {
                if (transaction.Sum != (double)value)
                {
                    transaction.Sum = value;
                    OnPropertyChanged();
                    AddTransaction.RaiseCanExecuteChanged();
                }
            }
        }

        public string Currency
        {
            get
            {
                return transaction.Currency;
            }
            set
            {
                if (transaction.Currency != value)
                {
                    transaction.Currency = value;
                    OnPropertyChanged();
                    AddTransaction.RaiseCanExecuteChanged();
                }
               
            }
        }

        public DateTime Date
        {
            get
            {
                return transaction.Date;
            }
            set
            {
                if (transaction.Date != value)
                {
                    transaction.Date = value;
                    OnPropertyChanged();
                    AddTransaction.RaiseCanExecuteChanged();
                }
            }
        }

        public string Description
        {
            get
            {
                return transaction.Description;
            }
            set
            {
                if (transaction.Description != value)
                {
                    transaction.Description = value;
                    OnPropertyChanged();
                    AddTransaction.RaiseCanExecuteChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DelegateCommand GoToTransactionsCommand { get; }
        public DelegateCommand AddTransaction { get; }
        public AddTransactionViewModel(Action goToTransaction)
        {
            _goToTransaction = goToTransaction;
            AddTransaction = new DelegateCommand(Add);
            GoToTransactionsCommand = new DelegateCommand(GoToTransactions);
        }
        lab.Wallet wallet = CurrentInfo.Customer.GetWalletByName(CurrentInfo.WalletInfo.Name);

        public void Add()
        {
            if (String.IsNullOrEmpty(Currency) || String.IsNullOrEmpty(Date.ToString()) || String.IsNullOrEmpty(Sum.ToString()))
            {
                MessageBox.Show("Some fields are empty");

            }
            else
            {
                //if (AlreadyExists())
                //{
                //    MessageBox.Show($"Transaction on '{Date}' already exists");
                //}
                //else
                //{
                // wallet = new lab.Wallet(CurrentInfo.Customer, Name, StartBalance, Description, BasicCurrency);
                transaction = new lab.Transaction(Sum, Currency, Date, Description);

                wallet.MakeTransaction(transaction);
                //adding in the db
                //WalletsHandler handler = new WalletsHandler();
                //handler.Filename = @"../../../DataBase/Wallet/Wallets.json";
                //await handler.write(new DBWallet(CurrentInfo.Customer.Email, wallet.Name,
                //    wallet.Balance, wallet.Description, wallet.BasicCurrency));
                // CurrentInfo.AddRecord(wallet);
                MessageBox.Show(wallet.GetTransactions()[0].Description);
                //MessageBox.Show(wallet.GetTransactions()[0].Description);
                _goToTransaction.Invoke();


            }
        }

        //private bool AlreadyExists()
        //{
            
        //    //??
        //    foreach (lab.Transaction w in wallet)
        //    {
        //        if (Date == w.Date)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        public void GoToTransactions()
        {
            _goToTransaction.Invoke();
        }
    }
}
