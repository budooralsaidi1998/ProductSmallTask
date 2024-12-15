using ProductSmallTask.Models;

namespace ProductSmallTask.Service
{
    public interface IUserService
    {
        void AddUser(User user);
        User GetUser(string email, string password);
    }
}