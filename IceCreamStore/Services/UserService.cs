using Entities;
using repositories;
namespace Services


{
    public class UserService : IUserService//??fix 
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;   
        }

        
        public async Task<User> getUserById(int id)
        {
            return  await _userRepository.getUserById(id);
        }

        public  async Task<User> addUser(User user)
        {
            return await _userRepository.addUser(user);
        }

        public Task<User> updateUser(User user)
        {
            return _userRepository.updateUser(user);
        }

        public async Task<User> login(UserLogin userLogin)
        {
            if (userLogin.Email == null || userLogin.Password == null)
                return null;
            return await _userRepository.login(userLogin);
        }

        public int powerOfPassword(String password)
        {
            if (password == null)
                return -1;

            int result = Zxcvbn.Core.EvaluatePassword(password).Score;
            return result;
        }
    }
}
