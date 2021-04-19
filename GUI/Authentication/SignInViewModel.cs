using Prism.Commands;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using GUI.Users;
using GUI.DataBase;
using GUI.Services;
using GUI.WalletDB;
using lab;
using System.Threading.Tasks;

namespace GUI.Authentication
{
    public partial class SignInViewModel : INotifyPropertyChanged
    {
        private AuthenticationUser _authUser = new AuthenticationUser();
        private Action _gotoSignUp;
        private Action _goToWallet;
        private bool _isEnabled = true;

        public string Login
        {
            get => _authUser.Login;
            set
            {
                if (_authUser.Login != value)
                {
                    _authUser.Login = value;
                    OnPropertyChanged();
                    SignInCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Password
        {
            get => _authUser.Password;
            set
            {                
                if (_authUser.Password != value)
                { 
                    _authUser.Password = value;
                    OnPropertyChanged();
                    SignInCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public DelegateCommand SignInCommand { get; }

        public DelegateCommand SignUpCommand { get; }
        public bool IsEnabled { get => _isEnabled; set => _isEnabled = value; }

        public SignInViewModel(Action gotoSignUp, Action goToWallet)
        {
            //2
            SignInCommand = new DelegateCommand(SignIn, IsSignInEnabled);
            _gotoSignUp = gotoSignUp;
            SignUpCommand = new DelegateCommand(_gotoSignUp);
            _goToWallet = goToWallet;

        }

        private bool IsSignInEnabled()
        {
            return !String.IsNullOrWhiteSpace(Login) && !String.IsNullOrWhiteSpace(Password);
        }

        private async void SignIn()
        {
            if (String.IsNullOrWhiteSpace(Login) || String.IsNullOrWhiteSpace(Password))
                MessageBox.Show("Login or password is empty");
            else
            {
                var authService = new AuthenticationService();
                User user = null;
                try
                {
                    IsEnabled = false;
                    _authUser.Password = PasswordHandler.Code(_authUser.Password);
                    user = await authService.Authenticate(_authUser);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sign in failed: {ex.Message}");
                    return;
                }
                MessageBox.Show($"Sign in was successful for user {user.FirstName} {user.LastName}");
                CurrentInfo.Customer = new lab.Customer(user.FirstName, user.LastName, user.Email);
                await LoadAsync();
                _goToWallet.Invoke();
            }
        }

        private async Task LoadAsync()
        {
            WalletsHandler walletsHandler = new WalletsHandler();
            walletsHandler.Filename = @"../../../DataBase/Wallet/Wallets.json";
            var wallets = await walletsHandler.Find(CurrentInfo.Customer.Email);
            //var w = new List<Wallet>();
            foreach (DBWallet wallet in wallets)
            {
                CurrentInfo.Customer.AddWallet(new Wallet(CurrentInfo.Customer, wallet.Name,
                    wallet.Balance, wallet.Description, wallet.BasicCurrency, wallet.WalletGuid));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
