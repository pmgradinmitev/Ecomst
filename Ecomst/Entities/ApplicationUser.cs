using Microsoft.AspNetCore.Identity;

namespace Ecomst.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
