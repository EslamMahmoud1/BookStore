using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ManageRoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BookStoreUser> _userManager;

        public ManageRoleController(RoleManager<IdentityRole> roleManager , UserManager<BookStoreUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return Content("Hello From Index");
        }
        public async Task<IActionResult> CreateRole(string RoleName)
        {
            IdentityRole identityRole = new IdentityRole
            {
                Name = RoleName
            };
            // Saves the role in the underlying AspNetRoles table
            var result = await _roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("CreateRoleAsync", "ManageRoleController");
        }
        public async Task<IActionResult> AddUserToRole(string RoleName, string UserName)
        {
            var user = await _userManager.FindByEmailAsync(UserName);
            var role = await _roleManager.FindByNameAsync(RoleName);
            if (role == null || user == null)
                return Content("Wrong Info");

            await _userManager.AddToRoleAsync(user, RoleName);
            return RedirectToAction("Index", "Home");
        }

    }
}
