using System.Windows.Controls;
using GUI.Account;
using GUI.Authentication;
using GUI.Wallet;

namespace GUI
{
    
    public partial class MainView : UserControl
    {

        public MainView()
        {
            InitializeComponent();
            Content = new SignInView(GotoSignUp, GoToAccount);
        }

        public void GotoSignUp()
        {
            Content = new SignUpView(GotoSignIn);
        }

        public void GotoSignIn()
        {
            Content = new SignInView(GotoSignUp, GoToAccount);
        }

        public void GoToAccount()
        {
            Content = new AccountView(GoToAddWallet, GotoSignIn);
        }

        public void GoToAddWallet()
        {
            Content = new AddWalletView(GoToAccount);
        }
    }
}
