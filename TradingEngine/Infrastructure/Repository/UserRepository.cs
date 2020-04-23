using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingEngine.Domains.Entities;
using TradingEngine.Infrastructure.Repository.Interfaces;

namespace TradingEngine.Infrastructure.Repository
{
    public class UserRepository : TradingEngineRepository<User>, IUserRepository
    {
        public UserRepository(TradingEngineContext tradingEngineEngineContext) : base(tradingEngineEngineContext)
        {
        }
    }
}
