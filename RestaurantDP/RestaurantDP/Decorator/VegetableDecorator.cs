using RestaurantDP.Factory;

namespace RestaurantDP.Decorator
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