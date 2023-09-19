using Microsoft.AspNetCore.Mvc;
using Purse.Application.Services;
using Purse.Application.Contracts;
using Purse.Domain.Entites;
using Purse.Application.Dtos;

namespace Purse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurseController : Controller
    {

        private readonly IPurseService purseService;

        public PurseController(IPurseService purseService)
        {
            this.purseService = purseService;
        }

        [HttpGet]
        [Route("GetPurses")]
        public ActionResult<List<PurseDto>> GetPurses()
        {
                var purses = purseService.GetPurses();
            return Ok(purses);
        }
        [HttpGet]
        [Route("GetPurseBalance")]
        public ActionResult<float> GetBalance(int PurseId)
        {
            var balance = purseService.GetBalance(PurseId);
            return Ok(balance);
        }
        [HttpPut]
        [Route("UpdateUser")]
        public ActionResult<string> UpdateUser(UserDto userDto)
        {
            var response = purseService.UpdateUser(userDto);
            return Ok(response);
        }

        [HttpPost]
        [Route("AddUser")]
        public ActionResult<string> AddUser(UserDto userDto, int CompanyId)
        {
            var response = purseService.CreateUser(userDto, CompanyId);
            return Ok(response);
        }

        [HttpPost]
        [Route("AddPurse")]
        public ActionResult<string> AddPurse(PurseDto purseDto, int UserId)
        {
            var response = purseService.CreatePurse(purseDto, UserId);
            return Ok(response);
        }

        [HttpPost]
        [Route("AddCompany")]
        public ActionResult<string> AddCompany(CompanyDto companyDto)
        {
            var response = purseService.CreateCompany(companyDto);
            return Ok(response);
        }

        [HttpPost]
        [Route("WithDrawTransaction")]
        public ActionResult<string> Withdraw(int purseId, float amount)
        {
            var response = purseService.Withdraw(purseId, amount);
            return Ok(response);
        }
        [HttpPost]
        [Route("DepositTransaction")]
        public ActionResult<string> Deposit(int purseId, float amount)
        {
            var response = purseService.Deposit(purseId, amount);
            return Ok(response);
        }

        [HttpPost]
        [Route("MoveTransaction")]
        public ActionResult<string> Move(int sourcePurseId, int destinationPurseId, float amount)
        {
            var response = purseService.Move(sourcePurseId, destinationPurseId, amount);
            return Ok(response);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
