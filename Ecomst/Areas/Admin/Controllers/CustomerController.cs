using Ecomst.Areas.Admin.ViewModels.Customer;
using Ecomst.DTO;
using Ecomst.Entities;
using Ecomst.Helpers;
using Ecomst.Services.IServices;
using Ecomst.Areas.Admin.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using Ecomst.Services;

namespace Ecomst.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService; 
        }

        public IActionResult Index(CustomerTableViewModel viewModel)
        {
            ApplicationUserSearch searchModel = new ApplicationUserSearch();
            searchModel.UserName = viewModel.UserName;
            SearchResult<ApplicationUser> result = _customerService.Search(searchModel, viewModel.SortOrder, viewModel.PageNumber, viewModel.Length);
            viewModel.PopulateFromSearchResult(result);
            return View(viewModel);
        }
    }
}
