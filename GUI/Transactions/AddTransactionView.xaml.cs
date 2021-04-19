using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.Transactions
{
    /// <summary>
    /// Interaction logic for AddTransactionView.xaml
    /// </summary>
    public partial class AddTransactionView : UserControl
    {
        private AddTransactionViewModel _view;
        public AddTransactionView(Action goToTransaction)
        {
            InitializeComponent();
            _view = new AddTransactionViewModel(goToTransaction);
            this.DataContext = _view;
        }
    }
}
