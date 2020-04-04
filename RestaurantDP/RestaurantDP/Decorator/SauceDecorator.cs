using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantDP
{
    class SauceDecorator : BurgerDecorator 
    {
        public SauceDecorator(IBurger burger) : base(burger)
        {
            _decoratedBurger.ExtraIngredientsType = EExtraIngredients.SAUCE;
        }

        public override void AddExtraIngredient()
        {
            _decoratedBurger.Price += 0.5f;
        }
    }
}
