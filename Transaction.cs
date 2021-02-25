using System;

namespace lab{
    class Transaction{
        double _sum;
        string _currency;
        Category _category;
        string _description;
        DateTime _date;
        string _file;

        public Transaction(double sum, string currency, Category category, DateTime date,
         string description, string file = ""){
             Sum = sum;
             Currency = currency;
             Category = category;
             Date = date;
             Description = description;
             File = file;
        }

        public Category Category { get => _category; private set => _category = value; }
        public string Description { get => _description; set => _description = value; }
        public string File { get => _file; set => _file = value; }
        public double Sum { get => _sum; private set => _sum = value; }
        public DateTime Date { get => _date; private set => _date = value; }
        public string Currency { get => _currency; private set => _currency = value; }

        public void Show(){
            Console.WriteLine($"{_sum}, {_currency}, {_category}, {_description}, {_date}, {_file}");
        }
        
    }
}