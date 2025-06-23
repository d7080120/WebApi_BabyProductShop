//using Entities;
//using Repositories;
//using Services;

//namespace IntegrtionTesting
//{
//    public class UserRepositoryIntegrationTesting : IClassFixture<Prudoct_Kategory_webApi>
//    {
//        private readonly Prudoct_Kategory_webApi _dbContext;
//        private readonly UserRepositroy userRepositroy;

//        public UserServiceIntegrationTesting(Prudoct_Kategory_webApi dbContext)
//        {
//            _dbContext = dbContext;
//            userRepositroy = new UserRepositroy(_dbContext);
//        }
//        [Fact]
//        public async Task RegisterAsync_AddsUser()
//        {
//            // Arrange

//            var newUser = new User { Id = 2, Username = "new", Password = "pw2" };

//            // Act
//            var result = await userRepository.registerAsync(newUser);

//            // Assert
//            Assert.Equal(newUser, result);
//            Assert.Contains(newUser, users);
//        }
//    }
//}




using Xunit;
using Entities;
using Repositories;
using Microsoft.Extensions.Logging;

public class UserRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _fixture;
    private readonly UserRepositroy _userRepository;

    public UserRepositoryIntegrationTests(DatabaseFixture fixture)
    {
        _fixture = fixture;

        var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = loggerFactory.CreateLogger<UserRepositroy>();

        _userRepository = new UserRepositroy(_fixture.DbContext, logger);
    }

    [Fact]
    public async Task RegisterAsync_AddsUser()
    {
        // Arrange
        _fixture.ClearDatabase(); // מנקה לפני כל טסט
        var newUser = new User { Id = 2, Username = "d07080120@gmail.com", Password = "pw2@#F$#T" };

        // Act
        var result = await _userRepository.registerAsync(newUser);
        var users = await _userRepository.getAllUsersAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal("d07080120@gmail.com", result.Username);
        Assert.Contains(users, u => u.Username == "d07080120@gmail.com" && u.Password == "pw2@#F$#T");
    }
}