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
            var guiTest = Guid.NewGuid();

            //
            TransactionsHandler handler = new TransactionsHandler();
            handler.Filename = @"../../../DataBase/Transaction/transactions.json";
            handler.write(new DBTransaction(guiTest, "", 0, DateTime.Now, "UAH", ""));

            ////
            Assert.NotNull(handler.Find(guiTest, 0, true));
            
        }

        [Fact]
        public void TestRemovingTransactions()
        {
            //
            var categoriesTest = new Category("one", "", "", "");
            var guiTest = Guid.NewGuid();

            //
            TransactionsHandler handler = new TransactionsHandler();
            handler.Filename = @"../../../DataBase/Transaction/transactions.json";
            handler.write(new DBTransaction(guiTest, "", 0, DateTime.Now, "UAH", ""));
            handler.Remove(guiTest);

            ////
            var ex = Assert.Throws<AggregateException>(() => handler.Find(guiTest).Result);
            Assert.NotNull(ex);

        }
    }

}
