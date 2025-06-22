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

        public async Task<IEnumerable<Product>> GetProducts(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            var query = objectContext.Products.Where(product =>
            (desc == null ? (true) : (product.Description.Contains(desc)))
            && ((minPrice == null) ? (true) : (product.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
                .OrderBy(product => product.Price);
            Console.WriteLine(query.ToQueryString());
            List<Product> products = await query.ToListAsync();
            return products;
        }
    }
}
