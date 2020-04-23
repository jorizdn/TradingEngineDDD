using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TradingEngine.Domains.Entities;
using TradingEngine.Infrastructure.Repository.Interfaces;
using TradingEngine.Services.Interfaces;

namespace TradingEngine.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account AddAccount(int userId, int amount)
        {
            var account = new Account(new Guid(), amount, userId); 
            _accountRepository.Add(account); 
            _accountRepository.SaveChanges();
            return account;
        }

        public void UpdateAccount(Account account)
        { 
            _accountRepository.Update(account);
            _accountRepository.SaveChanges();
        }

        public List<Account> GetAccounts()
        {
            return _accountRepository.GetAll(includeProperties: new Expression<Func<Account, object>>[] {x => x.User, x => x.Currency})
                .ToList();
        }
    }
}
