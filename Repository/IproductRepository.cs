using Entities;

namespace Repository
{
    public interface IproductRepository
    {
    
        Task<IEnumerable<Product>> getAllProduct();
     
    }
}