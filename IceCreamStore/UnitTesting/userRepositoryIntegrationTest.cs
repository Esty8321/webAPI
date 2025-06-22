using Entities;
using Microsoft.Extensions.Configuration;
using Moq;
using repositories;


namespace UnitTesting
{
    public class UserRepositoryIntegrationTest : IClassFixture<DbFixure>
    {
        private readonly webApiServerContext _dbContext;
        private UserRepository _userRepository;
        public UserRepositoryIntegrationTest(DbFixure dbFixure)
        {
            _dbContext = dbFixure.Context;
            var mockConfiguration = new Mock<IConfiguration>();

            _userRepository = new UserRepository(_dbContext, mockConfiguration.Object);
        }

        [Fact]
        public async Task addUser_validation()
        {
            User user = new User { Email = "a@gmail.com", FirstName = "a", LastName = "a", Password = "1" };
            User user2 = await _userRepository.addUser(user);
            var userFromDb = _dbContext.Users.FirstOrDefault(u => u.Email == user.Email);

            Assert.NotNull(userFromDb); // לוודא שהמשתמש נשמר
            Assert.Equal(user.FirstName, userFromDb.FirstName.Trim());
            Assert.Equal(user.LastName, userFromDb.LastName.Trim());
            Assert.Equal(user.Password, userFromDb.Password.Trim());

        }

        [Fact]
        public async Task getUserByID_validation()
        {
            User user = new User { Email = "a@gmail.com", FirstName = "a", LastName = "a", Password = "1" };

            User userAdd = await _userRepository.addUser(user);
            User userGet = await _userRepository.getUserById(user.Id);
            Assert.NotNull(userGet);
            Assert.Equal(user.Password, userGet.Password);

        }

        [Fact]
        public async Task UpdateUser_validtion()
        {
            User user = new User { Email = "a@gmail.com", FirstName = "a", LastName = "a", Password = "1" };
            User userAdd = await _userRepository.addUser(user);

            userAdd.Email = "b@gmail.com";
            userAdd.FirstName = "b";
            userAdd.LastName = "b";
            userAdd.Password = "2";

            User userUpdated = await _userRepository.updateUser(userAdd);
            Assert.NotNull(userUpdated);
            //Assert.Equal(userUpdated.Email,userToUpdate.Email);
        }
    }
}
