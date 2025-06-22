using Entities;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.EntityFrameworkCore;
using repositories;
namespace UnitTesting
{
    public class UserRepositoryUnitTesting
    {
        [Fact]
        public async Task GetUser_ValidCredentials_ReturnsUser()//checking the login function
        {
            var user = new User { Email = "a@gmail.com", FirstName = "Esty", Id = 1, LastName = "Margi", Password = "1234" };
            var userLogin = new UserLogin { Email = "a@gmail.com" ,Password="1234"};
            var mockContext = new Mock<webApiServerContext>();
            var mockConfig = new Mock<IConfiguration>();

            var users = new List<User>() { user };
            mockContext.Setup(x=>x.Users).ReturnsDbSet(users);
            var userRepository = new UserRepository(mockContext.Object,mockConfig.Object);
            var result = await userRepository.login(userLogin);
            Assert.Equal(user, result);
        }

        //[Fact]
        //public async Task GetUser_validCredials_ReturnsNull()
        //{
        //    var user = new User { Email = "a@gmail.com", FirstName = "Esty", Id = 1, LastName = "Margi", Password = "1234" };
        //    var userLogin = new UserLogin { Email = "a@gmail.com", Password = "1243" };
        //    var mockContext = new Mock<webApiServerContext>();
        //    var users = new List<User>() { user };
        //    mockContext.Setup(x => x.Users).ReturnsDbSet(users);
        //    var userRepository = new UserRepository(mockContext.Object);
        //    var result = await userRepository.login(userLogin);
        //    Assert.Equal(null, result);
        //}

        //[Fact]
        //public async Task AddUser_ValidCredentials_ReturnsUser()
        //{
        //    var users = new List<User>();
        //    var user = new User { Email = "a@gmail.com", FirstName = "Esty", Id = 1, LastName = "Margi", Password = "1234" };
        //    var mockContext = new Mock<webApiServerContext>();
        //    mockContext.Setup(x => x.Users).ReturnsDbSet(users);
        //    var userRepository = new UserRepository(mockContext.Object);
        //    var result = await userRepository.addUser(user);
        //    Assert.Equal(user, result);

        //}
    }
}
