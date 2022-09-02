using ClassLibrary;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        private readonly Item itemA99 = new("A99", 0.5m);


        [Fact]
        public void Test1()
        {
            Assert.True(true);//testing the test project 
        }

        [Fact]
        public void createitem()
        {
            Item newItem = itemA99;

            Assert.Equal("A99", newItem.SKU);//testing object creation
        }

        [Fact]
        public void ScanItem()
        {
            var checkout = new Checkout();
            var item = itemA99;

            Assert.Throws<Exception>(
                () => checkout.Scan(item));//negative test for scan item
        }


        [Fact]
        public void TotalPrice()
        {
            var checkout = new Checkout();
            var item1 = itemA99;

            checkout.Scan(item1);

            Assert.Equal(0.5m, checkout.Total());
        }

    }
}