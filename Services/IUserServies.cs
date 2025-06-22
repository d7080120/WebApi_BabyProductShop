using BabyProductShop;
using DTOEntities;
using Entities;

namespace Services
{
    public interface IUserServies
    {
        Task<UserDTO> registerAsync(UserDTO user);
        Task<UserDTO> loginAsync(LoginUserDTO user);
        int powerOfPassword(string password);
        Task<UserDTO> updateAsync(UserDTO userToUpdate, int id);
        Task<List<UserDTO>> getAllUsersAsync();
    }
}