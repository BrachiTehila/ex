using ex1;

namespace Repository
{
    public interface IuserRepository
    {
        Task<User> addUser(User user);
        Task<User> getUserByEmailAndPassword(string email, string password);
        Task updateUser(int id, User value);
        Task<User> getUserById(int id);
    }
}