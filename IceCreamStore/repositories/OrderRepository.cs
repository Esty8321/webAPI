using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repositories
{
    public class OrderRepository : IOrderRepository
    {

        webApiServerContext objectContext;
        public OrderRepository(webApiServerContext objectContext)
        {
            this.objectContext = objectContext;
        }

        public async Task<Order> AddOrder(Order order)
        {
            await objectContext.Orders.AddAsync(order);
            await objectContext.SaveChangesAsync();
            return order;
        }
    }
}
