using ClassLibrary;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        private readonly Item itemA99 = new("A99", 0.5m);
        private readonly Item itemB15 = new("B15", 0.3m);
        private readonly Item itemC40 = new("C40", 0.6m);
        readonly Offers offerA99 = new("A99", 3, 1.3m);
        readonly Offers offerB15 = new("B15", 2, 0.45m);


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
            var item2 = itemB15;
            var item3 = itemC40;

            checkout.Scan(item1);
            checkout.Scan(item2);
            checkout.Scan(item3); 

            Assert.Equal(1.4m, checkout.Total());
        }

    }
}