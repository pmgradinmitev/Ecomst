﻿using Ecomst.Data;
using Ecomst.Entities;
using Ecomst.Repositories.IRepositories;

namespace Ecomst.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Category> ToList()
        {
            return _context.Categories.ToList();
        }
    }
}
