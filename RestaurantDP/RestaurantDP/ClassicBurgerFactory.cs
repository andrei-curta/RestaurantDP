namespace RestaurantDP
{
    public class ClassicBurgerFactory : Kitchen
    {
        public override Burger GetBurger(string name, float price)
        {
            return new ClassicBurger(LastId++, name, price);
        }
    }
}