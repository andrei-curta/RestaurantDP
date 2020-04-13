using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantDP.Strategy
{
    public class LoyaltyDicount : IDiscountStrategy
    {
        public string Name => nameof(LoyaltyDicount);

        public double GetDiscountPercetange()
        {
            return 0.25;
        }
    }
}
