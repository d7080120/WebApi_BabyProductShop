using BabyProductShop;
using Entities;

namespace Services
{
    public interface IUserServies
    {
        Task<User> registerAsync(User user);
        Task<User> getUserByIdAsync(int id);
        Task<User> loginAsync(LoginUser user);
        int powerOfPassword(string password);
        Task<User> updateAsync(User userToUpdate, int id);
    }
}