namespace ClassLibrary
{
    public class Checkout
        {
        private List<Item> items = new List<Item>();
        public decimal Total()
            {
            decimal total = 0;
            foreach(var item in items)
            {
                total = total + item.Price;
            }
                return total;
            }

            public void Scan(Item item)
            {
            items.Add(item);

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


    public class Offers
    {
        public Offers(string sku, int offerQuantity, decimal offerPrice)
        {
            SKU = sku;
            OfferQuantity = offerQuantity;
            OfferPrice = offerPrice;
        }
        public string SKU { get; }
        public int OfferQuantity { get; }
        public decimal OfferPrice { get; }
    }

}