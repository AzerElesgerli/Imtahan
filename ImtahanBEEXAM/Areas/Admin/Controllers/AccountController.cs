using ImtahanBEEXAM.Areas.Admin.ViewModels.Account;
using ImtahanBEEXAM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ImtahanBEEXAM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = new AppUser
            {
                Name = vm.Name,
                Surname = vm.Surname,
                Email = vm.Email,
              

            };
            var result = await _userManager.CreateAsync(user, vm.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(String.Empty, item.Description);
                }
                return View();
            }
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home", new { Area = "" });
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = await _userManager.FindByNameAsync(vm.Username);
            if (user == null)
            {
                user = await _userManager.FindByNameAsync(vm.Username);
                if (user == null)
                {
                    ModelState.AddModelError(String.Empty, "Password,Email or UserName is incorrect");
                    return View();
                }

            }
            var result = await _signInManager.PasswordSignInAsync(user, vm.Password, vm.RememberMe, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(String.Empty, "Password,Email or UserName is incorrect");
                return View();
            }
            await _signInManager.SignInAsync(user,false);
            return RedirectToAction("Index", "Home", new { Area = "" });
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }
        public async Task<IActionResult> CreateRoles()
        {
            await _roleManager.CreateAsync(new IdentityRole
            {
                Name = "admin"
            });
            return RedirectToAction("Index", "Home", new { Area = "" });
        }
    }

}
