using Prism.Commands;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using GUI.Users;
using lab;
using GUI.DataBase;

namespace GUI.Authentication
{
    public partial class SignInViewModel : INotifyPropertyChanged
    {
        private AuthenticationUser _authUser = new AuthenticationUser();
        private Action _gotoSignUp;
        private Action _goToWallet;

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

        public SignInViewModel(Action gotoSignUp, Action goToWallet)
        {
            SignInCommand = new DelegateCommand(SignIn, IsSignInEnabled);
            _gotoSignUp = gotoSignUp;
            SignUpCommand = new DelegateCommand(_gotoSignUp);
            _goToWallet = goToWallet;

        }

        private bool IsSignInEnabled()
        {
            return !String.IsNullOrWhiteSpace(Login) && !String.IsNullOrWhiteSpace(Password);
        }

        private void SignIn()
        {
            if (String.IsNullOrWhiteSpace(Login) || String.IsNullOrWhiteSpace(Password))
                MessageBox.Show("Login or password is empty");
            else
            {
                var authService = new AuthenticationService();
                User user = null;
                try
                {
                    user = authService.Authenticate(_authUser);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sign in failed: {ex.Message}");
                    return;
                }
                MessageBox.Show($"Sign in was successful for user {user.FirstName} {user.LastName}");
                lab.Customer ourCustomer = new lab.Customer(user.FirstName, user.LastName, user.Email);
                CurrentInfo.Customer = ourCustomer;

                //string fileName = @"ourCustomers.txt";
                //string path = Path.GetFullPath(fileName);
                //StreamWriter sw = new StreamWriter(@path, true);

                //sw.Write("zhopa");
                //sw.Close();

                //testAppliance below
                MessageBox.Show($"{ourCustomer.LastName} {ourCustomer.FirstName} {ourCustomer.Email}");
                _goToWallet.Invoke();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
