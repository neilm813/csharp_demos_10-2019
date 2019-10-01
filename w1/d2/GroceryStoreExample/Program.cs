using System;
using System.Collections.Generic;

namespace GroceryStoreExample
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
                1. Create a few grocery strores
                2. Create a few shoppers with a shopping list
                3. Have shoppers enter stores of their choosing
                    - when shopper enters store, store should print a greeting
                4. Have store print list of shoppers
                5. Add items from their list to their cart
                    - print shopping cart items
                6. Shopper checkout and pay
                    - shopper must have enough money
                        - shopper says they got too many items if not enough money
                    - shopper exits store after checkout
                    - store prints goodbye to shopper
                    - store should print list of shopper names
            */

            GroceryStore albs = new GroceryStore("Albertsons");

            Shopper shopper1 = new Shopper("Neil", 300m, new Dictionary<string, int>() {
                {"Royal Jelly", 2},
                { "Cactus Jerkey", 1 },
                { "Soda", 3 },
            });

            Shopper shopper2 = new Shopper("Jon", 10, new Dictionary<string, int>() {
                {"Milk", 2},
                { "Healing Crystal", 1 },
            });


            shopper1.EnterStore(albs);
            shopper2.EnterStore(albs);

            shopper1.AddGroceriesToCart();
            shopper1.Checkout();
            
            shopper2.AddGroceriesToCart();
            shopper2.Checkout();
        }   
    }
}
