using Entities;


namespace Service
{
    public interface IuserService
    {
        Task<UsersTbl> addUser(UsersTbl user);
        int checkPassword(string password);
        Task<UsersTbl> getUserByEmailAndPassword(string email, string password);
        Task updateUser(int id, UsersTbl value);
        //Task<User> getUserById(int id);

    }
}