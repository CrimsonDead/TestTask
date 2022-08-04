using dataLayer.Context;
using dataLayer.Models;

namespace dataLayer.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public User AddItem(User item)
        {
            _context.Users.Add(item);
            _context.SaveChanges();
            return item;
        }

        public User Delete(User item)
        {
            _context.Users.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public User GetItem(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UniqNumber == id);
        }

        public IEnumerable<User> GetItems()
        {
            return _context.Users.ToList();
        }

        public User Update(User item)
        {
            _context.Users.Update(item);
            _context.SaveChanges();
            return _context.Users.First(u => u == item);
        }
    }
}
