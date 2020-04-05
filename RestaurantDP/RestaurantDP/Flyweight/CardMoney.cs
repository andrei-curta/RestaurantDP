namespace RestaurantDP.Flyweight
{
    public class CardMoney : Money
    {
        public override EMoneyType GetMoneyType()
        {
            return EMoneyType.Card;
        }
    }
}