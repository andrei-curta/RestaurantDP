namespace RestaurantDP.Factory
{
    public abstract class Kitchen
    {
        public static int LastId { get; set; } = 0;

        public abstract Burger GetBurger(string name, float price);
    }
}