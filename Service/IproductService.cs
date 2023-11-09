using Entities;

namespace Service
{
    public interface IproductService
    {
  
        Task<IEnumerable<Product>> getAllProduct();
       
        //Task<Product> getProductById(int id);
    }
}