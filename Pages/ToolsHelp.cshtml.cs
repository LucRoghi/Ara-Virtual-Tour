using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AraVirtualTour.Pages;

public class ToolsHelpModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public ToolsHelpModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
