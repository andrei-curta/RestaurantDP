namespace RestaurantDP.Flyweight
{
    public class CashRegisterPaper : CashRegister
    {
        public CashRegisterPaper()
        {
            UnsharedMoney = CreateNewMoney();
        }

        public sealed override Money CreateNewMoney()
        {
            return new PaperMoney();
        }

        public override bool IsSharedValue(float value)
        {
            return PaperMoney.IsSharedMoney(value);
        }
    }
}