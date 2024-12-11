using Ecomst.Data;
using Ecomst.DTO;
using Ecomst.Entities;
using Ecomst.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Ecomst.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public SearchResult<ApplicationUser> GetPageData(ApplicationUserSearch searchModel, string sortColumn, int start, int length)
        {
            IQueryable<ApplicationUser> query = _context.Set<ApplicationUser>();
            query = query.Include(s=>s.UserRoles).ThenInclude(s=>s.Role);
            int recordsTotal = query.Count();

            query = Search(searchModel, query);
            int recordsFiltered = query.Count();

            query = OrderBy(sortColumn, query);
            query = WithPagination(start, length, query);

            SearchResult<ApplicationUser> result = new SearchResult<ApplicationUser>();

            result.RecordsTotal = recordsTotal;
            result.RecordsFiltered = recordsFiltered;
            result.Data = query.ToList();
            return result;
        }

        private IQueryable<ApplicationUser> OrderBy(string value, IQueryable<ApplicationUser> query)
        {
            switch (value)
            {
                case "-userName":
                    return query.OrderByDescending(s => s.UserName);
                default:
                    return query.OrderBy(s => s.UserName);
            }
        }

        private IQueryable<ApplicationUser> WithPagination(int start, int length, IQueryable<ApplicationUser> query)
        {
            return query.Skip(start).Take(length);
        }

        private IQueryable<ApplicationUser> Search(ApplicationUserSearch searchModel, IQueryable<ApplicationUser> query)
        {
            //if (!String.IsNullOrEmpty(searchModel.CodeNumber))
            //    query = query.Where(s => s.CodeNumber!.ToUpper().Contains(searchModel.CodeNumber.ToUpper()));
            
            return query;
        }
    }
}
