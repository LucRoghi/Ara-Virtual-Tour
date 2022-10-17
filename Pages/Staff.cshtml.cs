using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AraVirtualTour.Pages;

public class StaffModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public StaffModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}


