using Entities;

namespace repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
    }
}