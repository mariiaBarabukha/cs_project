

using lab;
using Prism.Mvvm;

namespace GUI.Wallets
{
    public class WalletInfo : BindableBase
    {
        lab.Wallet wallet;
        public string Name { 
            get { 
                return wallet.Name;
            } 

            set { 
                wallet.Name = value;
                RaisePropertyChanged(nameof(DisplayName));
            } 
        }
        public double Balance 
        { 
            get 
            {
                return wallet.StartBalance;
            } 

            set 
            { 
                wallet.StartBalance = value;
                RaisePropertyChanged(nameof(DisplayName));
            } 
        }

        public string DisplayName
        {
            get
            {
                return $"{wallet.Name} (${wallet.StartBalance})";
            }
        }
        public WalletInfo(lab.Wallet wallet)
        {
            this.wallet = wallet;
        }


    }
}
