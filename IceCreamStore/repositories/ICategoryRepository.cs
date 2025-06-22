using DTOs;
using Entities;

namespace repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
    }
}