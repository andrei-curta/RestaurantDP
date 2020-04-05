namespace RestaurantDP.Flyweight
{
    public abstract class Money
    {
        public float TotalCashValue { get; set; } = 0.0f;

        public abstract EMoneyType GetMoneyType();
    }
}