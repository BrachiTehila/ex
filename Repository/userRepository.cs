using Entities;

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
        private readonly string pathFile = "M:\\Web-API\\ex1\\ex1\\data.txt";

        public async Task<UsersTbl> getUserByEmailAndPassword(string email, string password)
        {
            using (StreamReader reader = System.IO.File.OpenText(pathFile))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    UsersTbl user = JsonSerializer.Deserialize<UsersTbl>(currentUserInFile);
                 
                    if (user.Email == email && user.Password == password)
                        return user;
                }
            }
            return null;

        }
        //public async Task<User> getUserById(int id)
        //{
        //    using (StreamReader reader = System.IO.File.OpenText(pathFile))
        //    {
        //        string? currentUserInFile;
        //        while ((currentUserInFile = await reader.ReadLineAsync()) != null)
        //        {
        //            User user = JsonSerializer.Deserialize<User>(currentUserInFile);
        //            if (user.Id == id)
        //                return user;

        //        }
        //    }
        //    return null;

        //}

        public async Task<UsersTbl> addUser(UsersTbl user)
        {
            int numberOfUsers = System.IO.File.ReadLines(pathFile).Count();
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(pathFile, userJson + Environment.NewLine);
            return user;

        }


        public async Task updateUser(int id, UsersTbl value)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(pathFile))
            {
                string currentUserInFile;
                while ((currentUserInFile = await reader.ReadLineAsync()) != null)
                {

                    UsersTbl user =  JsonSerializer.Deserialize<UsersTbl>(currentUserInFile);
                    if (user.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = await System.IO.File.ReadAllTextAsync(pathFile);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(value));
                await System.IO.File.WriteAllTextAsync(pathFile, text);

            }

        }


    }
}
