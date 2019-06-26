using PocInkDAL.Services;
using PocInkDataLayer;
using PocInkDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PocInk.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private IUserRepository _userRepository;
        public AuthenticationService()
        {
            _userRepository = new UserRepository(new PocInkDBContext());
        }
        public User AuthenticateUser(string username, string password)
        {
            User userData = GetUsers().FirstOrDefault(u => u.UserName.Equals(username)
                 && u.HashedPassword.Equals(AuthenticationHelper.CalculateHash(password, u.UserName)));
            if (userData == null)
                throw new UnauthorizedAccessException("Access denied. Please provide some valid credentials.");

            return new User { UserName = userData.UserName, Email = userData.Email, Role = userData.Role };
        }
              

        private List<User> GetUsers()
        {
            var users = _userRepository.GetUsers();
            return users.ToList();
        }
    }
}
