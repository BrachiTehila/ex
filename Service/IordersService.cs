using Entities;

namespace Service
{
    public interface IordersService
    {
        Task<OrdersTbl> addNewOrder(OrdersTbl newOrder);
    }
}