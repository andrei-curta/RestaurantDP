namespace RestaurantDP.Factory
{
    public class DeluxeBurger : Burger
    {
        public sealed override EBurgerType Type { get; set; }

        public DeluxeBurger(int id, string name, float price) : base(id, name, price)
        {
            Type = EBurgerType.Deluxe;
        }
    }
}