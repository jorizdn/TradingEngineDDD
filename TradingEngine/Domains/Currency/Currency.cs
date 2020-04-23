using TradingEngine.Infrastructure;

namespace TradingEngine.Domains.Currency
{
    public class Currency : Entity
    {
        public Currency(string name, decimal ratio)
        {
            Name = name;
            Ratio = ratio;
        }

        public string Name { get; private set; }
        public decimal Ratio { get; private set; }

        public decimal ExchangeMoney(int amount)
        {
            return amount * Ratio;
        }
    }
}
