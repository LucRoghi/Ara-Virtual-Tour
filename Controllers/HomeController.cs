using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AraVirtualTour.Models;

namespace AraVirtualTour.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Staff()
    {
        return View();
    }

    public IActionResult UsingAraResources()
    {
        return View();
    }

    public IActionResult VirtualTour()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
