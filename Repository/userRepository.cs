using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository
{
    public class userRepository : IuserRepository
    {
        private  StoreDataBase2Context dbContext;
        public userRepository(StoreDataBase2Context dbContext)
        {
            this.dbContext = dbContext;
        }
     

        public async Task<UsersTbl> getUserByEmailAndPassword(string email, string password)
        {
            return await dbContext.UsersTbls.Where(e => e.Password == password && e.Email == email).FirstOrDefaultAsync();
            
    

        }
        //public async Task<User> getUserById(int id)
        //{
        //}

        public async Task<UsersTbl> addUser(UsersTbl user)
        {
           await dbContext.UsersTbls.AddAsync(user);
           await dbContext.SaveChangesAsync();
            return user;


        }


        public async Task updateUser(UsersTbl newUser)
        {

           dbContext.UsersTbls.Update(newUser);
           await dbContext.SaveChangesAsync();
        }


    }
}
