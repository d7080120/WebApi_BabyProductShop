using BabyProductShop;
using Entities;
using Repositories;
using System.Text.Json;

namespace Services
{
    public class UserServies : IUserServies
    {
        private readonly IUserRepositroy userRepositroy;
        public UserServies(IUserRepositroy ur)
        {
            userRepositroy = ur;
        }
       
        public async Task<User> updateAsync(User userToUpdate, int id)
        {
            if (userToUpdate.Username == null || userToUpdate.Password == null || userToUpdate.FirstName == null || userToUpdate.LastName == null)
            {
                return null;
            }
            List<User> users = await userRepositroy.getAllUsersAsync();
            foreach (var item in users)
            {
                if (userToUpdate.Username == item.Username)
                    return null;
            }
            int powerPassword = powerOfPassword(userToUpdate.Password);
            if (powerPassword >= 3)
                return await userRepositroy.updateAsync(userToUpdate, id);
            else
                throw new Exception("password is not strong");
        }

        public async Task<User> loginAsync(LoginUser user)
        {
            if (user.Username == null || user.Password == null)
            {
                return null;
            }
            return await userRepositroy.loginAsync(user);
        }

        public async Task<User> registerAsync(User user)
        {
            if (user.Username == null || user.Password == null || user.FirstName == null || user.LastName == null)
            {
                return null;
            }
            List<User> users = await userRepositroy.getAllUsersAsync();
            foreach (var item in users)
            {
                if (user.Username==item.Username)
                    return null;
            }
            int powerPassword = powerOfPassword(user.Password);
            if (powerPassword >= 3)
                return await userRepositroy.registerAsync(user);
            else
                throw new Exception("password is not strong");
        }
        public int powerOfPassword(string password)
        {
            if (password == null || password == "")
            {
                return -1;
            }
            int result = Zxcvbn.Core.EvaluatePassword(password).Score;
            return result;
        }

        public async Task<List<User>> getAllUsersAsync()
        {
            return await userRepositroy.getAllUsersAsync();
        }

    }
}
