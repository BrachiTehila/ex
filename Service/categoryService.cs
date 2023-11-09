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
    public class categoryService : IcategoryService
    {
        private IcategoryRepository repository;
        public categoryService(IcategoryRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<Category>> getAllCategories()
        {
            return await repository.getAllCategories();

        }

    }
}
