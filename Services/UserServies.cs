using BabyProductShop;
using Repositories;
using System.Text.Json;

namespace Services
{
    public class UserServies
    {
        UserRepositroy userRepositroy = new UserRepositroy();
        public User getUserById(int id)
        {
            return userRepositroy.getUserById(id);
        }

        public User update(User userToUpdate,int id)
        {
            if (userToUpdate.Username == null || userToUpdate.Password == null || userToUpdate.FirstName == null || userToUpdate.LastName == null)
            {
                return null;
            }
            return userRepositroy.update(userToUpdate,id);
        }

        public User login(LoginUser user)
        {
            if (user.Username == null || user.Password == null)
            {
                return null;
            }
            return userRepositroy.login(user);
        }

        public User addUser(User user)
        {
            if (user.Username == null || user.Password == null || user.FirstName == null || user.LastName == null)
            {
                return null;
            }
            return userRepositroy.addUser(user);
        }
        public int powerOfPassword(string password)
        {
            if (password==null||password=="")
            {
                return -1;
            }
            int result = Zxcvbn.Core.EvaluatePassword(password).Score;
            return result;
        }
      
        //public Boolean deleteUser()
        //{

        //}
    }
}
