using Entities;

namespace Service
{
    public interface IcategoryService
    {
    
        Task<IEnumerable<Category>> getAllCategories();
    }
}