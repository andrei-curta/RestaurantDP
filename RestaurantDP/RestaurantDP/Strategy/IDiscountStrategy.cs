using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantDP.Strategy
{
   public interface IDiscountStrategy
    {
        string Name { get; }
        double GetDiscountPercetange();
    }
}
