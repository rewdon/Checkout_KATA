using ClassLibrary;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);//testing the test project 
        }

        [Fact]
        public void createitem()
        {
            Item newItem = new Item("A99", 0.5m);

            Assert.Equal("A99", newItem.SKU);
        }
    }
}