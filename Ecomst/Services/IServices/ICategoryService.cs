using Ecomst.Entities;

namespace Ecomst.Services.IServices
{
    public interface ICategoryService
    {
        public List<Category> GetCategoryList();
        bool AddCategory(Category category);
        Category? GetCategoryById(int? id);
        public bool UpdateCategory(Category category);
        public bool DeleteCategory(int id);
    }
}
