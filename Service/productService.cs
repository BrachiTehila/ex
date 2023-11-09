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
    public class productService : IproductService
    {
        private productRepository repository;
        public productService(productRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Product>> getAllProduct()
        {
            return await repository.getAllProduct();
        }
    }
}
