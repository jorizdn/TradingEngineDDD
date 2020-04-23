using System.Collections.Generic;
using TradingEngine.Domains.Entities;

namespace TradingEngine.Services.Interfaces
{
    public interface IUserService
    {
        int AddUser(string firstname, string lastName);
        List<User> GetUsers();
        void SendMoney(int fromUserId, int toUserId, int amount);
        void StoreMoney(int userId, int amount);

        decimal ExchangeMoney(int userId, int currencyId);
    }
}
