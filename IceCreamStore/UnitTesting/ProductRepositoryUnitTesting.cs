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
    public class ProductRepositoryUnitTesting
    {
        [Fact]
        public async Task GetAllProducts_ValidCredentilals_ReturnsUser()
        {
            var product = new Product { Name="",CategoryId=1,Description="",Price=34,ImagePath="aa",Id=1,};
            var products= new List<Product> { product };
            var mockContext = new Mock<webApiServerContext>();
            mockContext.Setup(x => x.Products).ReturnsDbSet(products);
            var productRepository = new ProductRepository(mockContext.Object);
            var result = await productRepository.GetAllProducts();
            Assert.Equal(products, result);
        }
    }
}
