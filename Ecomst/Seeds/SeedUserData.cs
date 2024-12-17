using Ecomst.Entities;
using Ecomst.Helpers;
using Microsoft.AspNetCore.Identity;

namespace Ecomst.Seeds
{
    public class SeedUserData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            SetAndSaveUser("admin@test.com", "Password123@", StaticData.Role_Admin, serviceProvider);
            SetAndSaveUser("customer@test.com", "Password123@", StaticData.Role_Customer, serviceProvider);
        }

        private static void SetAndSaveUser(string userEmail, string password, string role, IServiceProvider serviceProvider)
        {
            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (userManager.FindByNameAsync(userEmail).GetAwaiter().GetResult() == null)
            {
                ApplicationUser user = new()
                {
                    UserName = userEmail,
                    Email = userEmail,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                userManager.CreateAsync(user, password).GetAwaiter().GetResult();
                userManager.AddToRoleAsync(user, role).GetAwaiter().GetResult();
            }
        }
    }
}
