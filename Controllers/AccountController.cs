using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using AraVirtualTour.Models;
using System;

namespace AraVirtualTour.Controllers;
public class AccountController : Controller
{
    private readonly UserManager<AppUserModel> _userManager;
    private readonly SignInManager<AppUserModel> _signInManager;
    private readonly AraVirtualTour.AppContext _context;
    public AccountController(UserManager<AppUserModel> userManager, SignInManager<AppUserModel> signInManager, AraVirtualTour.AppContext context)
    {
        _context = context;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Login()
    {
        var response = new LoginModel();
        return View(response);
    }

    [HttpGet]
    public IActionResult AdminPanel()
    {
        return View();
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
                    return RedirectToAction("Index", "Home");
                }
            }
            TempData["Error"] = "Wrong credentials. Please try again";
            return View();
        }
        TempData["Error"] = "Wrong credentials. Please try again";
        return View();
    } 
}
  
