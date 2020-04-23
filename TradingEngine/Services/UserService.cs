using System;
using System.Collections.Generic;
using System.Linq;
using TradingEngine.Domains.Entities;
using TradingEngine.Infrastructure.Repository.Interfaces;
using TradingEngine.Services.Interfaces;

namespace TradingEngine.DomainServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IAccountService _accountService;

        public UserService(
            IUserRepository userRepository,
            ICurrencyRepository currencyRepository,
            IAccountService accountService)
        {
            _userRepository = userRepository;
            _currencyRepository = currencyRepository;
            _accountService = accountService;
        }

        public int AddUser(string firstname, string lastName)
        {
            var user = new User(firstname, lastName);
            _userRepository.Add(user);

            return _userRepository.SaveChanges();
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetAll().ToList();
            //includeProperties: new Expression<Func<User, object>>[] { x => x.Account }
        }

        public void SendMoney(int fromUserId, int toUserId, int amount)
        {
            var fromUserAccount = _accountService.GetAccounts().FirstOrDefault(x => x.UserId == fromUserId);
            var toUserAccount = _accountService.GetAccounts().FirstOrDefault(x => x.UserId == toUserId);
            fromUserAccount.Send(amount);
            toUserAccount.Store(amount);
            _accountService.UpdateAccount(fromUserAccount);
            _accountService.UpdateAccount(toUserAccount);
        }

        public void StoreMoney(int userId, int amount)
        {
            var userAccount = _accountService.GetAccounts().FirstOrDefault(x => x.UserId == userId);
            userAccount.Store(amount);
            _accountService.UpdateAccount(userAccount);
        }

        public decimal ExchangeMoney(int userId, int currencyId)
        {
            var userAccount = _accountService.GetAccounts().FirstOrDefault(x => x.UserId == userId);
            var currencyToConvert = _currencyRepository.GetById(currencyId);
            var convertedMoney =  currencyToConvert.ExchangeMoney(userAccount.Balance);
            return convertedMoney;
        }
    }
}
