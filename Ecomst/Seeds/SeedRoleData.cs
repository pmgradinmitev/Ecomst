using Ecomst.Entities;
using Ecomst.Helpers;
using Microsoft.AspNetCore.Identity;

namespace Ecomst.Seeds
{
    public class SeedRoleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            if (!roleManager.RoleExistsAsync(StaticData.Role_Customer).GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(new ApplicationRole(StaticData.Role_Customer)).GetAwaiter().GetResult();
            }
            if (!roleManager.RoleExistsAsync(StaticData.Role_Admin).GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(new ApplicationRole(StaticData.Role_Admin)).GetAwaiter().GetResult();
            }
        }
    }
}
