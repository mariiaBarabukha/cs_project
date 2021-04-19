using System;
using Xunit;
using lab;

namespace Test1
{
    public class WalletTests
    {
        [Fact]
        public void  TestWalletConstructorAlongsideWithCategories()
        {
            //
            var testCustomer = new Customer("Vasilii", "Poberezhnii", "vas_pob@gmail.com");
            var testCategory = new Category("OneTwo", "", "", "");
            testCustomer.AddCategory(testCategory);
            var testName = "wallet1";

            //
            var testWallet = new Wallet(testCustomer, testName, 0, "", "UAH");

            //
            Assert.True(testWallet.GetCategories()[0].Equals(testCategory));
        }

        [Fact]
        public void TestWalletAddingCategories()
        {
            //
            var testCustomer = new Customer("Vasilii", "Poberezhnii", "vas_pob@gmail.com");
            var testCategory = new Category("OneTwo", "", "", "");
            testCustomer.AddCategory(testCategory);
            var testName = "wallet1";
            var testWallet = new Wallet(testCustomer, testName, 0, "", "UAH");

            //
            var testCategory2 = new Category("OneTwoThree", "", "", "");
            testCustomer.AddCategory(testCategory2);
            testWallet.AddCategory(testCategory2);

            //
            Assert.True(testWallet.GetCategories()[1].Equals(testCategory2));
        }

        [Fact]
        public void TestWalletAddingTransactionByAttributes()
        {
            //
            var testCustomer = new Customer("Vasilii", "Poberezhnii", "vas_pob@gmail.com");
            var testCategory = new Category("OneTwo", "", "", "");
            testCustomer.AddCategory(testCategory);
            var testName = "wallet1";
            var testWallet = new Wallet(testCustomer, testName, 0, "", "UAH");
            var testDate = new DateTime(2002, 12, 2);

            //
            testWallet.MakeTransaction(-200, "UAH", testCategory, "", testDate, "");

            //
            Assert.NotEmpty(testWallet.Outcome);

        }

        [Fact]
        public void TestWalletAddingTransactionByName()
        {
            //
            var testCustomer = new Customer("Vasilii", "Poberezhnii", "vas_pob@gmail.com");
            var testCategory = new Category("OneTwo", "", "", "");
            testCustomer.AddCategory(testCategory);
            var testName = "wallet1";
            var testWallet = new Wallet(testCustomer, testName, 0, "", "UAH");
            var testDate = new DateTime(2002, 12, 2);
            var testTransaction = new Transaction(200, "UAH", testCategory, testDate, "", "");

            //
            testWallet.MakeTransaction(testTransaction);

            //
            Assert.NotEmpty(testWallet.Income);

        }

        [Fact]
        public void TestWalletRemovingTransaction()
        {
            //
            var testCustomer = new Customer("Vasilii", "Poberezhnii", "vas_pob@gmail.com");
            var testCategory = new Category("OneTwo", "", "", "");
            testCustomer.AddCategory(testCategory);
            var testName = "wallet1";
            //var testWallet = new Wallet(testCustomer, testName, 0, "", "UAH");
            var testDate = new DateTime(2002, 12, 2);
            var testTransaction = new Transaction(200, "UAH", testCategory, testDate, "", "");

            //
           // testWallet.MakeTransaction(testTransaction);
            //testWallet.RemoveTransaction(0);

            //
           // Assert.Empty(testWallet.Transactions);

        }



    }
}
