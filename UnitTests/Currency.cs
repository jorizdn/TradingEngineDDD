using FluentAssertions;
using NUnit.Framework;
using TradingEngine.Domains;
using TradingEngine.Domains.Currency;

namespace UnitTests
{
    [TestFixture]
    public class CurrencyTest
    {
        [TestCase]
        public void WhenCurrencyIsUsd_ThenItShouldConvertPesoCorrectly()
        {
            var currency = new Currency("Usd", 50.47m);
            var convertedMoney = currency.ExchangeMoney(100);

            convertedMoney.Should().Be(5047.00m);
        }

        [TestCase]
        public void WhenCurrencyIsBaht_ThenItShouldConvertPesoCorrectly()
        {
            var currency = new Currency("Baht", 1.57m);
            var convertedMoney = currency.ExchangeMoney(100);

            convertedMoney.Should().Be(157.00m);
        }

        [TestCase]
        public void WhenCurrencyIsYen_ThenItShouldConvertPesoCorrectly()
        {
            var currency = new Currency("Yen", 0.47m);
            var convertedMoney = currency.ExchangeMoney(100);

            convertedMoney.Should().Be(47.00m);
        }

        [TestCase]
        public void WhenCurrencyIsPeso_ThenItShouldConvertPesoCorrectly()
        {
            var currency = new Currency("Peso", 1);
            var convertedMoney = currency.ExchangeMoney(100);

            convertedMoney.Should().Be(100);
        }
    }
}
