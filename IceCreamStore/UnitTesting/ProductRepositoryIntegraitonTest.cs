using Entities;
using repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class ProductRepositoryIntegraitonTest : IClassFixture<DbFixure>
    {
        private readonly webApiServerContext _dbContext;
        private ProductRepository _productRepository;
        public ProductRepositoryIntegraitonTest(DbFixure dbFixure)
        {
            _dbContext = dbFixure.Context;
            _productRepository = new ProductRepository(_dbContext);
        }


        [Fact]
        public async Task getAllProducts()
        {
            List<Product> products = await _productRepository.GetAllProducts();

            Assert.NotNull(products); // Ensure the list is not null

            if (products.Count == 0)
            {
                // אפשר לעבור אם זה מצב תקין, או לכתוב אזהרה
                Console.WriteLine("אין מוצרים ברשימה — נבדק רק שלא null");
                return;
            }

            foreach (var product in products)
            {
                Assert.NotNull(product.Category);
                Assert.NotNull(product.Name);
                Assert.NotNull(product.Description);
            }
        }
    }
}
