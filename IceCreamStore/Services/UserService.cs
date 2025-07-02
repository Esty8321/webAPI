using AutoMapper;
using DTOs;
using Entities;
using Microsoft.Extensions.Logging;
using repositories;
namespace Services


{
    public class UserService : IUserService//??fix //
    {
        public readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository,IMapper mapper,ILogger<UserService> logger)
        {
            _userRepository = userRepository;  
            _mapper = mapper;
            _logger = logger;
        }

        //i change this function and i need check if she still works!//
        public async Task<UserDTO> getUserById(int id)//GetUserById
        {
            User user= await _userRepository.getUserById(id);
           var userToReturn= _mapper.Map<UserDTO>(user);
            Console.WriteLine("userToReturn",userToReturn);//
            return userToReturn;
        }

        public  async Task<User> addUser(User user)//AddUser
        {
            return await _userRepository.addUser(user);
        }

        public Task<User> updateUser(User user)//UpdateUser
        {
            return _userRepository.updateUser(user);
        }

        public async Task<UserDTO> login(UserLogin userLogin)//Login
        {
            _logger.LogInformation("Login attempted with User Email, {0} and password {1}", userLogin.Email, userLogin.Password);

            if (userLogin.Email == null || userLogin.Password == null)
            {
                _logger.LogWarning("the user didn't insert some fields");
                return null;
            }
           User user= await _userRepository.login(userLogin);
            if (user == null)
            {
                _logger.LogError("invalild user try to insert for you site!!!");
            }
           return _mapper.Map<UserDTO>(user); 
        }

      
        public int powerOfPassword(String password)//PowerOfPassword
        {
            if (password == null)
                return -1;

            int result = Zxcvbn.Core.EvaluatePassword(password).Score;
            return result;
        }
    }
}
