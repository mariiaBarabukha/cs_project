using System;
//-delete
using Lab;

namespace lab
{
    class Program
    {
        static void Main(string[] args)
        {
          
            //--------------------------
/*
            var costumer = new Customer("Vasya", "Volk", "gfvolkvasya@gmail.com");
            costumer.AddCategory("c1", "d1","red","rrrrrr");
            costumer.AddCategory("c2", "d2","blue","aaaaa");

            costumer.AddWallet("wallet1", 2, "useless wallet", "ukr grivna");


            var costumer2 = new Customer("Ari", "Aru", "mariia.barabukha@gmail.com");
            costumer.ShareWallet(costumer2, costumer.GetWallets()[0]);

            costumer.GetWallets()[0].MakeTransaction(100, "ukr grivna", costumer.GetCategories()[0], "test", DateTime.Now);
            costumer.GetWallets()[0].MakeTransaction(-10, "ukr grivna", costumer.GetCategories()[0], "test", DateTime.Now);
           // Console.WriteLine(costumer.GetWallets()[0].transactions[0].Show()); 
            costumer.GetWallets()[0].ShowTransactions();
            costumer.GetWallets()[0].ShowWalletInfo();*/

            var customer1 = new Customer("Ari", "Ari", "mariia.barabukha@gmail.com");
            customer1.AddCategory("c1", "d1","red","rrrrrr");
            customer1.AddWallet("wallet1", 100, "first wallet", "UAH");
            customer1.GetWallets()[0].MakeTransaction(-20, "UAH", customer1.GetCategories()[0], "first transaction", DateTime.Now);
            customer1.GetWallets()[0].MakeTransaction(100, "UAH", customer1.GetCategories()[0], "second transaction", (DateTime.Now).AddMonths(1));
            customer1.GetWallets()[0].MakeTransaction(-40, "UAH", customer1.GetCategories()[0], "third transaction", (DateTime.Now).AddMonths(2));
            customer1.GetWallets()[0].MakeTransaction(-30, "UAH", customer1.GetCategories()[0], "for testing remove", (DateTime.Now).AddMonths(2));
            //customer1.GetWallets()[0].RemoveTransaction(3);
            customer1.GetWallets()[0].ShowTransactions();
            customer1.GetWallets()[0].ShowWalletInfo();

            var customer2 = new Customer("Vasya", "Volk", "gfvolkvasya@gmail.com");
            customer1.ShareWallet(customer2, customer1.GetWallets()[0]);
            customer2.GetWallets()[0].ShowWalletInfo();
        }
        
    }
}
