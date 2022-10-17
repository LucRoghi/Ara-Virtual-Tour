using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AraVirtualTour.Pages;

public class VirtualTourModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public VirtualTourModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}


