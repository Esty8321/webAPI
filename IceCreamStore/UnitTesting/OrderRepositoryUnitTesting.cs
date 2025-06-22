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
   public class OrderRepositoryUnitTesting
    {

        [Fact]
        public async Task AddOrder_ValidCredentials_ReturnsOrder()
        {
            var orders = new List<Order>();
            var order = new Order { Id = 1, Price = 78, UserId = 2 };
            var mockContext = new Mock<webApiServerContext>();
            mockContext.Setup(x => x.Orders).ReturnsDbSet(orders);
            var orderRepository = new OrderRepository(mockContext.Object);
            var result = await orderRepository.AddOrder(order);
            Assert.Equal(order, result);

        }
    }
}
