using Ecomst.DTO;
using Ecomst.Entities;

namespace Ecomst.Services.IServices
{
    public interface ICustomerService
    {
        public SearchResult<ApplicationUser> Search(ApplicationUserSearch searchModel, string sortColumn, int pageNumber, int length);
    }
}
