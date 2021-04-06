using System.Windows.Controls;
using GUI.Account;
using GUI.Authentication;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
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
            Content = new AccountView(GoToAddWallet);
        }

        public void GoToAddWallet()
        {
            //TODO
        }
    }
}
