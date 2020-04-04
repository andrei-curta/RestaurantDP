using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantDP
{
    public class Waiter
    {
        private readonly Dictionary<int, BurgerDecorator> _orderedBurgers;
        private readonly Dictionary<int, BurgerDecorator> _premadeBurgers;   //???

        public Waiter()
        {
            _orderedBurgers = new Dictionary<int, BurgerDecorator>();
            _premadeBurgers = new Dictionary<int, BurgerDecorator>();
        }

        public int OrderBurger(string name, float price, EBurgerType burgerType, EExtraIngredients extraIngredients = EExtraIngredients.BASIC)
        {
            Kitchen kitchen;
            switch (burgerType)
            {
                case EBurgerType.Classic:
                {
                    kitchen = new ClassicBurgerFactory();
                    Burger burger = kitchen.GetBurger(name, price);
                    BurgerDecorator decoratedBurger = AddExtraIngredients(burger, extraIngredients);

                    _orderedBurgers.Add(Kitchen.LastId, decoratedBurger);
                    Console.WriteLine($"Classic burger was ordered : {decoratedBurger.ToString()} => ID {Kitchen.LastId}");
                    return Kitchen.LastId;
                }
                case EBurgerType.Deluxe:
                {
                    kitchen = new DeluxeBurgerFactory();
                    Burger burger = kitchen.GetBurger(name, price);
                    BurgerDecorator decoratedBurger = AddExtraIngredients(burger, extraIngredients);

                    _orderedBurgers.Add(Kitchen.LastId, decoratedBurger);
                    Console.WriteLine($"Deluxe burger was ordered : {decoratedBurger.ToString()} => ID {Kitchen.LastId}");
                    return Kitchen.LastId;
                }
                default:
                    return -1;
            }
        }

        private BurgerDecorator AddExtraIngredients(IBurger burger, EExtraIngredients extraIngredients)
        {
            switch (extraIngredients)
            {
                case EExtraIngredients.BASIC:
                {
                    return new BasicDecorator(burger);
                }
                case (EExtraIngredients.DRINK):
                {
                    return new DrinkDecorator(burger);
                }
                case (EExtraIngredients.SAUCE):
                {
                    return new SauceDecorator(burger);
                }
                case (EExtraIngredients.VEGETABLE):
                {
                    return new VegetableDecorator(burger);
                }
                default:
                    return null;
            }
        }

        public BurgerDecorator SellBurger(int id)
        {
            var burgerToBeSold = _orderedBurgers.FirstOrDefault(burger => burger.Key.Equals(id)).Value;
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