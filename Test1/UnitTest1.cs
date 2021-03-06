using System;
using Xunit;
using lab;

namespace Test1
{
    public class UnitTest1
    {
     
        [Fact]
        public void TestCategoriesConstructor()
        {
            //
            var categoriesTest = new Category("one", "", "", "");
            var expectedTest = new Category("one", "", "black", "default");

            //
            //
            Assert.True(String.Equals(categoriesTest._name, expectedTest._name) &&
                String.Equals(categoriesTest.Description, expectedTest.Description) &&
                String.Equals(categoriesTest.Color, expectedTest.Color) &&
                String.Equals(categoriesTest.Icon, expectedTest.Icon));

        }

        [Fact]
        public void TestCategoriesCopy()
        {
            //
            var categoriesTest = new Category("onetwo", "test", "", "");
            var copyTest = new Category();

            //
            copyTest = categoriesTest.CopyCategory();

            //
            Assert.True(String.Equals(categoriesTest._name, copyTest._name) &&
                String.Equals(categoriesTest.Description, copyTest.Description) &&
                String.Equals(categoriesTest.Color, copyTest.Color) &&
                String.Equals(categoriesTest.Icon, copyTest.Icon));
        }

    }
}
