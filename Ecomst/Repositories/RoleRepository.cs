using Ecomst.Data;
using Ecomst.Entities;
using Ecomst.Repositories.IRepositories;

namespace Ecomst.Repositories
{
    public class RoleRepository:IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<ApplicationRole> GetRoles()
        {
            return _context.ApplicationRoles.ToList();
        }
    }
}
