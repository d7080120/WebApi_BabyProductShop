using BabyProductShop;
using DTOEntities;
using Entities;

namespace Repositories
{
    public interface IUserRepositroy
    {
        Task<User> registerAsync(User user);
        Task<User> loginAsync(UserDTO value);
        Task<User> updateAsync(User userToUpdate, int id);
        Task<List<User>> getAllUsersAsync();
    }
}