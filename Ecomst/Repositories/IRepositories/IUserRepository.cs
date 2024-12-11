using Ecomst.DTO;
using Ecomst.Entities;

namespace Ecomst.Repositories.IRepositories
{
    public interface IUserRepository
    {
        public SearchResult<ApplicationUser> GetPageData(ApplicationUserSearch searchModel, string sortColumn, int start, int length);
    }
}
