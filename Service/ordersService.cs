using Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ordersService : IordersService
    {
        private IorderRepository repository;
        public ordersService(IorderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<OrdersTbl> addNewOrder(OrdersTbl newOrder)
        {
            return await repository.addNewOrder(newOrder);


        }
    }
}
