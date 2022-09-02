namespace ClassLibrary
{
        public class Checkout
        {
            public decimal Total()
            {
                return 0m;
            }

            public void Scan(Item item)
            {

            }
        }

    public class Item
    {
        public Item(string sku, decimal price)
        {
            SKU = sku;
            Price = price;
        }

        public string SKU { get; set; }
        public decimal Price { get; set; }
    }

}