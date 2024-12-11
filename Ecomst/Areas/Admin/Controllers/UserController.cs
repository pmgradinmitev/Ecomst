using Ecomst.Areas.Admin.ViewModels.User;
using Ecomst.DTO;
using Ecomst.Entities;
using Ecomst.Helpers;
using Ecomst.Services.IServices;
using Ecomst.Areas.Admin.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using Ecomst.Services;
using Microsoft.AspNetCore.Identity;

namespace Ecomst.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService; 
        }

        public IActionResult Index(UserTableViewModel viewModel)
        {
            ApplicationUserSearch searchModel = new ApplicationUserSearch();
            searchModel.UserName = viewModel.UserName;
            searchModel.UserRole = viewModel.UserRole;
            SearchResult<ApplicationUser> result = _userService.UserSearch(searchModel, viewModel.SortOrder, viewModel.PageNumber, viewModel.Length);
            viewModel.PopulateFromSearchResult(result);
            viewModel.UserRoleList = Utils.ListToSelectListItem(_userService.GetUserRolesList(), "Name", "Id"); ;
            return View(viewModel);
        }
    }
}
