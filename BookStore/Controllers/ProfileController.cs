using BookStore.Models;
using BookStore.Utills;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<BookStoreUser> _userManager;

        public ProfileController(UserManager<BookStoreUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            return View(CurrentUser);
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var User = await _userManager.GetUserAsync(HttpContext.User);
            User.ProfileImage = ImageHandling.UploadImage(file, "Images");
            var result = await _userManager.UpdateAsync(User);

            if (result.Succeeded)
                return RedirectToAction("Index");
            return View(User);
        }
    }
}
