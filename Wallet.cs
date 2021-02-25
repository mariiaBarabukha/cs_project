using System;
using System.Collections.Generic;

namespace lab{
    class Wallet{       
        string _name;
        double _startBalance;
        string _description;
        string _basicCurrency;

        List<Costumer> owners = new List<Costumer>();
        List<Category> categories = new List<Category>();

        public List<Transaction> transactions = new List<Transaction>();

        public Wallet(Costumer owner, string name, double sB, string description, string bC){
            owners.Add(owner);
            Name = name;
            StartBalance = sB;
            Description = description;
            BasicCurrency = bC;
            foreach(Category c in owner.GetCategories()){
                categories.Add(c);
            }
        }

        public string Name { get => _name; set => _name = value; }
        public double StartBalance { get => _startBalance; set => _startBalance = value; }
        public string Description { get => _description; set => _description = value; }
        public string BasicCurrency { get => _basicCurrency; set => _basicCurrency = value; }

        public List<Category> GetCategories(){
            return categories;
        }

        public void AddOwner(Costumer owner){
            owners.Add(owner);
        }

        public void MakeTransaction(double sum, string currency, Category category, string description, DateTime date, string file = ""){
            if((sum > 0 || sum <= _startBalance) && categories.Contains(category)){
                var transaction = new Transaction(sum, currency, category, date, description, file);
                transactions.Add(transaction);
                _startBalance += sum;
            }else{
                Console.WriteLine("you don't have enough money or you've entered incorrect category");
            }
           
        }

        public void RemoveTransaction(int n){
            if(transactions[n] != null)
                transactions.RemoveAt(n);
        }

        public void ShowTransactions(){
            //Console.WriteLine(transactions.Capacity);
            for(int i = transactions.Count - 1; i > transactions.Count - 11; i --){
                if(i>= 0 && transactions[i] != null)
                    transactions[i].Show();
            }
        }
        
    }
}