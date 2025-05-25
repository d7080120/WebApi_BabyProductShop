using BabyProductShop;
using Entities;

namespace Repositories
{
    public interface IUserRepositroy
    {
        Task<User> registerAsync(User user);
        Task<User> loginAsync(LoginUser value);
        Task<User> updateAsync(User userToUpdate, int id);
        Task<List<User>> getAllUsersAsync();
    }
}