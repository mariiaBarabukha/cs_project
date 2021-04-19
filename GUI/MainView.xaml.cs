using System.Windows.Controls;
using GUI.Account;
using GUI.Authentication;
using GUI.CustomerWallet;
using GUI.Transactions;

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
            Content = new AccountView(GoToAddWallet, GotoSignIn, GoToTransactions);
        }

        public void GoToAddWallet()
        {
            Content = new AddWalletView(GoToAccount);
        }

        public void GoToTransactions()
        {
            Content = new TransactionsView(GoToAccount, GoToAddTransaction);
        }

        public void GoToAddTransaction()
        {
            Content = new AddTransactionView(GoToTransactions);
        }

       
    }
}
