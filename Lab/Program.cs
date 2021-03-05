using System;

namespace lab
{
    class Program
    {
        static void Main(string[] args)
        {
            //test part-----------------
            var test = new Category("assas", "", "", "");
            char[] badSymbols = {'@', '-', '_', '!', '?', '+', '=', ')',
                '(', '*', '^', '$', '#', '"', '`', '~', '/', '\\', '.', ',', '|', '№', ';', '₴', '%', '&'};
            var test2 = new Customer("231@232", "", "");
            //Console.WriteLine(test2.FirstName.IndexOfAny(badSymbols, 0));











            //--------------------------
            
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
            costumer.GetWallets()[0].ShowWalletInfo();
        }
    }
}
