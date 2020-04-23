using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingEngine.Models.RequestModels
{
    public class StoreMoneyModel
    {
        public int UserId { get; set; }
        public int Amount { get; set; }
    }

    public class SendMoneyModel
    {
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public int Amount { get; set; }
    }
    public class UserModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Amount { get; set; }
    }
}
