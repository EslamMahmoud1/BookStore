using BookStore.Models;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<BookStoreUser> _userManager;
        private readonly SignInManager<BookStoreUser> _signInManager;

        public AccountController(UserManager<BookStoreUser> userManager ,SignInManager<BookStoreUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);
            var user = new BookStoreUser
            { 
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email,
                Email = model.Email,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if(result.Succeeded) 
                return RedirectToAction(nameof(Login));
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user is null)
            {
                ModelState.AddModelError("", "Invalid Email");
                return View(model);
            }
                
            if (await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid Login");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
             await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
