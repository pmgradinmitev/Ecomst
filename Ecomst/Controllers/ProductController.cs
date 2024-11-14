using Ecomst.DTO;
using Ecomst.Entities;
using Ecomst.Services.IServices;
using Ecomst.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace Ecomst.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(ProductTableViewModel viewModel)
        {
            ProductSearch searchModel = new ProductSearch();
            searchModel.CategoryId = viewModel.CategoryId;
            searchModel.CodeNumber = viewModel.CodeNumber;
            searchModel.Title = viewModel.Title;
            searchModel.Description = viewModel.Description;
            searchModel.InStock = viewModel.InStock;
            SearchResult<Product> result = _productService.Search(searchModel, viewModel.SortOrder, viewModel.PageNumber, viewModel.Length);
            viewModel.PopulateFromSearchResult(result);
            return View(viewModel);
        }
    }
}
