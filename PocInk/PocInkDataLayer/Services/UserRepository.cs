using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PocInkDataLayer;
using PocInkDataLayer.Models;

namespace PocInkDAL.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly PocInkDBContext _context;

        public UserRepository(PocInkDBContext context)
        {
            _context = context;
        }

        public void DeleteUser(int userID)
        {
            User user = _context.Users.Find(userID);
            _context.Users.Remove(user);
        }

        public User GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public void InsertUser(User user)
        {
            _context.Users.Add(user);
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
