using Ecomst.DTO;
using Ecomst.Entities;

namespace Ecomst.Services.IServices
{
    public interface IUserService
    {
        public SearchResult<ApplicationUser> UserSearch(ApplicationUserSearch searchModel, string sortColumn, int pageNumber, int length);
        public List<ApplicationRole> GetUserRolesList();
    }
}
