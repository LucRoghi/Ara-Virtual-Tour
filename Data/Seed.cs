using Microsoft.AspNetCore.Identity;
using AraVirtualTour.Models;

namespace AraVirtualTour.Data
{
    public class Seed
    {  
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AraVirtualTour.AppUserModel>>();
                string adminUserEmail = "lcr0059@arastudent.ac.nz";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AraVirtualTour.AppUserModel()
                    {
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        UserName = adminUserEmail
                        
                    };
                    await userManager.CreateAsync(newAdminUser, "420CreamMonster!");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }
            }
        }
    }
}
