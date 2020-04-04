namespace RestaurantDP
{
    public interface IBurger
    {
        EExtraIngredients ExtraIngredientsType { get; set; }
        string Name { get; set; }
        float Price { get; set; }
        EBurgerType Type { get; set; }

        void AddExtraIngredients();
        void Prepare(string name, float price);
        string ToString();
    }
}