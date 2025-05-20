using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyCasesController : ControllerBase
    {
        private readonly IMoneyCaseService _moneycaseService;

        public MoneyCasesController(IMoneyCaseService moneycaseService)
        {
            _moneycaseService = moneycaseService;
        }
        [HttpGet("TTotalMoneyCaseAmount")]
        public IActionResult TotalMoneyCaseAmount()
        {
            return Ok(_moneycaseService.TTotalMoneyCaseAmount());
        }
    }
}
