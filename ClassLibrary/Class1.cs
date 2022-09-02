namespace ClassLibrary
{
    public class Checkout
        {
        private List<Item> items = new List<Item>();
        public List<Offers> offersList = new List<Offers>();
        public decimal Total()
            {
            decimal total = 0;
            List<TransactionLines> transactionLines = items
                            .GroupBy(p => p.SKU)
                            .Select(tl => new TransactionLines
                            {
                                ProductSKU = tl.First().SKU,
                                ProductUnitPrice = tl.First().Price,
                                ProductQuantity = tl.Count(),
                            }).ToList(); //group item by sku in a transaction

            //foreach(var item in items)
            //{
            //    total = total + item.Price;
            //}
            foreach (var product in transactionLines)
            {
                if (hasOffer(product.ProductSKU))
                {
                    int totalQuantity = product.ProductQuantity;
                    decimal unitPrice = product.ProductUnitPrice;
                    decimal ProductOfferPrice = GetOfferPrice(product.ProductSKU);
                    int ProductOfferQuantity = GetOfferQuantity(product.ProductSKU);
                    int PackQuantity = (totalQuantity - (totalQuantity % ProductOfferQuantity)) / ProductOfferQuantity;
                    int singleQuantity = totalQuantity % ProductOfferQuantity;

                    total = total + PackQuantity * ProductOfferPrice + singleQuantity * unitPrice;
                }
                else
                {

                    total = total + product.ProductQuantity * product.ProductUnitPrice;

                }

            }

            return total;
        }

        public void Scan(Item item)
            {
            items.Add(item);

            }

        public void SetUpOffer(Offers offer)
            {
            offersList.Add(offer);
            }

        public bool hasOffer(string sku)//check if a product has offer 
        {
            List<string> listSKU = offersList.Select(c => c.SKU).ToList();
            if (listSKU.Contains(sku))
            {
                return true;

            }
            else return false;
        }

        public decimal GetOfferPrice(string sku)
        {
            var offerPrice =
             (from item in offersList
              where item.SKU == sku
              select new { item.OfferPrice }).Single();
            return offerPrice.OfferPrice;
        }

        public int GetOfferQuantity(string sku)
        {
            var offerQuantity =
                (from item in offersList
                 where item.SKU == sku
                 select new { item.OfferQuantity }).Single();
            return offerQuantity.OfferQuantity;
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

    public class TransactionLines
    {

        public string ProductSKU { get; set; }
        public decimal ProductUnitPrice { get; set; }
        public int ProductQuantity { get; set; }
    }


}