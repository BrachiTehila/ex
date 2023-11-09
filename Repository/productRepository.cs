using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{

    public class productRepository : IproductRepository
    {
        private  StoreDataBase2Context dbContext;
        public productRepository(StoreDataBase2Context dbContext)
        {
            this.dbContext = dbContext;
        }



        public async Task<IEnumerable<Product>> getAllProduct()
        {
            return await dbContext.Products.ToListAsync();
        }
    }
}
