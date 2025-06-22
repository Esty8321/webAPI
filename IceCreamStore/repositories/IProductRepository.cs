using Entities;

namespace repositories
{

    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        public  Task<IEnumerable<Product>> GetProducts(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);

    }
}