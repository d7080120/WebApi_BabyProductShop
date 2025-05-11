using BabyProductShop;
using Entities;

namespace Repositories
{
    public interface IUserRepositroy
    {
        Task<User> addUser(User user);
        Task<User> getUserById(int id);
        Task<User> login(LoginUser value);
        Task<User> update(User userToUpdate, int id);
    }
}