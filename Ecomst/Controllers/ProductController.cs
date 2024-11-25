using Ecomst.DTO;
using Ecomst.Entities;
using Ecomst.Helpers;
using Ecomst.Services.IServices;
using Ecomst.ViewModels.Category;
using Ecomst.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace Ecomst.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
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
            List<Category> categoryList = _categoryService.GetCategoryList();
            viewModel.CategoryList = Utils.ListToSelectListItem(categoryList, "Name", "Id");
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ProductViewModel viewModel = new ProductViewModel();
            List<Category> categoryList = _categoryService.GetCategoryList();
            viewModel.CategoryList = Utils.ListToSelectListItem(categoryList, "Name", "Id");
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel viewModel, IFormFile? file)
        {
            return View(viewModel);
        }
    }
}
