using Entities;

namespace Repository
{
    public interface IcategoryRepository
    {
    
        Task<IEnumerable<Category>> getAllCategories();
    }
}