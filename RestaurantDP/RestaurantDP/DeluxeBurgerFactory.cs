namespace RestaurantDP
{
    public class DeluxeBurgerFactory : Kitchen
    {
        public override Burger GetBurger(string name, float price)
        {
            return new DeluxeBurger(LastId++, name, price);
        }
    }
}