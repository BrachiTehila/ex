using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class orderRepository : IorderRepository
    {
        private StoreDataBase2Context dbContext;
        public orderRepository(StoreDataBase2Context dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<OrdersTbl> addNewOrder(OrdersTbl newOrder)
        {
            await dbContext.OrdersTbls.AddAsync(newOrder);
            await dbContext.SaveChangesAsync();
            return newOrder;


        }

    }
}
