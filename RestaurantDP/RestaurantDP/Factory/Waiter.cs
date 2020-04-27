using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Repository;
using RestaurantDP.Bridge;
using RestaurantDP.Decorator;
using RestaurantDP.Flyweight;
using RestaurantDP.Strategy;
using RestaurantDP.Template;
using RestaurantDP.Visitor;

namespace RestaurantDP.Factory
{
    public class Waiter
    {
        private readonly Dictionary<int, BurgerDecorator> _orderedBurgers;
        private readonly CashRegisterCoin _cashRegisterCoin;
        private readonly CashRegisterPaper _cashRegisterPaper;
        private readonly CashRegisterCard _cashRegisterCard;

        public Waiter()
        {
            _orderedBurgers = new Dictionary<int, BurgerDecorator>();
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


        public void  GetUserOption(User client)
        {
            while (true)
            {
                Console.WriteLine("How can I help you? \n" +
                              "1 -> Place order");

                if (client.Order.Products.Count > 0)
                {
                    Console.WriteLine("2 -> Pay Reciept\n");
                }
                else
                    Console.WriteLine();
                
                int intTemp = Convert.ToInt32(Console.ReadLine());
                switch (intTemp)
                {
                    case 1:
                        PlaceOrder(client);
                        break;
                    case 2:
                        PayReceipt(client);
                        return;
                    default:
                        Console.WriteLine("Invalid request");
                        break;
                }
            }
        }

        private void PlaceOrder(User client)
        {
            int intTemp = 0;
            EBurgerType eBurgerType = EBurgerType.Classic;

            do
            {
                Console.WriteLine("What would you like to eat?: \n" +
                              "1 -> ClassicBurger\n" +
                              "2 -> Deluxe Burger\n");
                intTemp = Convert.ToInt32(Console.ReadLine());
                switch (intTemp)
                {
                    case 1:
                        eBurgerType = EBurgerType.Classic;
                        break;
                    case 2:
                        eBurgerType = EBurgerType.Deluxe;
                        break;
                    default:
                        Console.WriteLine("We don't have that type of burger. Maybe try something from the menu?");
                        break;
                }
            } while (intTemp != 1 && intTemp != 2);

            Console.WriteLine("Excellent choice! Do you want to add something extra to the burger? \n" +
                              "1 -> Yes\n" +
                              "2 -> No\n");
            intTemp = Convert.ToInt32(Console.ReadLine());


            switch (intTemp)
            {
                case 1:
                    Console.WriteLine("What kind of extra would you like? \n" +
                                      "1 -> Drink\n" +
                                      "2 -> Sauce\n" +
                                      "3 -> Vegetable");

                    int extraOption = 0;
                    do
                    {
                        try
                        {
                            extraOption = Convert.ToInt32(Console.ReadLine());
                            switch (extraOption)
                            {
                                case 1:
                                    FulfillOrder(eBurgerType, client, EExtraIngredients.DRINK);
                                    break;
                                case 2:
                                    FulfillOrder(eBurgerType, client, EExtraIngredients.SAUCE);
                                    break;
                                case 3:
                                    FulfillOrder(eBurgerType, client, EExtraIngredients.VEGETABLE);
                                    break;
                                default:
                                    Console.WriteLine("Sorry, we're not adding weird stuff to our burgers since the coronavirus outbreak");
                                    break;
                            }
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    } while (intTemp != 1 && intTemp != 2 && intTemp != 3);

                    break;
                case 2:
                    FulfillOrder(eBurgerType, client);
                    break;
                default:
                    Console.WriteLine("I'll take that as a no.");
                    FulfillOrder(eBurgerType, client);
                    break;
            }

        } 

        private int FulfillOrder(EBurgerType burgerType, User client, EExtraIngredients extraIngredients = EExtraIngredients.BASIC)
        {
            string name = "";
            float price = 0;
            if (burgerType == EBurgerType.Classic)
            {
                name = Constants.ClassicBurgerName;
                price = Constants.ClassicBurgerPrice;
            }

            if (burgerType == EBurgerType.Deluxe)
            {
                name = Constants.DeluxeBurgerName;
                price = Constants.DeluxeBurgerPrice;
            }

            Kitchen kitchen;


            switch (burgerType)
            {
                case EBurgerType.Classic:
                    {
                        kitchen = new ClassicBurgerFactory();
                        var burger = kitchen.GetBurger(name, price);
                        var decoratedBurger = AddExtraIngredients(burger, extraIngredients);

                        _orderedBurgers.Add(Kitchen.LastId, decoratedBurger);
                        Console.WriteLine($"Classic burger was ordered : {decoratedBurger.ToString()} => ID {Kitchen.LastId}");
                        Console.WriteLine("It will be serverd in a short time...");
                        ServeBurger(client, Kitchen.LastId);

                        return Kitchen.LastId;
                    }
                case EBurgerType.Deluxe:
                    {
                        kitchen = new DeluxeBurgerFactory();
                        var burger = kitchen.GetBurger(name, price);
                        var decoratedBurger = AddExtraIngredients(burger, extraIngredients);

                        _orderedBurgers.Add(Kitchen.LastId, decoratedBurger);

                        Console.WriteLine($"Deluxe burger was ordered : {decoratedBurger.ToString()} => ID {Kitchen.LastId}");
                        ApplicationMode.Instance.sendAction($"Deluxe burger was ordered : {decoratedBurger.ToString()} => ID {Kitchen.LastId}");
                        Console.WriteLine("It will be serverd in a short time...");
                        ServeBurger(client, Kitchen.LastId);

                        return Kitchen.LastId;
                    }
                default:
                    return -1;
            }
        }

        private BurgerDecorator ServeBurger(User client, int burgerId)
        {
            Thread.Sleep(2000);
            var burgerToBeSold = _orderedBurgers.FirstOrDefault(burger => burger.Key.Equals(burgerId)).Value;
            if (burgerToBeSold == null)
            {
                Console.WriteLine("This burger does not exists.");
                return null;
            }

            client.Order.AddProduct(_orderedBurgers[burgerId]);          
            _orderedBurgers.Remove(burgerId);

            Console.WriteLine($"A {burgerToBeSold.Name} was serverd to {client.Name}. Price: {burgerToBeSold.Price}\n");
            ApplicationMode.Instance.sendAction($"A {burgerToBeSold.Name} was serverd to {client.Name}. Price: {burgerToBeSold.Price}\n");
            return burgerToBeSold;
        }

        void PayReceipt(User client)
        {
            if (client.Order.Products.Count == 0)
            {
                Console.WriteLine("You have not ordered yet!");
            }

            ClientReport clientReport = new ClientReport();
            clientReport.Visit(client.Order);

            float totalPrice = clientReport.TotalPrice;

            if(Enum.IsDefined(typeof(EOfferType), client.OfferType))
            {
                StrategyContext strategyContext = new StrategyContext(totalPrice);

                totalPrice = (float) strategyContext.ApplyStrategy(client.OfferType);
            }

            totalPrice = (float)Math.Round(totalPrice, 2);

            CashIn(totalPrice, GetMoneyType());
            GetTotalCash();

            DataExporter exporter = null;

            Console.WriteLine("In what format do you want your reciept? \n" +
                              "1 -> txt\n" +
                              "2 -> pdf\n");

            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    exporter = new Txt_Bill_Exporter();
                    break;
                case 2:
                    exporter = new PDF_Bill_Exporter();
                    break;
                default:
                    exporter = new Txt_Bill_Exporter();
                    break;
            }

            ApplicationMode.Instance.sendAction($"Client {client.Name} paid order: {totalPrice}");

            List<BurgerDecorator> burgers = client.Order.Products;
            exporter.ExportFormatedData($"{client.Name}'s reciept", burgers, $"Total: {totalPrice}");
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
            Console.WriteLine($"Coin: {Math.Round(_cashRegisterCoin.GetTotalCash(), 2)}  Paper: {Math.Round(_cashRegisterPaper.GetTotalCash(), 2)}  Card: {Math.Round(_cashRegisterCard.GetTotalCash(),2)}");
            Console.WriteLine("Total cash = " + Math.Round(sum, 2));
        }
    }
}