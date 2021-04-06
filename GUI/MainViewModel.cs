using GUI.Navigation;
using GUI.Wallets;

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
