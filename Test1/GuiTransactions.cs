using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using GUI.DataBase;
using Xunit;
using lab;

namespace Test1
{
    public class GuiTransactions
    {
        [Fact]
        public void TestAddingTransactions()
        {
            //
            var categoriesTest = new Category("one", "", "", "");
            //var transaction = new lab.Transaction(0, "UAH", categoriesTest, DateTime.Now, "");
            var guiTest = Guid.NewGuid();

            //
            TransactionsHandler handler = new TransactionsHandler();
            handler.Filename = @"../../../DataBase/Transaction/transactions.json";
            handler.write(new DBTransaction(guiTest, "", 0, DateTime.Now, "UAH", ""));

            ////
            Assert.NotNull(handler.Find(guiTest, true));
            //Assert.NotNull(categoriesTest);
        }
    }

}
