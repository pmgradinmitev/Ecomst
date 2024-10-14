using Ecomst.Entities;

namespace Ecomst.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        bool Add(Category entity);
        List<Category> ToList();

        Category? FindById(int? id);

        public bool Update(Category category);
        public bool Delete(int id);
        public Category? FindByName(string? name);
    }
}
