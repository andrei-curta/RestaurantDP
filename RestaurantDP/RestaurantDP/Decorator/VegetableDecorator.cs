using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantDP
{
    class VegetableDecorator : BurgerDecorator
    {
        public VegetableDecorator(IBurger burger) : base(burger)
        {
            _decoratedBurger.ExtraIngredientsType = EExtraIngredients.VEGETABLE;
        }

        public override void AddExtraIngredient()
        {
            _decoratedBurger.Price += 2;
        }
    }
}
