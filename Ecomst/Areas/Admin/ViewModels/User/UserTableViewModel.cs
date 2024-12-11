using Ecomst.DTO;
using Ecomst.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace Ecomst.Areas.Admin.ViewModels.User
{
    public class UserTableViewModel : BaseTableViewModel
    {
        public List<Entities.ApplicationUser> Data { get; set; }
        public void PopulateFromSearchResult(SearchResult<Entities.ApplicationUser> searchResult)
        {
            TotalPages = searchResult.TotalPages;
            RecordsTotal = searchResult.RecordsTotal;
            RecordsFiltered = searchResult.RecordsFiltered;
            Start = searchResult.Start;
            Data = searchResult.Data;
        }

        //Search properties
        [DisplayName("Потребителско име")]
        public string? UserName { get; set; }
        [DisplayName("Роля")]
        public string? UserRole { get; set; }

        public IEnumerable<SelectListItem> UserRoleList { get; set; }
    }
}
