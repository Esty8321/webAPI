using Entities;
using repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class CategoryRepositoryIntegretionTest : IClassFixture<DbFixure>
    {
        private readonly webApiServerContext _dbContext;
        private CategoryRepository _categoryRepository;
        public CategoryRepositoryIntegretionTest(DbFixure dbFixure)
        {
            _dbContext = dbFixure.Context;
            _categoryRepository = new CategoryRepository(_dbContext);
        }
        [Fact]
        public async Task GetAllCategories()
        {
            List<Category> categories = await _categoryRepository.GetAllCategories();
            Assert.NotNull(categories); // Ensure the list is not null
            if (categories.Count == 0)
            {
                // אפשר לעבור אם זה מצב תקין, או לכתוב אזהרה
                Console.WriteLine("אין קטגוריות ברשימה — נבדק רק שלא null");
                return;
            }
            foreach (var category in categories)
            {
                Assert.NotNull(category.CategoryName);
            }
        }
    }
}
