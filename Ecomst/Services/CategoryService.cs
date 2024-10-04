using Ecomst.Entities;
using Ecomst.Services.IServices;
using Ecomst.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ecomst.Services
{
    public class CategoryService : ICategoryService
    {
        private ModelStateDictionary? _modelState;
        private ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public List<Category> GetCategoryList()
        {
            return _repository.ToList();
        }

        public bool AddCategory(Category category)
        {
            try
            {
                return _repository.Add(category);
            }
            catch
            {
                return false;
            }
        }

        public Category? GetCategoryById(int? id) 
        {
            return _repository.FindById(id);
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                return _repository.Update(category);
            }
            catch
            {
                return false;
            }
        }
    }
}
