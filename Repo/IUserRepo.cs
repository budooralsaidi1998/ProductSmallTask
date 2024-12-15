using ProductSmallTask.Models;

namespace ProductSmallTask.Repo
{
    public interface IUserRepo
    {
        void AddUser(User user);
        User GetUSer(string email, string password);
    }
}