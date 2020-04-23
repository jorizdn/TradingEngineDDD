using System.Collections.Generic;
using TradingEngine.Domains.Entities;

namespace TradingEngine.Services.Interfaces
{
    public interface IAccountService
    {
        Account AddAccount(int userId, int amount);
        void UpdateAccount(Account account);
        List<Account> GetAccounts();
    }
}
