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
    /// Interaction logic for TransactionsView.xaml
    /// </summary>
    public partial class TransactionsView : UserControl
    {
        private TransactionsViewModel transactionsViewModel;
        public TransactionsView(Action goToAccount, Action goToAddTransaction)
        {
            
            InitializeComponent();
            transactionsViewModel = new TransactionsViewModel(goToAccount, goToAddTransaction);
            this.DataContext = transactionsViewModel;
        }

       
    }
}
