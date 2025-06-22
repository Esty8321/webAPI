using Moq;
using Services;
using Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using AutoMapper;
using repositories;
using DTOs;
using NLog.Extensions.Logging;
using Moq.EntityFrameworkCore;

public class UserServiceUnitTests
{
    [Fact]
    public async Task Login_LogExceptedMessage_WhenUSerExists()
    {
        var users = new List<User>
        {
            new User { Email = "m025863821@gmail.com", Password = "1234" ,FirstName="",LastName="",Id=1}
        };

        var userLogin = new UserLogin { Email = "m025863821@gmail.com", Password = "1234" };
        var mockContext = new Mock<webApiServerContext>();
        mockContext.Setup(x=>x.Users).ReturnsDbSet(users);

        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.ClearProviders();
            builder.SetMinimumLevel(LogLevel.Information);
            builder.AddNLog("nlog.config");
        });
        var logger=loggerFactory.CreateLogger<UserService>();
        
        var mockConfiguration=new Mock<IConfiguration>();

      
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<Services.Mapper>(); // Use your actual profile class
        });

        var mapper=mapperConfig.CreateMapper();


        UserRepository userRepository=new UserRepository(mockContext.Object, mockConfiguration.Object);
        UserService userService = new UserService(userRepository, mapper, logger);

        string logFileName = Path.Combine("Logs", $"app-{DateTime.Now:yyyy-MM-dd}.log");

        await userService.login(userLogin);
        NLog.LogManager.Shutdown(); 
        var logContent=File.ReadAllText(logFileName);   
        Assert.Contains("Login attempted with User Email, m025863821@gmail.com and password 1234", logContent);
        File.Delete(logFileName); // Clean up the log file after the test
    }
}
