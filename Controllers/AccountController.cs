using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AraVirtualTour.Models;

namespace AraVirtualTour
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AraVirtualTour.AppContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AraVirtualTour.AppContext context)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            var response = new LoginModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if(!ModelState.IsValid) return View(loginModel);

            var user = await _userManager.FindByEmailAsync(loginModel.EmailAddress);

            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginModel.Password);
                if(passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Home", "Index");
                    }
                }
                TempData["Error"] = "Wrong credentials. Please try again";
                return View(loginModel);
            }
            TempData["Error"] = "Wrong credentials. Please try again";
            return View(loginModel);
        } 
    }
  
}