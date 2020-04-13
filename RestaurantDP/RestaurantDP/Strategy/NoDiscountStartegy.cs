using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantDP.Strategy
{
    public class NoDiscountStartegy : IDiscountStrategy
    {
        public string Name => nameof(NoDiscountStartegy);

        public double GetDiscountPercetange()
        {
            return 0;
        }
    }
}
