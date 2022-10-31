using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AraVirtualTour;
using System.Diagnostics;
using AraVirtualTour.Models;

namespace AraVirtualTour.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppContext _context;

    public HomeController(ILogger<HomeController> logger, AppContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Staff()
    {
        return View(await _context.StaffModel.ToListAsync());
    }

    [HttpGet]
    public IActionResult UsingAraResources()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> VirtualTour()
    {
        return View(await _context.VirtualTourModel.ToListAsync());
    }

    [HttpGet]
    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Credit()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
