using Microsoft.AspNetCore.Identity;

namespace Ecomst.Entities
{
    public class ApplicationRole:IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName):base(roleName) { }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
