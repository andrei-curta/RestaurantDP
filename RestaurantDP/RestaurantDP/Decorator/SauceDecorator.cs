using RestaurantDP.Factory;

namespace RestaurantDP.Decorator
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