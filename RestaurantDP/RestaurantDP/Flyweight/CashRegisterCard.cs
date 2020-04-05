namespace RestaurantDP.Flyweight
{
    public class CashRegisterCard : CashRegister
    {
        public CashRegisterCard()
        {
            UnsharedMoney = CreateNewMoney();
        }

        public sealed override Money CreateNewMoney()
        {
            return new CardMoney();
        }
         
        public override bool IsSharedValue(float value)
        {
            return false;
        }
    }
}