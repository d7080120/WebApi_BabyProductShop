using BabyProductShop;
using DTOEntities;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepositroy : IUserRepositroy
    {
        private readonly Prudoct_Kategory_webApi _prudoct_Kategory_webApi;

        public UserRepositroy(Prudoct_Kategory_webApi prudoct_Kategory_webApi)
        {
            _prudoct_Kategory_webApi = prudoct_Kategory_webApi;
        }

        public async Task<User> updateAsync(User userToUpdate, int id)
        {
            _prudoct_Kategory_webApi.Users.Update(userToUpdate);
            await _prudoct_Kategory_webApi.SaveChangesAsync();
            return await Task.FromResult(userToUpdate);
        }

        public async Task<User>loginAsync(UserDTO value)
        {
            return await _prudoct_Kategory_webApi.Users.FirstOrDefaultAsync((u) => u.Password ==value.Password &&u.Username==value.Username);
             
        }

        public async Task<User> registerAsync(User user)
        {
            await _prudoct_Kategory_webApi.Users.AddAsync(user);
            await _prudoct_Kategory_webApi.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>>getAllUsersAsync()
        {
            return await _prudoct_Kategory_webApi.Users.ToListAsync();
        }
      
    }
}
