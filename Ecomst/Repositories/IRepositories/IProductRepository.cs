using Ecomst.DTO;
using Ecomst.Entities;

namespace Ecomst.Repositories.IRepositories
{
    public interface IProductRepository
    {
        public bool Add(Product product);
        public bool Update(Product product);
        public SearchResult<Product> GetPageData(ProductSearch searchModel, string sortColumn, int start, int length);
    }
}
