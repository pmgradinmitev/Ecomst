using Ecomst.DTO;
using Ecomst.Entities;
using Ecomst.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace Ecomst.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(ProductTableViewModel viewModel)
        {
            ProductSearch searchModel = new ProductSearch();
            searchModel.Name = viewModel.Name;
            searchModel.DisplayOrder = viewModel.DisplayOrder;
            SearchResult<Product> result = _productService.Search(searchModel, viewModel.SortOrder, viewModel.PageNumber, viewModel.Length);
            viewModel.PopulateFromSearchResult(result);
            return View(viewModel);
        }
    }
}
