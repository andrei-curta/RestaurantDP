using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantDP
{
    public class Waiter
    {
        private readonly Dictionary<int, Burger> _orderedBurgers;
        private readonly Dictionary<int, Burger> _premadeBurgers;   //???

        public Waiter()
        {
            _orderedBurgers = new Dictionary<int, Burger>();
            _premadeBurgers = new Dictionary<int, Burger>();
        }

        public int OrderBurger(string name, float price, EBurgerType burgerType)
        {
            Kitchen kitchen;
            switch (burgerType)
            {
                case EBurgerType.Classic:
                {
                    kitchen = new ClassicBurgerFactory();
                    _orderedBurgers.Add(Kitchen.LastId, kitchen.GetBurger(name, price));
                    Console.WriteLine($"Classic burger was ordered : {name}, {price} => ID {Kitchen.LastId}");
                    return Kitchen.LastId;
                }
                case EBurgerType.Deluxe:
                {
                    kitchen = new DeluxeBurgerFactory();
                    _orderedBurgers.Add(Kitchen.LastId, kitchen.GetBurger(name, price));
                    Console.WriteLine($"Deluxe burger was ordered : {name}, {price} => ID {Kitchen.LastId}");
                    return Kitchen.LastId;
                }
                default:
                    return -1;
            }
        }

        public Burger SellBurger(int id)
        {
            var burgerToBeSold = _orderedBurgers.FirstOrDefault(car => car.Key.Equals(id)).Value;
            if (burgerToBeSold == null)
            {
                Console.WriteLine("This burger does not exists.");
                return null;
            }
            _orderedBurgers.Remove(id);
            Console.WriteLine($"A burger was sold : {burgerToBeSold.Name}, {burgerToBeSold.Price}");
            return burgerToBeSold;
        }

        public void DisplayBurgers()
        {
            foreach (var burger in _orderedBurgers.Values)
                Console.WriteLine(burger);
        }
    }
}