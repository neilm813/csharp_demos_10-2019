using System;
using System.Collections.Generic;

namespace GroceryStoreExample
{
    public class Shopper
    {
        public string Name { get; set; }
        private decimal _budget;
        Dictionary<string, int> ShoppingList { get; set; }
        // needs to be public so grocery store can access cart during checkout
        public List<Product> ShoppingCart { get; set; } = new List<Product>();

        private GroceryStore _currentStore = null;

        public Shopper(string name, decimal budget, Dictionary<string, int> shoppingList)
        {
            Name = name;
            _budget = budget;
            ShoppingList = shoppingList;
        }

        public void EnterStore(GroceryStore store)
        {
            _currentStore = store;
            store.ShopperEntering(this);
        }

        public void AddGroceriesToCart()
        {
            foreach (KeyValuePair<string, int> entry in ShoppingList)
            {
                string desiredItem = entry.Key;
                int desiredQuantity = entry.Value;

                foreach (Product prod in _currentStore.Products)
                {
                    if (desiredItem == prod.Name)
                    {
                        for (int i = 0; i < desiredQuantity; i++)
                        {
                            ShoppingCart.Add(prod);
                        }
                    }
                }
            }
            Console.WriteLine($"Your shopping cart contains: {string.Join(", ", ShoppingCart)}");

        }

        private void ExitStore()
        {
            _currentStore.ShopperExiting(this);
            _currentStore = null;
        }

        public void Checkout()
        {
            decimal totalBill = _currentStore.BillShopper(this);
            Console.WriteLine($"Bill: {totalBill}, {Name}'s Budget: {_budget}");

            if (totalBill > _budget)
            {
                Console.WriteLine($"I got too many groceries. -{Name}");
            }
            else
            {
                _budget -= totalBill;
                Console.WriteLine($"Remaining Budget: {_budget}");
                _currentStore.ReceivePayment(totalBill);
                ExitStore();
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}