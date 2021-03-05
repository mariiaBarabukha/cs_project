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

        
    }
}
