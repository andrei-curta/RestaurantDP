namespace RestaurantDP.Flyweight
{
    public class CashRegisterCoin : CashRegister
    {
        public CashRegisterCoin()
        {
            UnsharedMoney = CreateNewMoney();
        }

        public sealed override Money CreateNewMoney()
        {
            return new CoinMoney();
        }

        public override bool IsSharedValue(float value)
        {
            return CoinMoney.IsSharedMoney(value);
        }
    }
}