using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repositories
{
    public class ProductRepository : IProductRepository
    {
        webApiServerContext objectContext;
        public ProductRepository(webApiServerContext objectContext)
        {
            this.objectContext = objectContext;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await objectContext.Products.Include(p=>p.Category).ToListAsync();
        }

    }
}
