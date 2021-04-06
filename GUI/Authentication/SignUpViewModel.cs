using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using GUI.Users;
using Prism.Commands;
using Lab;

namespace GUI.Authentication
{
    public class SignUpViewModel : INotifyPropertyChanged
    {
        private RegisteredUser _regUser = new RegisteredUser();
        private Action _gotoSignIn;
        private bool loginTaken = false;

        public string Login
        {
            get => _regUser.Login;
            set
            {
                if (_regUser.Login != value)
                {

                    _regUser.Login = value;
                    
                }

                StreamReader sr = new StreamReader(@"..\..\..\DataBase\ourCustomers.txt");

                int temp = sr.Read();
                int i = 0;

                while (temp != -1 && Convert.ToChar(temp) != ' ')
                {
                    if (Convert.ToChar(temp) != _regUser.Login.ToCharArray()[i])
                    {
                        sr.ReadLine();
                        i = -1;

                    }

                    temp = sr.Read();
                    i++;

                }

                if(temp != -1)
                {
                    MessageBox.Show("This login is taken.");
                    loginTaken = true;
                }
                else
                {
                    loginTaken = false;
                    OnPropertyChanged();
                    SignUpCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Password
        {
            get => _regUser.Password;
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
                //how to check email without losing focus?
                if (_regUser.Email != value && Validity.checkValidityEmail(value))
                {
                    _regUser.Email = value;
                    OnPropertyChanged();
                    SignUpCommand.RaiseCanExecuteChanged();
                }
                else
                {
                    MessageBox.Show("You are not allowed to use this email");
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

        private void SignUp()
        {
            if (!loginTaken)
            {

                var authService = new AuthenticationService();
                User user = null;
                try
                {
                    user = authService.RegisterUser(_regUser);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sign in failed: {ex.Message}");
                    return;
                }

                MessageBox.Show($"User successfully registered. Please sign in");
                StreamWriter sw = new StreamWriter(@"..\..\..\DataBase\ourCustomers.txt", true);

                sw.Write($"\n{_regUser.Login} {_regUser.Password} {user.FirstName} {user.LastName} {user.Email}");
                sw.Close();
                _gotoSignIn.Invoke();
            }
            else
            {
                MessageBox.Show("Change your login");
            }

        }

        


        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
