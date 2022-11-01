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

public class ToolsController : Controller 
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppContext _context;

    public ToolsController(ILogger<HomeController> logger, AppContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Moodle()
    {
        return View();
    }

    public IActionResult Myara()
    {
        return View();
    }

    [HttpGet]
    public IActionResult UsingAraResources()
    {
        return View();
    }
}