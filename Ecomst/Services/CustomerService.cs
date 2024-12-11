using Ecomst.Entities;
using Ecomst.Services.IServices;
using Ecomst.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Ecomst.Helpers;
using System.Text.RegularExpressions;
using Ecomst.DTO;

namespace Ecomst.Services
{
    public class CustomerService : ICustomerService
    {
        private IUserRepository _repository;

        public CustomerService(IUserRepository repository)
        {
            _repository = repository;
        }

        public SearchResult<ApplicationUser> Search(ApplicationUserSearch searchModel, string sortColumn, int pageNumber, int length)
        {
            int start = (pageNumber - 1) * length;
            SearchResult<ApplicationUser> result = _repository.GetPageData(searchModel, sortColumn, start, length);

            int recordsFiltered = result.RecordsFiltered;
            int totalPages = (int)Math.Ceiling((double) recordsFiltered / length);
            result.Start = start;
            result.TotalPages = totalPages;
            return result;
        }
    }
}
