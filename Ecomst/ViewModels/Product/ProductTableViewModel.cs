using Ecomst.DTO;
using Ecomst.Helpers;
using System.ComponentModel;

namespace Ecomst.ViewModels.Product
{
    public class ProductTableViewModel:BaseTableViewModel
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
        [DisplayName("Категория")]
        public int CategoryId { get; set; }
        [DisplayName("Номер на продукта")]
        public string CodeNumber { get; set; }
        [DisplayName("Заглавие")]
        public string Title { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }
        public bool InStock { get; set; }
    }
}
