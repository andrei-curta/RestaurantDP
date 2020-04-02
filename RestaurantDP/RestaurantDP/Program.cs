using System;

namespace RestaurantDP
{
    class Program
    {
        static void Main(string[] args)
        {
            var waiter = new Waiter();

            waiter.OrderBurger(Constants.ClassicBurgerName, Constants.ClassicBurgerPrice, EBurgerType.Classic);
            waiter.OrderBurger(Constants.DeluxeBurgerName, Constants.DeluxeBurgerPrice, EBurgerType.Deluxe);
            waiter.OrderBurger(Constants.ClassicBurgerName, Constants.ClassicBurgerPrice, EBurgerType.Classic);

            Console.WriteLine("\nOrdered burgers:");
            waiter.DisplayBurgers();

            waiter.SellBurger(0);
            Console.WriteLine("\nAfter selling first burger.");
            waiter.DisplayBurgers();
        }
    }
}