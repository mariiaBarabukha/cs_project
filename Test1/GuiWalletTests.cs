using System;
using GUI.DataBase;
using GUI.WalletDB;
using lab;
using Xunit;

namespace Test1
{
    public class GuiWalletTests
    {

        [Fact]
        public void TestAddingWallets()
        {
            //
            var testDBWallet = new DBWallet
            {
                Balance = 120,
                BasicCurrency = "UAH",
                WalletGuid = Guid.NewGuid(),
                Description = "",
                Name = "Name",
                OwnerEmail = "OwnerEmail"
            };

            //
            WalletsHandler walletsHandler = new WalletsHandler();
            var filename = @"../../../DataBase/Wallet/wallets.json";
            walletsHandler.Filename = filename;
            walletsHandler.write(testDBWallet);

            //
            Assert.NotNull(walletsHandler.Find("OwnerEmail", "Name").Result);


        }

        [Fact]
        public void TestChangingWallets()
        {
            //
            var testCustomer = new Customer("Vasilii", "Poberezhnii", "vas_pob@gmail.com");
            var testName = "wallet1";
            var testWallet = new Wallet(testCustomer, testName, 0, "", "UAH");

            WalletsHandler walletsHandler = new WalletsHandler();
            var filename = @"../../../DataBase/Wallet/wallets.json";
            walletsHandler.Filename = filename;

            //
            
            walletsHandler.Change(testWallet, "changedName");
            

            //
            Assert.NotNull(walletsHandler.Find("OwnerEmail", "changedName"));

        }


        [Fact]
        public void TestRemovingWallets()
        {
            //
            WalletsHandler walletsHandler = new WalletsHandler();
            var filename = @"../../../DataBase/Wallet/wallets.json";
            walletsHandler.Filename = filename;

            //
            walletsHandler.Remove("OwnerEmail", "Name");

            //
            Assert.NotNull(walletsHandler.Find("OwnerEmail", "changedName"));

        }


    }
}
