using Ecomst.Data;
using Ecomst.Entities;
using Ecomst.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ecomst.Seeds
{
    public class SeedUserData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            SetAndSaveUser("testadmin@test.com", "Testadmin123@", StaticData.Role_Admin, serviceProvider);
            SetAndSaveUser("testcustomer@test.com", "Testadmin123@", StaticData.Role_Customer, serviceProvider);
            SetAndSaveUser("testemployee@test.com", "Testadmin123@", StaticData.Role_Employee, serviceProvider);
        }

        private static void SetAndSaveUser(string userEmail, string password, string role, IServiceProvider serviceProvider)
        {
            var userStore = serviceProvider.GetRequiredService<IUserStore<ApplicationUser>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            if (!userManager.SupportsUserEmail)
                throw new NotSupportedException("The default UI requires a user store with email support.");

            var emailStore = (IUserEmailStore<ApplicationUser>)userStore;
            var user = userManager.FindByNameAsync(userEmail).GetAwaiter().GetResult();
            if (user != null)
                return;

            user = CreateUser();
            userStore.SetUserNameAsync(user, userEmail, CancellationToken.None).GetAwaiter().GetResult();
            emailStore.SetEmailAsync(user, userEmail, CancellationToken.None).GetAwaiter().GetResult();

            var result = userManager.CreateAsync(user, password).GetAwaiter().GetResult();

            if (!result.Succeeded)
                return;

            if (!userManager.IsInRoleAsync(user, role).GetAwaiter().GetResult())
                userManager.AddToRoleAsync(user, role).GetAwaiter().GetResult();
        }

        //From register model in identity area
        private static ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. ");
            }
        }
    }
}
