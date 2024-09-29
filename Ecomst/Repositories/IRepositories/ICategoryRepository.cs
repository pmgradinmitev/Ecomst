using Ecomst.Entities;

namespace Ecomst.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        bool Add(Category entity);
        List<Category> ToList();
    }
}
