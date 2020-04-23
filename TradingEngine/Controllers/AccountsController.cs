
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TradingEngine.Models.RequestModels;
using TradingEngine.Services.Interfaces;

namespace TradingEngine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_accountService.GetAccounts());
        }

        [HttpPost]
        public IActionResult AddAccount([FromBody] AddAccountModel model)
        {
            return Ok(_accountService.AddAccount(model.UserId, model.Amount));
        }
        
    }
}
