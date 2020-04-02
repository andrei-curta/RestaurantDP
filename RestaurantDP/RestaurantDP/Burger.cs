namespace RestaurantDP
{
    public abstract class Burger
    {
        private int _id;

        public string Name { get; set; }
        public float Price { get; set; }
        public abstract EBurgerType Type { get; set; }

        protected Burger(int id, string name, float price)
        {
            _id = id;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return ($"{Name}, {Price}$");
        }
    }
}