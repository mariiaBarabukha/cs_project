using System;
using System.Windows;
using System.Windows.Controls;

namespace GUI.Authentication
{
    /// <summary>
    /// Interaction logic for SignInView.xaml
    /// </summary>
    public partial class SignInView : UserControl
    {
        private SignInViewModel _viewModel;
        public SignInView(Action gotoSignUp)
        {
            InitializeComponent();
            _viewModel = new SignInViewModel(gotoSignUp);
            this.DataContext = _viewModel;
      
        }

        private void PasswordInput_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            _viewModel.Password = PasswordInput.Password;
        }
    }
}
