using AutoMapper;
using Entities;
using Microsoft.Extensions.Configuration;
using Moq;
using repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class UserRepositoryIntegrationTest : IClassFixture<DbFixure>
    {
        private readonly webApiServerContext _dbContext;
        //private readonly IMapper mapper;
        private UserRepository _userRepository;
        public UserRepositoryIntegrationTest(DbFixure dbFixure)
        {
            //var mapperConfiguration = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<Services.Mapper>();
            //});
            //mapper = mapperConfiguration.CreateMapper();
            _dbContext=dbFixure.Context;
            var mockConfiguration = new Mock<IConfiguration>();

            _userRepository = new UserRepository(_dbContext, mockConfiguration.Object);

        }

        [Fact]
        public async Task addUser_validation()
        {
            User user = new User { Email = "a@gmail.com", FirstName = "a", LastName = "a", Password = "1" };
            User user2=await _userRepository.addUser(user);
            var userFromDb = _dbContext.Users.FirstOrDefault(u => u.Email == user.Email);

            Assert.NotNull(userFromDb); // לוודא שהמשתמש נשמר
            Assert.Equal(user.FirstName, userFromDb.FirstName);
            Assert.Equal(user.LastName, userFromDb.LastName);
            Assert.Equal(user.Password, userFromDb.Password);

        }
    }
}
