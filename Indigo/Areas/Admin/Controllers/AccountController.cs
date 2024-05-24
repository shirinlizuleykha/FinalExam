using Indigo.Areas.ViewModels;
using Indigo.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bloger.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        //////public async Task<IActionResult> CreateRole()
        //////{
        //////    IdentityRole identityRole = new IdentityRole("SuperAdmin");
        //////    IdentityRole identityRole1 = new IdentityRole("Member");

        //////    await _roleManager.CreateAsync(identityRole1);
        //////    await _roleManager.CreateAsync(identityRole);

        //////    return Ok("Rollar yarandi");
        //////}
        //////public async Task<IActionResult> CreateAdmin()
        //////{
        //////    AppUser user = new AppUser()
        //////    {
        //////        FullName = "Shirinli Zuleykha"
        //////        UserName = "Admin"


        //////    }

        ////    await _userManager.CreateAsync(user, "Admin123@");
        ////    await _userManager.AddToRoleAsync(user, "SuperAdmin");

        ////    return Ok("Admin yarandi");
        //}

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Login(AdminLoginVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser user = await _userManager.FindByNameAsync(vm.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "Username or password is not valid");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(user, vm.Pasword, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password is not valid");
                return View();
            }


            return RedirectToAction("index", "dashboard");
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login");
        }

    }



}
