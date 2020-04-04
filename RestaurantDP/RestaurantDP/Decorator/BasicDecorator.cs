using RestaurantDP.Factory;

namespace RestaurantDP.Decorator
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