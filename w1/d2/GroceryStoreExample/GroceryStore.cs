using System;
using System.Collections.Generic;

namespace GroceryStoreExample
{
    public class GroceryStore
    {
        private List<Shopper> Shoppers = new List<Shopper>();
        private List<Product> _products;
        // Products can be get from outside, but not re-assigned
        // the .AsReadOnly is needed to also prevent .Add and such
        // Could also have the prop type be IEnumerable which has no methods
        // by which to mutate the list on it
        public IList<Product> Products
        {
            get { return _products.AsReadOnly(); }
        }
        public string Name;
        private decimal _till = 0;

    public GroceryStore(string name)
        {
            Name = name;
            _products = new List<Product>
            {
                new Product("Milk", 4.99m),
                new Product("Royal Jelly", 10.95m),
                new Product("Healing Crystal", 66.6m),
                new Product("Cactus Jerkey", 5.95m),
                new Product("Fruit Flavored Fruitless Chews", 1.50m),
            };
        }

        public void ShopperEntering(Shopper newShopper)
        {
            Shoppers.Add(newShopper);
            DisplayShoppers();
            Console.WriteLine($"Hi {newShopper.Name}, welcome to {Name}");
        }

        public void ShopperExiting(Shopper shopper)
        {
            Shoppers.Remove(shopper);
            DisplayShoppers();
            Console.WriteLine($"Goodbye {shopper.Name}");
        }

        public void DisplayShoppers()
        {
            Console.WriteLine(String.Join(", ", Shoppers));

        }
        public decimal BillShopper(Shopper shopper)
        {
            decimal totalBill = 0;

            foreach (Product prod in shopper.ShoppingCart)
            {
                totalBill += prod.Price;
            }
            Console.WriteLine($"{Name} says, \"{shopper.Name}, your bill is: {totalBill}\"");
            return totalBill;
        }

        public void ReceivePayment(decimal shopperPayment)
        {
            _till += shopperPayment;
            Console.WriteLine($"{Name}'s till has ${_till}.");
        }
    }
}