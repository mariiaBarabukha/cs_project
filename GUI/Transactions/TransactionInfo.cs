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
        lab.Transaction transaction;

        public double Sum
        {
            get
            {
                return transaction.Sum;
            }

            set
            {
                transaction.Sum = value;
                RaisePropertyChanged(nameof(DisplayTransaction));
            }
        }

        public string Description
        {
            get
            {
                return transaction.Description;
            }

            set
            {
                transaction.Description = value;
                RaisePropertyChanged(nameof(DisplayTransaction));
            }
        }

        public DateTime Date
        {
            get
            {
                return transaction.Date;
            }
            set
            {
                transaction.Date = value;
                RaisePropertyChanged(nameof(DisplayTransaction));
            }
        }

        public string Currency
        {
            get
            {
                return transaction.Currency;
            }
            set
            {
                transaction.Currency = value;
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
                return $"{transaction.Date} {setSymbolForCurrency(transaction.Currency)}{transaction.Sum} {transaction.Description}";
            }

        }

        public TransactionInfo(lab.Transaction transaction)
        {
            this.transaction = transaction;
            this.transaction.Category = new Category("test", "", "", "");
            

        }

    }
}
