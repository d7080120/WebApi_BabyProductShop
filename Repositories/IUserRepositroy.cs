using BabyProductShop;

namespace Repositories
{
    public interface IUserRepositroy
    {
        User addUser(User user);
        User getUserById(int id);
        User login(LoginUser value);
        User update(User userToUpdate, int id);
    }
}