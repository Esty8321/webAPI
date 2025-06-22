using Entities;

namespace repositories
{
    public interface IUserRepository
    {

        Task<User> addUser(User user);
        Task<User> getUserById(int id);
      Task <User> login(UserLogin userLogin);
        Task<User> updateUser(User userToUpdate);
    }
}