using BabyProductShop;
using System.Text.Json;

namespace Repositories
{
    public class UserRepositroy
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "users.txt");

        //public List<User> getUsers()
        //{

        //}

        public User getUserById(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        return user;
                }
            }
            return null;
        }

        public User update(User userToUpdate,int id)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(filePath, text);
                return userToUpdate;
            }
            return null;
        }

        public User login(LoginUser value)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                try
                {
                    while ((currentUserInFile = reader.ReadLine()) != null)
                    {
                        User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                        if (user.Username == value.Username && user.Password == value.Password)
                            return user;
                    }
                }
                catch
                {
                    return null;
                }

            }
            return null;
        }

        public User addUser(User user)
        {
            int numberOfUsers = 0;
            try
            {
                numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            }
            catch
            {
            }
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return user;
        }

        //public Boolean deleteUser()
        //{

        //}
    }
}
