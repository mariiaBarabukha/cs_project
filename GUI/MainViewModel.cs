using GUI.Navigation;
using GUI.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class MainViewModel : NavigationBase<WalletNavigatableTypes>
    {
        public MainViewModel()
        {
            Navigate(WalletNavigatableTypes.Auth);
        }

        protected override INavigatable<WalletNavigatableTypes> CreateViewModel(WalletNavigatableTypes type)
        {
            return new WalletsViewModel();
        }
    }
}
