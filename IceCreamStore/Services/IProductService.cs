using DTOs;
using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllProducts();
        public Task<IEnumerable<ProductDTO>> GetProducts(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);

    }
}