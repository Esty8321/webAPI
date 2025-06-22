using Entities;
using Moq;
using Moq.EntityFrameworkCore;
using repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
  public class CategoryRepositryUnitTesting
    {
        [Fact]
        public async Task GetAllProducts_ValidCredentilals_ReturnsUser()
        {
            var category = new Category {CategoryName="aa",Id=1};
            var categories = new List<Category> { category };
            var mockContext = new Mock<webApiServerContext>();
            mockContext.Setup(x => x.Categories).ReturnsDbSet(categories);
            var categoryRepository = new CategoryRepository(mockContext.Object);
            var result = await categoryRepository.GetAllCategories();
            Assert.Equal(categories, result);
        }
    }
}
