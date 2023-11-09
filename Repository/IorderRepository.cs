using Entities;

namespace Repository
{
    public interface IorderRepository
    {
        Task<OrdersTbl> addNewOrder(OrdersTbl newOrder);
    }
}