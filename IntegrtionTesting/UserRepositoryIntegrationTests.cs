//using Xunit;
//using Entities;
//using DTOEntities;
//using Repositories;
//using Microsoft.Extensions.Logging;
//using System.Linq;
//using System.Threading.Tasks;

//public class UserRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
//{
//    private readonly DatabaseFixture _fixture;
//    private readonly UserRepositroy _userRepository;

//    public UserRepositoryIntegrationTests(DatabaseFixture fixture)
//    {
//        _fixture = fixture;
//        var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
//        var logger = loggerFactory.CreateLogger<UserRepositroy>();
//        _userRepository = new UserRepositroy(_fixture.DbContext, logger);
//    }

//    [Fact]
//    public async Task RegisterAsync_AddsUser()
//    {
//        _fixture.ClearDatabase();
//        var newUser = new User { Id = 2, Username = "d07080120@gmail.com", Password = "pw2@#F$#T" };
//        var result = await _userRepository.registerAsync(newUser);
//        var users = await _userRepository.getAllUsersAsync();

//        Assert.NotNull(result);
//        Assert.Equal("d07080120@gmail.com", result.Username);
//        Assert.Contains(users, u => u.Username == "d07080120@gmail.com" && u.Password == "pw2@#F$#T");
//    }

//    [Fact]
//    public async Task UpdateAsync_UpdatesUserFields()
//    {
//        _fixture.ClearDatabase();
//        var user = new User { Id = 10, Username = "old", Password = "oldpw", FirstName = "A", LastName = "B" };
//        _fixture.DbContext.Users.Add(user);
//        await _fixture.DbContext.SaveChangesAsync();

//        var updated = new User { Username = "new", Password = "newpw", FirstName = "C", LastName = "D" };
//        var result = await _userRepository.updateAsync(updated, 10);

//        Assert.NotNull(result);
//        Assert.Equal("new", result.Username);
//        Assert.Equal("C", result.FirstName);
//        Assert.Equal("D", result.LastName);
//    }

//    [Fact]
//    public async Task LoginAsync_ReturnsUserIfCredentialsMatch()
//    {
//        _fixture.ClearDatabase();
//        var user = new User { Id = 3, Username = "login_user", Password = "pw123" };
//        _fixture.DbContext.Users.Add(user);
//        await _fixture.DbContext.SaveChangesAsync();

//        var dto = new LoginUserDTO { Username = "login_user", Password = "pw123" };
//        var result = await _userRepository.loginAsync(dto);

//        Assert.NotNull(result);
//        Assert.Equal(user.Id, result.Id);
//    }

//    [Fact]
//    public async Task GetAllUsersAsync_ReturnsAllUsers()
//    {
//        _fixture.ClearDatabase();
//        var users = new[] {
//            new User { Id = 11, Username = "a", Password = "1" },
//            new User { Id = 12, Username = "b", Password = "2" }
//        };
//        _fixture.DbContext.Users.AddRange(users);
//        await _fixture.DbContext.SaveChangesAsync();

//        var result = await _userRepository.getAllUsersAsync();
//        Assert.Equal(2, result.Count);
//        Assert.Contains(result, u => u.Username == "a");
//        Assert.Contains(result, u => u.Username == "b");
//    }
//}