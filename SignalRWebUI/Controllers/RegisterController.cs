using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.DTOs.IdentityDTOs;

namespace SignalRWebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterDTOs registerDTOs)
        {
            AppUser appUser = new AppUser()
            {
                Name = registerDTOs.Name,
                Surname = registerDTOs.Surname,
                Email = registerDTOs.Mail,
                UserName = registerDTOs.Username
            };
            var result = await _userManager.CreateAsync(appUser, registerDTOs.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        

                   
    }
}
