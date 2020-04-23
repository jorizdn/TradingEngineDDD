using Microsoft.AspNetCore.Mvc;
using TradingEngine.Domains.Entities;
using TradingEngine.Models.RequestModels;
using TradingEngine.Services.Interfaces;

namespace TradingEngine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServices;

        public UserController(IUserService userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userServices.GetUsers());
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserModel model)
        {
            return Ok(_userServices.AddUser(model.Firstname, model.Lastname));
        }

        [HttpPost]
        [Route("send")]
        public IActionResult SendMoney([FromBody] SendMoneyModel model)
        {
            _userServices.SendMoney(model.FromUserId, model.ToUserId, model.Amount);
            return Ok();
        }

        [HttpPost]
        [Route("store")]
        public IActionResult StoreMoney([FromBody] StoreMoneyModel model)
        {
            _userServices.StoreMoney(model.UserId, model.Amount);
            return Ok();
        }

        [HttpGet]
        [Route("exchange")]
        public IActionResult ExchangeMoney(int id, int currencyId)
        {
            return Ok(_userServices.ExchangeMoney(id, currencyId));
        }
    }
}
