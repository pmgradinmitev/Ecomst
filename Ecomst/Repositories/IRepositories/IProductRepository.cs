using Ecomst.DTO;
using Ecomst.Entities;

namespace Ecomst.Repositories.IRepositories
{
    public interface IProductRepository
    {
        public SearchResult<Product> GetPageData(ProductSearch searchModel, string sortColumn, int start, int length);
    }
}
