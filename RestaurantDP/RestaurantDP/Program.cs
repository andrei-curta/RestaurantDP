using System;
using RestaurantDP.Decorator;
using RestaurantDP.Factory;

namespace RestaurantDP
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var waiter = new Waiter();

                waiter.OrderBurger(Constants.ClassicBurgerName, Constants.ClassicBurgerPrice, EBurgerType.Classic);
                waiter.OrderBurger(Constants.DeluxeBurgerName, Constants.DeluxeBurgerPrice, EBurgerType.Deluxe);
                waiter.OrderBurger(Constants.ClassicBurgerName, Constants.ClassicBurgerPrice, EBurgerType.Classic);
                waiter.OrderBurger(Constants.ClassicBurgerName, Constants.ClassicBurgerPrice, EBurgerType.Classic,
                    EExtraIngredients.DRINK);

                Console.WriteLine("\nOrdered burgers:");
                waiter.DisplayBurgers();

                waiter.SellBurger(1);
                Console.WriteLine("\nAfter selling first burger.");
                waiter.DisplayBurgers();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}