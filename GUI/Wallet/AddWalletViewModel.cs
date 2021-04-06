using GUI.DataBase;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Wallet
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
                if (wallet.StartBalance != (double)value)
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
                if(wallet.BasicCurrency != value)
                {
                    wallet.BasicCurrency = value;
                    OnPropertyChanged();
                    AddCommand.RaiseCanExecuteChanged();
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

        public void Add()
        {
            wallet = new lab.Wallet(CurrentInfo.Customer,Name, StartBalance,Description,BasicCurrency);
            CurrentInfo.Customer.AddWallet(wallet);
            _goToAccount.Invoke();
        }

       

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
