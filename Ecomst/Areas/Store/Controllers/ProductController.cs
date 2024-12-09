using Ecomst.Areas.Store.ViewModels.Product;
using Ecomst.DTO;
using Ecomst.Entities;
using Ecomst.Helpers;
using Ecomst.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Ecomst.Areas.Store.Controllers
{
    [Area("Store")]
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index(ProductGalaryViewModel viewModel)
        {
            List<Category> categories = _categoryService.GetCategoriesInUseAsc();
            string defaultCategoryName = categories.First().Name;
            ProductSearch searchModel = new ProductSearch();

            searchModel.CategoryName = String.IsNullOrEmpty(viewModel.CategoryName) ? defaultCategoryName : viewModel.CategoryName;
            SearchResult<Product> result = _productService.Search(searchModel, null, viewModel.PageNumber, viewModel.Length);
            viewModel.PopulateFromSearchResult(result);
            viewModel.CategoryList = _categoryService.GetCategoriesInUseAsc();
            if(String.IsNullOrEmpty(viewModel.CategoryName))
                viewModel.CategoryName = defaultCategoryName;
            return View(viewModel);
        }
    }
}
