using GUI.DataBase;
using Prism.Commands;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Lab;
using GUI.WalletDB;

namespace GUI.CustomerWallet
{
    public class AddWalletViewModel : INotifyPropertyChanged
    {
        lab.Wallet wallet = new lab.Wallet(CurrentInfo.Customer,"",0,"","");
        Action _goToAccount;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get
            {
                return wallet.Name;
            }

            set
            {
                if (wallet.Name != value)
                {
                    wallet.Name = value;
                    OnPropertyChanged();
                    AddCommand.RaiseCanExecuteChanged();
                }
                
            }
        }
        public double StartBalance 
        {
            get
            {
                return wallet.StartBalance;
            }

            set
            {
                if (wallet.StartBalance != value)
                {
                    wallet.StartBalance = (double)value;
                    OnPropertyChanged();
                    AddCommand.RaiseCanExecuteChanged();
                }
                
            }
        }

        public string Description 
        {
            get
            {
                return wallet.Description;
            }

            set
            {
                if (wallet.Description != value)
                {
                    wallet.Description = value;
                    OnPropertyChanged();
                    AddCommand.RaiseCanExecuteChanged();
                }
                
            }
        }

        public string BasicCurrency 
        {
            get
            {
                return wallet.BasicCurrency;
            }

            set
            {
                if(wallet.BasicCurrency != value && Validity.checkValidityCurrency(value))
                {
                    wallet.BasicCurrency = value;
                    OnPropertyChanged();
                    AddCommand.RaiseCanExecuteChanged();
                }
                else
                {
                    MessageBox.Show("Enter proper currency.");
                }
                
            }
        }

        public DelegateCommand CancelCommand { get; }
        public DelegateCommand AddCommand { get; }
        public AddWalletViewModel(Action goToAccount)
        {
          
            
           // _goToAccount = goToAccount;
            AddCommand = new DelegateCommand(Add);
            _goToAccount = goToAccount;
            CancelCommand = new DelegateCommand(_goToAccount);
        }

        public async void Add()

        {
            if (String.IsNullOrEmpty(Name)
                || String.IsNullOrEmpty(BasicCurrency) || String.IsNullOrEmpty(Description))
            {
                MessageBox.Show("Some fields are empty");
                
            }
            else
            {
                if (AlreadyExists())
                {
                    MessageBox.Show($"Wallet with name '{Name}' already exists");
                }
                else 
                {
                    wallet = new lab.Wallet(CurrentInfo.Customer, Name, StartBalance, Description, BasicCurrency);
                    CurrentInfo.Customer.AddWallet(wallet);
                    WalletsHandler handler = new WalletsHandler();
                    handler.Filename = @"../../../DataBase/Wallet/Wallets.json";
                    await handler.write(new DBWallet(CurrentInfo.Customer.Email, wallet.Name,
                        wallet.Balance, wallet.Description,wallet.BasicCurrency));
                   // CurrentInfo.AddRecord(wallet);
                    _goToAccount.Invoke();
                }
                
            }

           
        }

        private bool AlreadyExists()
        {
            foreach (lab.Wallet w in CurrentInfo.Customer.GetWallets())
            {
                if (Name == w.Name)
                {
                    return true;
                }
            }
            return false;
        }
       

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
