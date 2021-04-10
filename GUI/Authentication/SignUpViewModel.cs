using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using GUI.Users;
using Prism.Commands;
using Lab;
using GUI.Services;
using GUI.DataBase;

namespace GUI.Authentication
{
    public class SignUpViewModel : INotifyPropertyChanged
    {
        private RegisteredUser _regUser = new RegisteredUser();
        private Action _gotoSignIn;
        private bool loginTaken = false;

        public string Login
        {
            get
            {
                return _regUser.Login;
            }
            set
            {
                if (_regUser.Login != value)
                {
                    _regUser.Login = value;
                    OnPropertyChanged();
                    SignUpCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Password
        {
            get
            {
                return _regUser.Password;
            }
            set
            {
                if (_regUser.Password != value)
                {
                    _regUser.Password = value;
                    OnPropertyChanged();
                    SignUpCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string LastName
        {
            get => _regUser.LastName;
            set
            {
                if (_regUser.LastName != value && Validity.checkValidity(value))
                {
                    _regUser.LastName = value;
                    OnPropertyChanged();
                    SignUpCommand.RaiseCanExecuteChanged();
                }
                else
                {
                    MessageBox.Show("You are not allowed to use these symbols.");
                }
            }
        }

        public string Email
        {
            get
            {
                return _regUser.Email;
            }
            set
            {
                if (_regUser.Email != value)
                {
                    _regUser.Email = value;
                    OnPropertyChanged();
                    SignUpCommand.RaiseCanExecuteChanged();
                }
                
            }
        }

        public string FirstName
        {
            get
            {
                return _regUser.FirstName;
            }
            set
            {
                if (_regUser.FirstName != value && Validity.checkValidity(value))
                {
                    
                    _regUser.FirstName = value;
                    OnPropertyChanged();
                    SignUpCommand.RaiseCanExecuteChanged();
                }
                else
                {

                    MessageBox.Show("You are not allowed to use these symbols.");

                }
            }
        }

        public DelegateCommand SignUpCommand { get; }


        public DelegateCommand SignInCommand { get; }

        public SignUpViewModel(Action gotoSignIn)
        {
            SignUpCommand = new DelegateCommand(SignUp, IsSignUpEnabled);
            _gotoSignIn = gotoSignIn;
            SignInCommand = new DelegateCommand(_gotoSignIn);

        }

        private bool IsSignUpEnabled()
        {
            return !String.IsNullOrWhiteSpace(Login) && !String.IsNullOrWhiteSpace(Password) && !String.IsNullOrWhiteSpace(LastName) && !String.IsNullOrWhiteSpace(Email)
                &&!String.IsNullOrWhiteSpace(FirstName);
        }

        private async void SignUp()
        {
            if (!loginTaken && Validity.checkValidityEmail(Email))
            {

                var authService = new AuthenticationService();
                //User user = null;
                try
                {
                    _regUser.Password = PasswordHandler.Code(_regUser.Password);
                   await authService.RegisterUser(_regUser);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sign in failed: {ex.Message}");
                    return;
                }

                MessageBox.Show($"User successfully registered. Please sign in");
               
                _gotoSignIn.Invoke();
            }
            else
            {
                if (loginTaken) MessageBox.Show("Change your login");
                else MessageBox.Show("You should use a proper email");
            }

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
