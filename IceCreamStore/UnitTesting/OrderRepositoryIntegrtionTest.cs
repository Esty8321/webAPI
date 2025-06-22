using Entities;
using repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class OrderRepositoryIntegrtionTest : IClassFixture<DbFixure>
    {
        private readonly webApiServerContext _dbContext;
        private OrderRepository _orderRepository;

        public OrderRepositoryIntegrtionTest(DbFixure dbFixure)
        {
            _dbContext = dbFixure.Context;
            _orderRepository = new OrderRepository(_dbContext);
        }

        [Fact]
        public async Task AddOrder_Validation()
        {
            Order order = new Order
            {
                //Id = 1, // Assuming a user with ID 1 exists
                Date= DateTime.Now,
                UserId = 1, // Assuming a user with ID 1 exists
                Price = 10.0,// Assuming a price for the order
                
            };
            Order addedOrder = await _orderRepository.AddOrder(order);
            var orderFromDb = _dbContext.Orders.FirstOrDefault(o => o.Id == addedOrder.Id);
            Assert.NotNull(orderFromDb); // Ensure the order was saved
            Assert.Equal(order.UserId, orderFromDb.UserId);
            //Assert.Equal(order.Id, orderFromDb.Id);
            Assert.Equal(order.Price, orderFromDb.Price);
            Assert.Equal(order.Date, orderFromDb.Date);
        }


    }
}
