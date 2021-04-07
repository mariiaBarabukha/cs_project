using GUI.DataBase;
using GUI.Navigation;
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

        private Action _goToAddWallet;
        private string prev = "";
        public WalletInfo CurrentWallet {
            get
            {
                return _currentWallet;
            }
            set
            {
                if(_currentWallet!=null)
                    prev = _currentWallet.Name;
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
        public DelegateCommand SubmitWalletCommand { get; }


        public WalletsViewModel()
        {
            
            //_service = new WalletService();
           // UserForTest user = new UserForTest();
            customer = CurrentInfo.Customer;
            CurrentInfo.getWalletsFromDB();
           // Wallets = new ObservableCollection<WalletInfo>();
            //customer.AddWallet("w1", 100, "first", "USD");
            //customer.AddWallet("w2", 110, "Second", "USD");
            Wallets = new ObservableCollection<WalletInfo>();
            RemoveWalletCommand = new DelegateCommand(Remove);
            //SubmitWalletCommand = new DelegateCommand(Submit);
            foreach (var wallet in CurrentInfo.Wallets)
            {
                Wallets.Add(new WalletInfo(wallet));
            }
        }

        public void Remove()
        {
            if (CurrentWallet != null)
            {
                CurrentInfo.Remove(CurrentWallet.Name);
                Wallets.Remove(CurrentWallet);
                CurrentWallet = null;
            }
            
           
        }

        public void Submit()
        {
          //  if(prev!="")
             //   CurrentInfo.Change(prev,_currentWallet.Name);
            
        }

       

       

        public void ClearSensitiveData()
        {
            throw new NotImplementedException();
        }
    }
}
