using System;
using Xunit;
using lab;

namespace Test1
{
    public class CustomerTests
    {
        [Fact]
        public void TestCustomerAddingCategoriesByAttributes()
        {
            //
            var testCustomer = new Customer("Vasilii", "Poberezhnii", "vas_pob@gmail.com");
            var testName = "OneTwo";

            //
            testCustomer.AddCategory(testName, "", "", "");

            //
            Assert.True(testCustomer.GetCategories()[0]._name.Equals(testName));
        }
        [Fact]
        public void TestCustomerAddingCategoriesByName()
        {
            //
            var testCustomer = new Customer("Vasilii", "Poberezhnii", "vas_pob@gmail.com");
            var testName = "OneTwoThree";
            var testCategory = new Category(testName, "", "", "");

            //
            testCustomer.AddCategory(testCategory);

            //
            Assert.True(testCustomer.GetCategories()[0]._name.Equals(testName));
        }

        [Fact]
        public void TestCustomerAddingWalletsByName()
        {
            var testCustomer = new Customer("Vasilii", "Poberezhnii", "vas_pob@gmail.com");
            var testName = "wallet1";
            var testWallet = new Wallet(testCustomer, testName, 0, "", "UAH");
            //
            testCustomer.AddWallet(testWallet);

            //
            Assert.True(testCustomer.GetWallets()[0].Name.Equals(testName));
        }

        [Fact]
        public void TestCustomerAddingWalletsByAttributes()
        {
            var testCustomer = new Customer("Vasilii", "Poberezhnii", "vas_pob@gmail.com");
            var testName = "wallet1";
            
            //
            testCustomer.AddWallet(testName, 0, "", "UAH");

            //
            Assert.True(testCustomer.GetWallets()[0].Name.Equals(testName));
        }

        [Fact]
        public void TestCustomerSharingWallet()
        {
            //
            var testCustomer = new Customer("Vasilii", "Poberezhnii", "vas_pob@gmail.com");
            var testCustomer2 = new Customer("Yuliia", "Poberezhna", "yul_pob@gmail.com");
            var testName = "wallet1";
            var testWallet = new Wallet(testCustomer, testName, 0, "", "UAH");

            //
            testCustomer.ShareWallet(testCustomer2, testWallet);


            //
            Assert.True(testCustomer2.GetWallets()[0].Equals(testWallet));
        }
    }
}
