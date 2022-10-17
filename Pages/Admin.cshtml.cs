using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AraVirtualTour.Pages;

public class AdminModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public AdminModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
