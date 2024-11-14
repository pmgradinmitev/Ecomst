using Ecomst.DTO;
using Ecomst.Entities;
using Ecomst.Helpers;

namespace Ecomst.Services.IServices
{
    public interface IProductService
    {
        public SearchResult<Product> Search(ProductSearch searchModel, string sortColumn, int start, int length);
    }
}
