namespace RestaurantDP.Flyweight
{
    public class CoinMoney : Money
    {
        public override EMoneyType GetMoneyType()
        {
            return EMoneyType.Coin;
        }

        public static bool IsSharedMoney(float value)
        {
            return (value.Equals(0.01f) || value.Equals(0.05f) ||
                    value.Equals(0.1f) || value.Equals(0.5f));
        }
    }
}