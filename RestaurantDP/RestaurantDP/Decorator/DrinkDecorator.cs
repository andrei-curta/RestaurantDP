using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantDP
{
    class DrinkDecorator : BurgerDecorator
    {
        public DrinkDecorator(IBurger burger) : base(burger)
        {
            _decoratedBurger.ExtraIngredientsType = EExtraIngredients.DRINK;
        }

        public override void AddExtraIngredient()
        {
            _decoratedBurger.Price += 6;
        }
    }
}
