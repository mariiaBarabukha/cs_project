

using lab;
using Prism.Mvvm;

namespace GUI.Wallets
{
    public class WalletInfo : BindableBase
    {
        Wallet wallet;
        public string Name { 
            get 
            { 
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
                return wallet.Balance;
            } 

            set 
            { 
                wallet.Balance = value;
                RaisePropertyChanged(nameof(DisplayName));
            } 
        }

        private string setSymbolForCurrency(string c)
        {
            string res = "--";
            switch (c)
            {
                case "USD":
                    res = "$";
                    break;
                case "UAH":
                    res = "₴";
                    break;
                case "EUR":
                    res = "€";
                    break;
            }
            return res;
        }

        public string DisplayName
        {
            get
            {
                return $"{wallet.Name} ({setSymbolForCurrency(wallet.BasicCurrency)}{wallet.Balance})";
            }
        }

        public Wallet Wallet { get => wallet;}

        public WalletInfo(lab.Wallet wallet)
        {
            this.wallet = wallet;
        }


    }
}
