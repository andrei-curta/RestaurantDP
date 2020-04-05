namespace RestaurantDP.Flyweight
{
    public class PaperMoney : Money
    {
        public override EMoneyType GetMoneyType()
        {
            return EMoneyType.Paper;
        }

        public static bool IsSharedMoney(float value)
        {
            return (value.Equals(1f)||value.Equals(5f)||
                    value.Equals(10f)||value.Equals(50f)||
                    value.Equals(100f)||value.Equals(200f)||
                    value.Equals(500f));
        }
    }
}