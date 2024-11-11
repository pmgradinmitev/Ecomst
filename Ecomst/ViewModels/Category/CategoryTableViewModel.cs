using Ecomst.DTO;
using Ecomst.Helpers;

namespace Ecomst.ViewModels.Category
{
    public class CategoryTableViewModel:BaseTableViewModel
    {
        public List<Ecomst.Entities.Category> Data { get; set; }
        public void PopulateFromSearchResult(SearchResult<Ecomst.Entities.Category> searchResult)
        {
            TotalPages = searchResult.TotalPages;
            RecordsTotal = searchResult.RecordsTotal;
            RecordsFiltered = searchResult.RecordsFiltered;
            Start = searchResult.Start;
            Data = searchResult.Data;
        }

        //Search properties
        public string? Name {  get; set; }
        public int? DisplayOrder { get; set; }
    }
}
