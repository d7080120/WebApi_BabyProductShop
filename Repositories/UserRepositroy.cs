using BabyProductShop;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Repositories
{
    public class UserRepositroy : IUserRepositroy
    {
        private readonly Baby_Prudocts_webApi _baby_Prudocts_webApi;

        public UserRepositroy(Baby_Prudocts_webApi baby_Prudocts_webApi)
        {
            _baby_Prudocts_webApi = baby_Prudocts_webApi;
        }

        //string filePath = Path.Combine(Directory.GetCurrentDirectory(), "users.txt");

        //public List<User> getUsers()
        //{

        //}

        public async Task<User> getUserById(int id)
        {
            User user =await _baby_Prudocts_webApi.Users.FirstAsync((u) =>  u.Id == id);
            return user;
        }

        public async Task<User> update(User userToUpdate, int id)
        {
            User user = await _baby_Prudocts_webApi.Users.FirstAsync((u) => u.Id == id);
            await _baby_Prudocts_webApi.Users.Update(userToUpdate);
            await _baby_Prudocts_webApi.SaveChangesAsync();
            return null;
        }

        public async Task< User >login(LoginUser value)
        {
            User user = await _baby_Prudocts_webApi.Users.FirstAsync((u) => u.Password ==value.Password &&u.UserName==value.Username);
            return user;
        }

        public async Task< User> addUser(User user)
        {
            //int numberOfUsers = 0;
            //try
            //{
            //    numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            //}
            //catch
            //{
            //}
            //user.UserId = numberOfUsers + 1;
            //string userJson = JsonSerializer.Serialize(user);
            //System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            //return user;
            User user = await _baby_Prudocts_webApi.Users.AddAsync(user);
            await _baby_Prudocts_webApi.SaveChangesAsync();
            return user;
        }

        //public Boolean deleteUser()
        //{

        //}
    }
}
