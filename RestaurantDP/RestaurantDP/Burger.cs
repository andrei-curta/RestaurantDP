namespace RestaurantDP
{
    public abstract class Burger : IBurger
    {
        private int _id;

        public string Name { get; set; }
        public float Price { get; set; }
        public abstract EBurgerType Type { get; set; }
        public EExtraIngredients ExtraIngredientsType { get; set; } = EExtraIngredients.BASIC;


        protected Burger(int id, string name, float price)
        {
            _id = id;
            Name = name;
            Price = price;
        }

        public void Prepare(string name, float price)
        {
            Name = name;
            Price = price;
        }

        public void AddExtraIngredients()
        {
            System.Console.WriteLine("Decorate your burger with our extra offers to add extra ingredients");
        }
            

        public override string ToString()
        {
            return ($"{Name}, Extra: {ExtraIngredientsType} {Price}$");
        }
    }
}