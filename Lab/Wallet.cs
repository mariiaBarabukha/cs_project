using System;
using System.Collections.Generic;
using Lab;

namespace lab
{
    public class Wallet
    {
       // Guid Guid;
        string _name;
        double _startBalance;
        string _description;
        string _basicCurrency;

       // double Balance;

        List<BalanceState> income = new List<BalanceState>();
        List<BalanceState> _outcome = new List<BalanceState>();

        Customer owner;
        List<Customer> owners = new List<Customer>();
        List<Category> categories = new List<Category>();

        List<Transaction> transactions = new List<Transaction>();

        public Wallet( Customer owner, string name, double sB, string description, string bC, Guid guid = default)
        {
            if (guid == default)
            {
                guid = Guid.NewGuid();
            }

            Guid = guid;
            this.owner = owner;
            while (name == "")
            {
                Console.WriteLine("Enter a valid name for the wallet.");
                name = Console.ReadLine();
            }
            
            //while (!Validity.checkValidityCurrency(bC))
            //{
            //    Console.WriteLine("Enter a basic currency for the wallet(UAH, USD, EUR):");
            //    bC = "UAH";
            //}
            Name = name;
            StartBalance = sB;
            Description = description;
            BasicCurrency = bC;
            foreach (Category c in owner.GetCategories())
            {
                categories.Add(c);
            }
            Balance = _startBalance;
            categories = owner.GetCategories();
        }


        public string Name { get => _name; set => _name = value; }
        public double StartBalance { get => _startBalance; set => _startBalance = value; }
        public string Description { get => _description; set => _description = value; }
        public string BasicCurrency { get => _basicCurrency; set => _basicCurrency = value; }
        public List<BalanceState> Income { get => income; set => income = value; }
        public List<BalanceState> Outcome { get => _outcome; set => _outcome = value; }
        public List<Transaction> Transactions { get => transactions; set => transactions = value; }
        public double Balance { get; set; }
        public Guid Guid { get; set; }

        public List<Category> GetCategories()
        {
            return categories;
        }

        public bool AddCategory(Category category)
        {
            if (categories.Contains(category) || !owner.GetCategories().Contains(category))
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
            if (owners.Contains(owner) || this.owner == owner)
            {
                return false;
            }
            owners.Add(owner);
            return true;
        }

        public bool MakeTransaction(double sum, string currency, Category category, string description, DateTime date, string file = "")
        {
            Validity.checkValidityTransaction(sum);
            if ((sum > 0 || sum <= Balance) && categories.Contains(category))
            {
                var transaction = new Transaction(sum, currency, category, date, description, file);
                Transactions.Add(transaction);
                Balance += sum;
                if (sum < 0)
                {
                    Outcome.Add(new BalanceState(-sum, date));
                }
                else
                {
                    Income.Add(new BalanceState(sum, date));
                }

                return true;

            }
            else
            {
                Console.WriteLine("you don't have enough money or you've entered incorrect category");
                return false;
            }

        }

        public bool MakeTransaction(Transaction transaction)
        {
            if (!Transactions.Contains(transaction))
            {


                if (transaction.Sum > 0 || transaction.Sum <= Balance)
                {

                    var temp = transaction.Sum;
                    Transactions.Add(transaction);
                    if (this.BasicCurrency == "UAH")
                    {
                        if (transaction.Currency == "USD")
                        {
                            temp = transaction.Sum * 27;
                        }

                        if (transaction.Currency == "EUR")
                        {
                            temp = transaction.Sum * 30;
                        }
                    }
                    else if (this.BasicCurrency == "USD")
                    {
                        if (transaction.Currency == "UAH")
                        {
                            temp = transaction.Sum / 25;
                        }

                        if (transaction.Currency == "EUR")
                        {
                            temp = transaction.Sum * 0.8;
                        }
                    }
                    else
                    {
                        if (transaction.Currency == "UAH")
                        {
                            temp = transaction.Sum / 30;
                        }

                        if (transaction.Currency == "USD")
                        {
                            temp = transaction.Sum / 1.2;
                        }
                    }

                    Balance += temp;
                    if (transaction.Sum < 0)
                    {
                        Outcome.Add(new BalanceState(-temp, transaction.Date));
                    }
                    else
                    {
                        Income.Add(new BalanceState(temp, transaction.Date));
                    }

                    return true;

                }
                else
                {
                    Console.WriteLine("you don't have enough money or you've entered incorrect category");
                    return false;
                }
            }

            return false;

        }

        public bool RemoveTransaction(Transaction transaction)
        {
            if (Transactions.Contains(transaction))
            {
                Transactions.Remove(transaction);
                return true;
            }

            return false;

        }

        public List<Transaction> GetTransactions()
        {
            return Transactions;
        }

        public void ShowTransactions()
        {
            //Console.WriteLine(transactions.Capacity);
            for (int i = Transactions.Count - 1; i > Transactions.Count - 11; i--)
            {
                if (i >= 0 && Transactions[i] != null)
                    Transactions[i].Show();
            }
        }


        public void ShowTransactions(int from)
        {
            //Console.WriteLine(transactions.Capacity);
            for (int i = from + 10; i > from; i--)
            {
                if (i >= 0 && Transactions[i] != null)
                    Transactions[i].Show();
            }
        }

        public void ShowWalletInfo()
        {
            double inc = 0;
            double outc = 0;

            for (int i = 0; i < Income.Count; i++)
            {

                if (DateTime.Now <= Income[i].Date.AddMonths(1))
                {
                    inc += Income[i].Sum;
                }
            }

            for (int i = 0; i < Outcome.Count; i++)
            {

                if (DateTime.Now <= Outcome[i].Date.AddMonths(1))
                {
                    outc += Outcome[i].Sum;
                }
            }

            Console.WriteLine($"{Balance}, {inc}, {outc}");
        }

        public string ShowWalletInformation()
        {
            double inc = 0;
            double outc = 0;

            for (int i = 0; i < Income.Count; i++)
            {

                if (DateTime.Now <= Income[i].Date.AddMonths(1))
                {
                    inc += Income[i].Sum;
                }
            }

            for (int i = 0; i < Outcome.Count; i++)
            {

                if (DateTime.Now <= Outcome[i].Date.AddMonths(1))
                {
                    outc += Outcome[i].Sum;
                }
            }

            return ($"Balance: {Balance}, Income: {inc}, Outcome: {outc}");
        }

    }
}