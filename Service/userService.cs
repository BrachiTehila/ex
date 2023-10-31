using ex1;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Zxcvbn;


namespace Service
{
    public class userService : IuserService
    {
        IuserRepository repository;

        public userService(IuserRepository repository)
        {
            this.repository = repository;
        }
        public async Task<User> getUserByEmailAndPassword(string email, string password)
        {
            return await repository.getUserByEmailAndPassword(email, password);
        }
        public async Task<User> getUserById(int id)
        {
           return await repository.getUserById(id);
        }

        public async Task< User> addUser(User user)
        {
            int level = checkPassword(user.Password);
            if (level > 2)
                return await repository.addUser(user);
            return null;
        }


        public async Task updateUser(int id, User value)
        {
            await repository.updateUser(id, value);
        }
        public int checkPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }

    }
}
