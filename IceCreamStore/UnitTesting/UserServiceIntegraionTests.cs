using repositories;

using Microsoft.Extensions.Configuration;
using Entities;
using DTOs;
using Services;
using Moq;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using AutoMapper;
using NLog.Extensions.Logging;
namespace UnitTesting
{
    public class UserServiceIntegraionTests : IClassFixture<DbFixure>
    {
        private readonly webApiServerContext _dbContext;
        private readonly UserService userService;
        private readonly IConfiguration _configuration;
        private IMapper _mapper;
        ILogger<UserService> logger;
        public UserServiceIntegraionTests(DbFixure dbFixure)
        {
            _dbContext = dbFixure.Context;
            var mapperCongig= new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Services.Mapper>(); // use your actual profile class
            }); 
           _mapper = mapperCongig.CreateMapper(); 
            var loggerFactory=LoggerFactory.Create(builder =>
            {
                builder.ClearProviders();
                builder.SetMinimumLevel(LogLevel.Information);
                builder.AddNLog("nlog.config");
            }); 
             logger=loggerFactory.CreateLogger<UserService>();
            var mockConfiguration = new Mock<IConfiguration>(); 
            _configuration = mockConfiguration.Object;

            //IMapper _mapper = config.CreateMapper();
            var mockContext = new Mock<webApiServerContext>();

            UserRepository userRepository = new UserRepository(_dbContext, _configuration); ;
            userService = new UserService(userRepository, _mapper, logger);
        }
        
        [Fact]
        public async Task AddUser_ValidMultiplied_ReturnsUser()
        {
            User user = new User { Email = "aaa@gmail.com", LastName = "a", FirstName = "b", Password = "1234" };
            User user2 = await userService.addUser(user);
            Assert.Equal(user,user2);

        }

      


        //[Fact]
        //public async Task Logint_LogToFile()
        //{
        //    string logFileName = Path.Combine("Logs", $"app-{DateTime.Now:yyyy-MM-dd}.log");
        //    //Assert.True(File.Exists(logFileName), $"Log file {logFileName} does not exist.");
        //    //var logContent = File.ReadAllText(logFileName);
        //    //Assert.False(string.IsNullOrWhiteSpace(logContent), "Log file is empty.");
        //    var login = new UserLogin { Email = "m025863821@gmail.com", Password = "1234" };
        //    await userService.login(login);
        //    var logContent = File.ReadAllText(logFileName);
        //    Assert.Contains("Login attempted with User Email m025863821@gmail.com and password 1234", logContent); // Check if the log file contains the expected content
        //}
    }


}
