using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantDP.Strategy
{
    public class StudentDiscount : IDiscountStrategy
    {
        public string Name => nameof(StudentDiscount);

        public double GetDiscountPercetange()
        {
            return 0.15;
        }
    }
}
