using Ecomst.DTO;
using Ecomst.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace Ecomst.Areas.Store.ViewModels.Product
{
    public class ProductGalleryViewModel : BaseTableViewModel
    {
        public List<Entities.Product> Data { get; set; }
        public void PopulateFromSearchResult(SearchResult<Entities.Product> searchResult)
        {
            TotalPages = searchResult.TotalPages;
            RecordsTotal = searchResult.RecordsTotal;
            RecordsFiltered = searchResult.RecordsFiltered;
            Start = searchResult.Start;
            Data = searchResult.Data;
        }

        public string? CategoryName { get; set; }
        public List<Ecomst.Entities.Category> CategoryList { get; set; }
    }
}
