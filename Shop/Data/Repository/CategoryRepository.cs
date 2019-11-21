using Shop.Interfaces.Models;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IEnumerable<Category> AllCategories => _dbContext.Categories;
    }
}
