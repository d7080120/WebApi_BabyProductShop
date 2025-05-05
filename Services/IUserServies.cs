using BabyProductShop;

namespace Services
{
    public interface IUserServies
    {
        User addUser(User user);
        User getUserById(int id);
        User login(LoginUser user);
        int powerOfPassword(string password);
        User update(User userToUpdate, int id);
    }
}