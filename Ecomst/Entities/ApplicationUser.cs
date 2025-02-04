using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomst.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        [NotMapped]
        public string FirstName {  get; set; }
        [NotMapped]
        public string LastName { get; set; }
    }
}
