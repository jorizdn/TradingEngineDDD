using TradingEngine.Domains.Entities;
using TradingEngine.Infrastructure.Repository.Interfaces;

namespace TradingEngine.Infrastructure.Repository
{
    public class AccountRepository : TradingEngineRepository<Account>, IAccountRepository
    {
        public AccountRepository(TradingEngineContext tradingEngineEngineContext) : base(tradingEngineEngineContext)
        {
        }
    }
}
