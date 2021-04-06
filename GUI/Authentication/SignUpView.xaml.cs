using System;
using System.Windows;
using System.Windows.Controls;

namespace GUI.Authentication
{
    /// <summary>
    /// Interaction logic for SignUpView.xaml
    /// </summary>
    public partial class SignUpView : UserControl
    {
        private SignUpViewModel _viewModel;
        public SignUpView(Action gotoSignIn)
        {
            InitializeComponent();
            _viewModel = new SignUpViewModel(gotoSignIn);
            DataContext = _viewModel;
        }

        private void PasswordInput_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            _viewModel.Password = PasswordInput.Password;
        }
    }
}
