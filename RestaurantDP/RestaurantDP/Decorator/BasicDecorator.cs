using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantDP
{
    class BasicDecorator : BurgerDecorator
    {
        public BasicDecorator(IBurger burger) : base(burger)
        {
            _decoratedBurger.ExtraIngredientsType = EExtraIngredients.BASIC;
        }

        public override void AddExtraIngredient()
        {
            
        }
    }
}
