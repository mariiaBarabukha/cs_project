using System;

namespace lab
{
    class Program
    {
        static void Main(string[] args)
        {
            var costumer = new Costumer("Vasya", "Volk", "gfvolkvasya@gmail.com");
            costumer.AddCategory("c1");
            costumer.AddCategory("c2");

            costumer.AddWallet("wallet1", 2, "useless wallet", "ukr grivna");


            var costumer2 = new Costumer("Ari", "Aru", "mariia.barabukha@gmail.com");
            costumer.ShareWallet(costumer2, costumer.GetWallets()[0]);

            costumer.GetWallets()[0].MakeTransaction(100, "ukr grivna", costumer.GetCategories()[0], "test", DateTime.Now);
            costumer.GetWallets()[0].MakeTransaction(-10, "ukr grivna", costumer.GetCategories()[0], "test", DateTime.Now);
           // Console.WriteLine(costumer.GetWallets()[0].transactions[0].Show()); 
            costumer.GetWallets()[0].ShowTransactions();
            costumer.GetWallets()[0].ShowWalletInfo();
        }
    }
}
