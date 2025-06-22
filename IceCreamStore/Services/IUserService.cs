using DTOs;
using Entities;

namespace Services
{
    public interface IUserService
    {
       
        Task<User> addUser(User user);
        Task<UserDTO> getUserById(int id);
        Task<UserDTO> login(UserLogin userLogin);
        int powerOfPassword(string password);
        
        Task<User> updateUser(User user);
    }
}