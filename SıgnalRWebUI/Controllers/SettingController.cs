using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SıgnalRWebUI.DTOs.IdentityDTOs;

namespace SıgnalRWebUI.Controllers
{
    public class SettingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        /// <summary>
        /// Kullanıcı Bilgilerini Ayarlardan Değiştirme İşlemi
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDto userEditDto=new UserEditDto();
            userEditDto.Name = values.Name;
            userEditDto.Surname = values.Surname;
            userEditDto.Username = values.UserName;
            userEditDto.Mail = values.Email;
            //Password burada kullanılmaz onun için burada kullanılmayacak.

            return View(userEditDto);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditDto userEditDto)
        {
            if (userEditDto.Password==userEditDto.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name= userEditDto.Name;
                user.Surname= userEditDto.Surname;
                user.Email = userEditDto.Mail;
                user.UserName = userEditDto.Username;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user,userEditDto.Password);
                _userManager.UpdateAsync(user);
                return RedirectToAction("Index","Category");
            }
            return View();   
        }
    }
}
