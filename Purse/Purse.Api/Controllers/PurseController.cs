using Microsoft.AspNetCore.Mvc;
using Purse.Application.Services;
using Purse.Application.Contracts;
using Purse.Domain.Entites;

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
        public ActionResult<List<PurseM>> GetPurses()
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
        public ActionResult<string> UpdateUser(User user)
        {
            var response = purseService.UpdateUser(user);
            return Ok(response);
        }

        [HttpPost]
        [Route("AddUser")]
        public ActionResult<string> AddUser(User user, int CompanyId)
        {
            var response = purseService.CreateUser(user, CompanyId);
            return Ok(response);
        }

        [HttpPost]
        [Route("AddPurse")]
        public ActionResult<string> AddPurse(PurseM purse, int UserId)
        {
            var response = purseService.CreatePurse(purse, UserId);
            return Ok(response);
        }

        [HttpPost]
        [Route("AddCompany")]
        public ActionResult<string> AddCompany(Company company)
        {
            var response = purseService.CreateCompany(company);
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
