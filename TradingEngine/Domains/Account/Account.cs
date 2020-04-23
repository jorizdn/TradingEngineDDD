using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TradingEngine.Infrastructure;

namespace TradingEngine.Domains.Entities
{
    public class Account : Entity
    {

        public Account(Guid accountNumber, int balance, int userId)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            UserId = userId;
        }

        public Guid AccountNumber { get; private set; }
        public int Balance { get; private set; }
        public int UserId { get; private set; }
        public int CurrencyId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; private set; }

        [ForeignKey("CurrencyId")]
        public Currency.Currency Currency { get; private set; }


        public void Store(int amount)
        {
            Balance += amount;
        }

        public int Check()
        {
            return Balance;
        }

        public void Send(int amount)
        {
            Balance -= amount;
        }
    }
}
