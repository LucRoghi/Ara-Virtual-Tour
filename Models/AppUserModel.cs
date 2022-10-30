using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AraVirtualTour
{
    public class AppUserModel : IdentityUser
    {
        public string? EmailAddress { get; set; }
        public string? FirstName { get; set; } 
        public string? LastName { get; set; }
        public string? Role { get; set; }
    }
}