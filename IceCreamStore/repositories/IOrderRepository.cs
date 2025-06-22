using Entities;

namespace repositories
{
    public interface IOrderRepository
    {
        Task<Order> AddOrder(Order order);
    }
}