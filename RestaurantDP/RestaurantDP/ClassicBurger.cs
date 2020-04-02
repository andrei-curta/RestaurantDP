namespace RestaurantDP
{
    public class ClassicBurger : Burger
    {
        public sealed override EBurgerType Type { get; set; }

        public ClassicBurger(int id, string name, float price) : base(id, name, price)
        {
            Type = EBurgerType.Classic;
        }
    }
}