using Microsoft.AspNetCore.Identity;

namespace Ecomst.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
