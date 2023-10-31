using ex1;

namespace Service
{
    public interface IuserService
    {
        Task< User> addUser(User user);
        int checkPassword(string password);
        Task<User> getUserByEmailAndPassword(string email, string password);
        Task updateUser(int id, User value);
        Task<User> getUserById(int id);

    }
}