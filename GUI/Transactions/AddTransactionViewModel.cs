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

        public string Sum
        {
            get
            {
                return transaction.Sum.ToString();
            }
            set
            {
                if (transaction.Sum.ToString() != value)
                {
                    transaction.Sum = Convert.ToDouble(value);
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
        lab.Wallet wallet = CurrentInfo.Customer.GetWalletByName(CurrentInfo.Wallet.Name);

        public async void Add()
        {
            if (String.IsNullOrEmpty(Currency) || String.IsNullOrEmpty(Date.ToString()) || String.IsNullOrEmpty(Sum.ToString()))
            {
                MessageBox.Show("Some fields are empty");

            }
            else
            {
                transaction = new Transaction(Convert.ToDouble(Sum), Currency, Date, Description);

                wallet.MakeTransaction(transaction);
                //MessageBox.Show(wallet.Balance.ToString());
                //adding in the db
                TransactionsHandler handler = new ();
                handler.Filename = @"../../../DataBase/Transaction/transactions.json";
                await handler.write(new DBTransaction(CurrentInfo.Wallet.Guid, 
                    Description, Convert.ToDouble(Sum), Date, Currency, "NONE"));
                
                _goToTransaction.Invoke();
            }
        }

        public void GoToTransactions()
        {
            _goToTransaction.Invoke();
        }
    }
}
