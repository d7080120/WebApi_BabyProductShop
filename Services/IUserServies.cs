using BabyProductShop;
using DTOEntities;
using Entities;

namespace Services
{
    public interface IUserServies
    {
        Task<User> registerAsync(User user);
        Task<User> loginAsync(UserDTO user);
        int powerOfPassword(string password);
        Task<User> updateAsync(User userToUpdate, int id);
        Task<List<User>> getAllUsersAsync();
    }
}