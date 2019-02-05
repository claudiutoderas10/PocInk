using System;
using System.Collections.Generic;
using PocInkDataLayer.Models;

namespace PocInkDAL.Services
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int userId);
        void InsertUser(User user);
        void DeleteUser(int userID);
        void UpdateUser(User user);
        void Save();
    }
}
