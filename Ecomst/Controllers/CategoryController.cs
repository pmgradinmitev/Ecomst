using Ecomst.Entities;
using Microsoft.AspNetCore.Mvc;
using Ecomst.Services.IServices;
using Ecomst.ViewModels.Category;
using Ecomst.Helpers;

namespace Ecomst.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            List<Category> categoryList = _categoryService.GetCategoryList();
            return View(categoryList);
        }

        public IActionResult Create()
        {
            CategoryViewModel viewModel = new CategoryViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryViewModel viewModel)
        {
            _categoryService.SetModelStateDictionary(new ModelStateWrapper(ModelState));
           
            Category category = new Category();
            viewModel.PopulateCategory(category);
            if (_categoryService.AddCategory(category))
            {
                TempData["success"] = $"Category {category.Name} was created successfully!";
                return RedirectToAction("Index");
            }
            else if (ModelState.IsValid)
            {
                TempData["error"] = "Unable to create category!";
            }
            
            return View(viewModel);
        }

        public IActionResult Update(int id)
        {
            Category? category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                TempData["error"] = "Category with id " + id + " not found!";
                return RedirectToAction("Index");
            }
            CategoryViewModel viewModel = new CategoryViewModel();
            viewModel.PopulateFromCategory(category);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CategoryViewModel viewModel)
        {
            _categoryService.SetModelStateDictionary(new ModelStateWrapper(ModelState));
           
            Category? category = _categoryService.GetCategoryById(viewModel.Id);
            if (category == null)
            {
                TempData["error"] = "Unable to find category!";
                return RedirectToAction("Index");
            }
            viewModel.PopulateCategory(category);
            if (_categoryService.UpdateCategory(category))
            {
                TempData["success"] = $"Category {category.Name} was updated successfully!";
                return RedirectToAction("Index");
            }
            else if (ModelState.IsValid)
            {
                TempData["error"] = "Unable to update category!";
            }
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (_categoryService.DeleteCategory(id))
            {
                TempData["success"] = "Category was deleted successfully";
            }
            else
            {
                TempData["error"] = "Unable to delete category";
            }
            return RedirectToAction("Index");
        }

        public IActionResult GetTableData()
        {
            List<Category> categoryList = _categoryService.GetCategoryList();
            return Json(new { data = categoryList });
        }
    }
}
