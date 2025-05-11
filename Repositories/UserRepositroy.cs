using BabyProductShop;
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

        //string filePath = Path.Combine(Directory.GetCurrentDirectory(), "users.txt");

        //public List<User> getUsers()
        //{

        //}

        public async Task<User> getUserByIdAsync(int id)
        {
            User user =await _prudoct_Kategory_webApi.Users.FirstAsync((u) =>  u.Id == id);
            return user;
        }

        public async Task<User> updateAsync(User userToUpdate, int id)
        {
            _prudoct_Kategory_webApi.Users.Update(userToUpdate);
            await _prudoct_Kategory_webApi.SaveChangesAsync();
            return await Task.FromResult(userToUpdate);
        }

        public async Task< User >loginAsync(LoginUser value)
        {
            User user = await _prudoct_Kategory_webApi.Users.FirstAsync((u) => u.Password ==value.Password &&u.Username==value.Username);
            return user;
        }

        public async Task< User> registerAsync(User user)
        {
            await _prudoct_Kategory_webApi.Users.AddAsync(user);
            await _prudoct_Kategory_webApi.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>>getAllUsersAsync()
        {
            return await _prudoct_Kategory_webApi.Users.ToListAsync();
        }
        //public async Task<Boolean> deleteUser(int id)
        //{
           
        //}
    }
}
