using System.Collections.Generic;
using System.Linq;

namespace RestaurantDP.Flyweight
{
    public abstract class CashRegister
    {
        private readonly Dictionary<float, Money> _sharedMoneyMap;
        protected Money UnsharedMoney;

        protected CashRegister()
        {
            _sharedMoneyMap = new Dictionary<float, Money>();
        }

        public abstract Money CreateNewMoney();
        public abstract bool IsSharedValue(float value);

        protected Money Lookup(float value)
        {
            if (_sharedMoneyMap.ContainsKey(value))
            {
                _sharedMoneyMap.TryGetValue(value, out var returnVal1);
                return returnVal1;
            }

            if (!IsSharedValue(value)) return UnsharedMoney;

            _sharedMoneyMap.Add(value, CreateNewMoney());
            _sharedMoneyMap.TryGetValue(value, out var returnVal2);
            return returnVal2;
        }

        public void CashIn(float value)
        {
            var money = Lookup(value);
            money.TotalCashValue += value;
        }

        public void CashOut(float value)
        {
            var money = Lookup(value);
            money.TotalCashValue -= value;
        }

        public double GetTotalCash()
        {
            var sum = _sharedMoneyMap.Sum(money => money.Value.TotalCashValue);
            sum += UnsharedMoney.TotalCashValue;
            return sum;
        }
    }
}