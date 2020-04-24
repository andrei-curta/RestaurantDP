using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace RestaurantDP.Strategy
{
   public class StrategyContext
    {
        double price;

        Dictionary<string, IDiscountStrategy> strategyContext = new Dictionary<string, IDiscountStrategy>();

        public StrategyContext(double price)
        {
            this.price = price;

            strategyContext.Add(nameof(NoDiscountStartegy), new NoDiscountStartegy());

            strategyContext.Add(nameof(LoyaltyDicount), new LoyaltyDicount());

            strategyContext.Add(nameof(StudentDiscount), new StudentDiscount());
        }

        public void ApplyStrategy(IDiscountStrategy strategy)
        {
            Console.WriteLine("Price before offer: " + price);

            double finalPrice = price - (price * strategy.GetDiscountPercetange());

            Console.WriteLine("Price after offer: " + finalPrice);
        }

        public double ApplyStrategy(EOfferType offerType)
        {
            var strategy = GetStrategy(offerType);

            Console.WriteLine($"You get {strategy.GetType().Name}");

            Console.WriteLine("Price before offer: " + price);

            double finalPrice = price - (price * strategy.GetDiscountPercetange());

            Console.WriteLine("Price after offer: " + finalPrice);

            return finalPrice;
        }

        public IDiscountStrategy GetStrategy(EOfferType offerType)
        {
            if (offerType == "Loyal")
            {
                return strategyContext[nameof(LoyaltyDicount)];
            }
            else if(offerType == "Student")
            {
                return strategyContext[nameof(StudentDiscount)];
            }
            return strategyContext[nameof(NoDiscountStartegy)];
        }
    }
}
