using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.DTOs.IdentityDTOs;

namespace SignalRWebUI.Controllers
{
    public class SettingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDTOs userEditDTOs = new UserEditDTOs();
            userEditDTOs.Surname = value.Surname;
            userEditDTOs.Name = value.Name;
            userEditDTOs.Username = value.UserName;
            userEditDTOs.Mail = value.Email;
            return View(userEditDTOs);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditDTOs userEditDTOs)
        {
            if (userEditDTOs.Password == userEditDTOs.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = userEditDTOs.Name;
                user.Surname=userEditDTOs.Surname;
                user.Email = userEditDTOs.Mail;
                user.UserName = userEditDTOs.Username;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditDTOs.Password);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index","Category");
            }
            return View();
        }
    }
}
