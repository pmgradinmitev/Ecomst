using Ecomst.Data;
using Ecomst.DTO;
using Ecomst.Entities;
using Ecomst.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Ecomst.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public SearchResult<Product> GetPageData(ProductSearch searchModel, string sortColumn, int start, int length)
        {
            IQueryable<Product> query = _context.Set<Product>();
            query.Include("Category");
            int recordsTotal = query.Count();

            query = Search(searchModel, query);
            int recordsFiltered = query.Count();

            query = OrderBy(sortColumn, query);
            query = WithPagination(start, length, query);

            SearchResult<Product> result = new SearchResult<Product>();

            result.RecordsTotal = recordsTotal;
            result.RecordsFiltered = recordsFiltered;
            result.Data = query.ToList();
            return result;
        }

        private IQueryable<Product> OrderBy(string value, IQueryable<Product> query)
        {
            //switch (value)
            //{
            //    case "-category":
            //        return query.OrderByDescending(s => s.Name);
            //    case "-displayOrder":
            //        return query.OrderByDescending(s => s.DisplayOrder);
            //    case "displayOrder":
            //        return query.OrderBy(s => s.DisplayOrder);
            //    default:
            //        return query.OrderBy(s => s.Name);
            //}
            return query;
        }

        private IQueryable<Product> WithPagination(int start, int length, IQueryable<Product> query)
        {
            return query.Skip(start).Take(length);
        }

        private IQueryable<Product> Search(ProductSearch searchModel, IQueryable<Product> query)
        {
            //if (!String.IsNullOrEmpty(searchModel.Name))
            //    query = query.Where(s=>s.Name!.ToUpper().Contains(searchModel.Name.ToUpper()));
            //if (searchModel.DisplayOrder != null)
            //    query = query.Where(s => s.DisplayOrder == searchModel.DisplayOrder);
            return query;
        }
    }
}
