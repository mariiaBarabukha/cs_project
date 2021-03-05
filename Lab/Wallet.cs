using System;
using System.Collections.Generic;

namespace lab
{
    public class Wallet
    {
        string _name;
        double _startBalance;
        string _description;
        string _basicCurrency;

        double _balance;

        List<BalanceState> _income = new List<BalanceState>();
        List<BalanceState> _outcome = new List<BalanceState>();

        List<Customer> owners = new List<Customer>();
        List<Category> categories = new List<Category>();

        List<Transaction> transactions = new List<Transaction>();

        public Wallet(Customer owner, string name, double sB, string description, string bC)
        {
            owners.Add(owner);
            Name = name;
            StartBalance = sB;
            Description = description;
            BasicCurrency = bC;
            foreach (Category c in owner.GetCategories())
            {
                categories.Add(c);
            }
            _balance = _startBalance;
            categories = owner.GetCategories();
        }


        public string Name { get => _name; set => _name = value; }
        public double StartBalance { get => _startBalance; set => _startBalance = value; }
        public string Description { get => _description; set => _description = value; }
        public string BasicCurrency { get => _basicCurrency; set => _basicCurrency = value; }

        public List<Category> GetCategories()
        {
            return categories;
        }

        public bool AddCategory(Category category)
        {
            if (categories.Contains(category) || !owners[0].GetCategories().Contains(category))
            {
                return false;
            }
            else
            {
                categories.Add(category);
                return true;
            }
        }

        public bool AddOwner(Customer owner)
        {
            if (owners.Contains(owner))
            {
                return false;
            }
            owners.Add(owner);
            return true;
        }

        public bool MakeTransaction(double sum, string currency, Category category, string description, DateTime date, string file = "")
        {
            if ((sum > 0 || sum <= _balance) && categories.Contains(category))
            {
                var transaction = new Transaction(sum, currency, category, date, description, file);
                transactions.Add(transaction);
                _balance += sum;
                if (sum < 0)
                {
                    _outcome.Add(new BalanceState(-sum, date));
                }
                else
                {
                    _income.Add(new BalanceState(sum, date));
                }

                return true;

            }
            else
            {
                Console.WriteLine("you don't have enough money or you've entered incorrect category");
                return false;
            }

        }

        public bool RemoveTransaction(int n)
        {
            if (transactions[n] != null)
            {
                transactions.RemoveAt(n);
                return true;
            }

            return false;

        }

        public List<Transaction> GetTransactions()
        {
            return transactions;
        }

        public void ShowTransactions()
        {
            //Console.WriteLine(transactions.Capacity);
            for (int i = transactions.Count - 1; i > transactions.Count - 11; i--)
            {
                if (i >= 0 && transactions[i] != null)
                    transactions[i].Show();
            }
        }


        public void ShowTransactions(int from)
        {
            //Console.WriteLine(transactions.Capacity);
            for (int i = from + 10; i > from; i--)
            {
                if (i >= 0 && transactions[i] != null)
                    transactions[i].Show();
            }
        }
        public void ShowWalletInfo()
        {
            double inc = 0;
            double outc = 0;

            for (int i = 0; i < _income.Count; i++)
            {

                if (DateTime.Now <= _income[i].Date.AddMonths(1))
                {
                    inc += _income[i].Sum;
                }
            }

            for (int i = 0; i < _outcome.Count; i++)
            {

                if (DateTime.Now <= _outcome[i].Date.AddMonths(1))
                {
                    outc += _outcome[i].Sum;
                }
            }

            Console.WriteLine($"{_balance}, {inc}, {outc}");
        }

    }
}