using System;
using Lab;
using System.Reflection.Metadata;
using System.IO;
using System.Security.Cryptography;

namespace lab{
    public class Transaction{
        public Guid Guid { get; private set; }
        double _sum;
        string _currency;
        Category _category;
        string _description;
        DateTime _date;
        string _file;

        public Transaction(double sum, string currency, DateTime date,
            string description, Guid guid = default)
        {
            //Validity.checkValidityTransaction(sum);
            if (guid == default)
            {
                guid = Guid.NewGuid();
            }
            Guid = guid;
            Sum = sum;
            Currency = currency;
            Date = date;
            Description = description;

        }
        public Transaction(double sum, string currency, Category category, DateTime date,
         string description, string file = "NONE"){
            Validity.checkValidityTransaction(sum);
             Sum = sum;
             Currency = currency;
             Category = category;
             Date = date;
             Description = description;
             File = file;
        }

       

        public Category Category { get => _category; set => _category = value; }
        public string Description { get => _description; set => _description = value; }
        public string File { get => _file; set => _file = value; }
        public double Sum { get => _sum; set => _sum = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public string Currency { get => _currency; set => _currency = value; }

        public void Show(){
            Console.WriteLine($"{_sum}, {_currency}, {_category}, {_description}, {_date}, {_file}");
        }
        
    }
}