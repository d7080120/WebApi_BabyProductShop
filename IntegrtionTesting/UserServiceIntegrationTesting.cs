//using Entities;
//using Repositories;
//using Services;

//namespace IntegrtionTesting
//{
//    public class UserServiceIntegrationTesting : IClassFixture<Prudoct_Kategory_webApi>
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
