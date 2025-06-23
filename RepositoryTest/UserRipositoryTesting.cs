using Xunit;
using Moq;
using Entities;
using Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using BabyProductShop;
using Moq.EntityFrameworkCore;
using DTOEntities;
using Microsoft.Extensions.Logging;
using Services;
using AutoMapper;

namespace RepositoryTest
{
    public class UserRepositoryUnitTesting
    {
        
        [Fact]
        public async Task RegisterAsync_AddsUser()
        {
            // Arrange
            var users = new List<User>();
            var mockContext = new Mock<Prudoct_Kategory_webApi>();
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            mockContext.Setup(x => x.Users.AddAsync(It.IsAny<User>(), default))
                .Callback<User, CancellationToken>((u, ct) => users.Add(u));
            mockContext.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<UserRepositroy>();
            var userRepository = new UserRepositroy(mockContext.Object, logger);
            var newUser = new User { Id = 2, Username = "new", Password = "pw2" };

            // Act
            var result = await userRepository.registerAsync(newUser);

            // Assert
            Assert.Equal(newUser, result);
            Assert.Contains(newUser, users);
        }

        [Fact]
        public async Task LoginAsync_ValidCredentials_ReturnsUser()
        {
            // Arrange
            var user = new User { Id = 1, Username = "user", Password = "pass" };
            var users = new List<User> { user };
            var mockContext = new Mock<Prudoct_Kategory_webApi>();
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<UserRepositroy>();

            var userRepository = new UserRepositroy(mockContext.Object, logger);
            var loginUser = new LoginUserDTO ( "user",  "pass" );

            // Act
            var result = await userRepository.loginAsync(loginUser);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user, result);
        }

        [Fact]
        public async Task UpdateAsync_UpdatesUser()
        {
            // Arrange
            var user = new User { Id = 1, Username = "user", Password = "pass" };
            var users = new List<User> { user };
            var mockContext = new Mock<Prudoct_Kategory_webApi>();
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            mockContext.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<UserRepositroy>();

            var userRepository = new UserRepositroy(mockContext.Object,logger);
            var updatedUser = new User { Id = 1, Username = "d07080120@gmail.com", Password = "pass!@DQQFF" };

            // Act
            var result = await userRepository.updateAsync(updatedUser, 1);

            // Assert
            Assert.Equal(updatedUser, result);
        }

        [Fact]
        public async Task GetAllUsersAsync_ReturnsAllUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, Username = "A", Password = "1" },
                new User { Id = 2, Username = "B", Password = "2" }
            };
            var mockContext = new Mock<Prudoct_Kategory_webApi>();
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<UserRepositroy>();

            var userRepository = new UserRepositroy(mockContext.Object, logger);

            // Act
            var result = await userRepository.getAllUsersAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, u => u.Username == "A");
            Assert.Contains(result, u => u.Username == "B");
        }

        [Fact]
        public async Task LoginAsync_ReturnsUserDTO_WhenCredentialsAreValid_AndLogsInformation()
        {
            // Arrange
            var userRepoMock = new Mock<IUserRepositroy>();
            var loggerMock = new Mock<ILogger<UserServies>>();
            var mapperMock = new Mock<IMapper>();

            var loginDto = new LoginUserDTO ("test@email.com", "pw123");
            var userEntity = new User { Id = 1, Username = "test@email.com", Password = "pw123" };
            var userDto = new UserDTO (  "test@email.com",  "pw123", string.Empty, string.Empty,1);

            userRepoMock.Setup(r => r.loginAsync(It.IsAny<LoginUserDTO>())).ReturnsAsync(userEntity);
            mapperMock.Setup(m => m.Map<UserDTO>(userEntity)).Returns(userDto);

            var service = new UserServies(userRepoMock.Object, mapperMock.Object, loggerMock.Object);

            // Act
            var result = await service.loginAsync(loginDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("test@email.com", result.Username);

            // Verify the logger was called with LogInformation
            loggerMock.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Login attempted with user Name")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()
                ),
                Times.Once
            );
        }

        [Fact]
        public async Task LoginAsync_ReturnsNull_WhenUsernameOrPasswordIsNull()
        {
            // Arrange
            var userRepoMock = new Mock<IUserRepositroy>();
            var loggerMock = new Mock<ILogger<UserServies>>();
            var mapperMock = new Mock<IMapper>();
            var service = new UserServies(userRepoMock.Object, mapperMock.Object, loggerMock.Object);

            // Act & Assert
            Assert.Null(await service.loginAsync(new LoginUserDTO ( null,  "pw123" )));
            Assert.Null(await service.loginAsync(new LoginUserDTO ( "test@email.com",  null)));
        }
    }
}