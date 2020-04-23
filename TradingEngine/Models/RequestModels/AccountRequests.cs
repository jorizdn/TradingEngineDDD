using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingEngine.Models.RequestModels
{
    public class AddAccountModel
    {
        public int UserId { get; set; }
        public int Amount { get; set; }
    }
}
