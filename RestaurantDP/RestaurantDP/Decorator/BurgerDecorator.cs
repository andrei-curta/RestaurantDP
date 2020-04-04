using RestaurantDP.Factory;

namespace RestaurantDP.Decorator
{
    public abstract class BurgerDecorator 
    {
        protected IBurger _decoratedBurger;

        public string Name { get => _decoratedBurger.Name; }
        public float Price { get => _decoratedBurger.Price; }

        protected BurgerDecorator(IBurger burger)
        {
            _decoratedBurger = burger;
            AddExtraIngredient();
        }

        public void Prepare(string name, float price)
        {
            _decoratedBurger.Prepare(name, price);
        }

        public abstract void AddExtraIngredient();

        public override string ToString()
        {
            return _decoratedBurger.ToString();
        }
    }
}