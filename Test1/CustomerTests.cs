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

            //
            testCustomer.AddCategory("OneTwo", "", "", "");

            //
            Assert.True(testCustomer.GetCategories()[0]._name.Equals("OneTwo"));
        }
        [Fact]
        public void TestCustomerAddingCategoriesByName()
        {
            //
            var testCustomer = new Customer("Vasilii", "Poberezhnii", "vas_pob@gmail.com");
            var testCategory = new Category("OneTwoThree", "", "", "");

            //
            testCustomer.AddCategory(testCategory);

            //
            Assert.True(testCustomer.GetCategories()[0]._name.Equals("OneTwoThree"));
        }
    }
}
