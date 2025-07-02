using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        webApiServerContext objectContext;//_objectContext , change in all files
        public CategoryRepository(webApiServerContext objectContext)
        {
            this.objectContext = objectContext;//_objectContext = objectContext;
        }
        public async Task<List<Category>> GetAllCategories()
        {
            return await objectContext.Categories.ToListAsync();
        }
    }
}
