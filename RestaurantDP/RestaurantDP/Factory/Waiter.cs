using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantDP.Decorator;
using RestaurantDP.Flyweight;

namespace RestaurantDP.Factory
{
    public class Waiter
    {
        private readonly Dictionary<int, BurgerDecorator> _orderedBurgers;
        private readonly Dictionary<int, BurgerDecorator> _premadeBurgers;   //???
        private readonly CashRegisterCoin _cashRegisterCoin;
        private readonly CashRegisterPaper _cashRegisterPaper;
        private readonly CashRegisterCard _cashRegisterCard;

        public Waiter()
        {
            _orderedBurgers = new Dictionary<int, BurgerDecorator>();
            _premadeBurgers = new Dictionary<int, BurgerDecorator>();
            _cashRegisterCoin = new CashRegisterCoin();
            _cashRegisterPaper = new CashRegisterPaper();
            _cashRegisterCard = new CashRegisterCard();
        }

        private static EMoneyType GetMoneyType()
        {
            Console.WriteLine("How would you like to pay: \n" +
                              "1 -> Paper\n" +
                              "2 -> Coin\n" +
                              "3 -> Card");
            var intTemp = Convert.ToInt32(Console.ReadLine());
            switch (intTemp)
            {
                case 1:
                    return EMoneyType.Paper;
                case 2:
                    return EMoneyType.Coin;
                case 3:
                    return EMoneyType.Card;
                default:
                    throw new Exception("Invalid type of money!");
            }
        }

        public int OrderBurger(string name, float price, EBurgerType burgerType, EExtraIngredients extraIngredients = EExtraIngredients.BASIC)
        {
            Kitchen kitchen;
            switch (burgerType)
            {
                case EBurgerType.Classic:
                    {
                        kitchen = new ClassicBurgerFactory();
                        var burger = kitchen.GetBurger(name, price);
                        var decoratedBurger = AddExtraIngredients(burger, extraIngredients);

                        _orderedBurgers.Add(Kitchen.LastId, decoratedBurger);
                        CashIn(decoratedBurger.Price, GetMoneyType());
                        GetTotalCash();
                        Console.WriteLine($"Classic burger was ordered : {decoratedBurger.ToString()} => ID {Kitchen.LastId}");
                        return Kitchen.LastId;
                    }
                case EBurgerType.Deluxe:
                    {
                        kitchen = new DeluxeBurgerFactory();
                        var burger = kitchen.GetBurger(name, price);
                        var decoratedBurger = AddExtraIngredients(burger, extraIngredients);

                        _orderedBurgers.Add(Kitchen.LastId, decoratedBurger);
                        CashIn(decoratedBurger.Price, GetMoneyType());
                        GetTotalCash();
                        Console.WriteLine($"Deluxe burger was ordered : {decoratedBurger.ToString()} => ID {Kitchen.LastId}");
                        return Kitchen.LastId;
                    }
                default:
                    return -1;
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

        private void CashIn(float value, EMoneyType moneyType)
        {
            switch (moneyType)
            {
                case EMoneyType.Card:
                    _cashRegisterCard.CashIn(value);
                    break;

                case EMoneyType.Coin:
                    _cashRegisterCoin.CashIn(value);
                    break;

                case EMoneyType.Paper:
                    _cashRegisterPaper.CashIn(value);
                    break;
            }
        }

        private void CashOut(float value, EMoneyType moneyType)
        {
            switch (moneyType)
            {
                case EMoneyType.Card:
                    _cashRegisterCard.CashOut(value);
                    break;
                case EMoneyType.Coin:
                    _cashRegisterCoin.CashOut(value);
                    break;
                case EMoneyType.Paper:
                    _cashRegisterPaper.CashOut(value);
                    break;
            }
        }

        private void GetTotalCash()
        {
            var sum = _cashRegisterCard.GetTotalCash() + _cashRegisterCoin.GetTotalCash() + _cashRegisterPaper.GetTotalCash();
            Console.WriteLine($"Coin: {_cashRegisterCoin.GetTotalCash()}  Paper: {_cashRegisterPaper.GetTotalCash()}  Card: {_cashRegisterCard.GetTotalCash()}");
            Console.WriteLine("Total cash = " + sum);
        }
    }
}