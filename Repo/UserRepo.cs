using ProductSmallTask.Models;

namespace ProductSmallTask.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContexr _context;

        public UserRepo(ApplicationDbContexr context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.users.Add(user);
            _context.SaveChanges();
        }

        public User GetUSer(string email, string password)
        {
            return _context.users.Where(u => u.Email == email & u.Password == password).FirstOrDefault();
        }
    }
}
