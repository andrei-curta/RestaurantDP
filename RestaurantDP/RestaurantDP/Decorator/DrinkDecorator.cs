using RestaurantDP.Factory;

namespace RestaurantDP.Decorator
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