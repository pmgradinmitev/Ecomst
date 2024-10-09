using Ecomst.Entities;
using Ecomst.Services.IServices;
using Ecomst.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Ecomst.Helpers;

namespace Ecomst.Services
{
    public class CategoryService : ICategoryService
    {
        private IValidationDictionary? _modelState;
        private ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public void SetModelStateDictionary(IValidationDictionary modelState)
        {
            _modelState = modelState;
        }

        public bool ValidateCategory(Category category)
        {
            if (_modelState == null)
                throw new ArgumentNullException(nameof(_modelState));

            if (category.Name.ToLower() == "test")
                _modelState.AddError("Name", "\"Test\" is an invalid value!");

            return _modelState.IsValid;
        }

        public List<Category> GetCategoryList()
        {
            return _repository.ToList();
        }

        public bool AddCategory(Category category)
        {
            try
            {
                if (!ValidateCategory(category))
                    return false;
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
                if (!ValidateCategory(category))
                    return false;
                return _repository.Update(category);
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCategory(int id) {
            return _repository.Delete(id);
        }
    }
}
