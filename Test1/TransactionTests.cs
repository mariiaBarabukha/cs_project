using System;
using Xunit;
using lab;



namespace Test1
{
    public class TransactionTests
    {
        [Fact]
        public void TestTransactionConstructor()
        {
            //
            var categoryTest = new Category("categoryTest", "", "", "");
            var dateTest = new DateTime(2002, 12, 2);

            //
            var transactionTest = new Transaction(120, "UAH", categoryTest, dateTest, "", "");

            //
            Assert.NotNull(transactionTest);
        }
    }

}
