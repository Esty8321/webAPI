using Entities;
using repositories;
namespace Services


{
    public class UserService
    {
        UserRepository userRepository = new UserRepository();
      
        public User getUserById(int id)
        {
            return userRepository.getUserById(id);
        }

        public User addUser(User user)
        {
            return userRepository.addUser(user);
        }

        public User updateUser(User user)
        {
            return userRepository.updateUser(user);
        }

       public User login(UserLogin userLogin)
        {
            if (userLogin.Email == null || userLogin.Password == null)
                return null;
            return userRepository.login(userLogin);
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
