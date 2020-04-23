using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingEngine.Domains;
using TradingEngine.Domains.Currency;
using TradingEngine.Infrastructure.Repository.Interfaces;

namespace TradingEngine.Infrastructure.Repository
{
    public class CurrencyRepository : TradingEngineRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(TradingEngineContext tradingEngineEngineContext) : base(tradingEngineEngineContext)
        {
        }
    }
}
