using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab;
using Prism.Mvvm;

namespace GUI.Transactions
{
    public class TransactionInfo : BindableBase
    {
        //lab.Transaction transaction;

        public double Sum
        {
            get
            {
                return Transaction.Sum;
            }

            set
            {
                Transaction.Sum = value;
                RaisePropertyChanged(nameof(DisplayTransaction));
            }
        }

        public string Description
        {
            get
            {
                return Transaction.Description;
            }

            set
            {
                Transaction.Description = value;
                RaisePropertyChanged(nameof(DisplayTransaction));
            }
        }

        public DateTime Date
        {
            get
            {
                return Transaction.Date;
            }
            set
            {
                Transaction.Date = value;
                RaisePropertyChanged(nameof(DisplayTransaction));
            }
        }

        public string Currency
        {
            get
            {
                return Transaction.Currency;
            }
            set
            {
                Transaction.Currency = value;
                RaisePropertyChanged(nameof(DisplayTransaction));
            }
        }

        private string setSymbolForCurrency(string c)
        {
            string res = "--";
            switch (c)
            {
                case "USD":
                    res = "$";
                    break;
                case "UAH":
                    res = "₴";
                    break;
                case "EUR":
                    res = "€";
                    break;
            }
            return res;
        }

        public string DisplayTransaction
        {
            get
            {
                return $"{Transaction.Date} " +
                    $"{setSymbolForCurrency(Transaction.Currency)}" +
                    $"{Transaction.Sum} {Transaction.Description}";
            }

        }

        public Transaction Transaction { get; private set; }

        public TransactionInfo(Transaction transaction)
        {
            Transaction = transaction;
            Transaction.Category = new Category("test", "", "", "");
            

        }

    }
}
