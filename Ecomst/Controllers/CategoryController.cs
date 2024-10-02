﻿using Ecomst.Entities;
using Microsoft.AspNetCore.Mvc;
using Ecomst.Services.IServices;
using Ecomst.ViewModels.Category;

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

        public IActionResult Upsert(int? id)
        {
            CategoryViewModel viewModel = new CategoryViewModel();
            if(id == null)
                return View(viewModel);

            Category? category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                TempData["error"] = "Category with id " + id + " not found!";
                return RedirectToAction("Index");
            }
            viewModel.PopulateFromCategory(category);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CategoryViewModel viewModel)
        {
            Category category = new Category();
            
            if (viewModel.Id == null && ModelState.IsValid)
            {
                viewModel.PopulateCategory(category);
                if (_categoryService.AddCategory(category))
                {
                    TempData["success"] = "Category was created successfully!";
                    return RedirectToAction("Index");
                }
                TempData["error"] = "Unable to create category!";
            }
            return View(viewModel);
        }
    }
}
