using PocInkDAL.Services;
using PocInkDataLayer;
using PocInkDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PocInkOld.Authentication
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
                 && u.HashedPassword.Equals(CalculateHash(password, u.UserName)));
            if (userData == null)
                throw new UnauthorizedAccessException("Access denied. Please provide some valid credentials.");

            return new User { UserName = userData.UserName, Email = userData.Email, Role = userData.Role };
        }

        private string CalculateHash(string clearTextPassword, string salt)
        {
            // Convert the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);
            // Use the hash algorithm to calculate the hash
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            // Return the hash as a base64 encoded string to be compared to the stored password
            return Convert.ToBase64String(hash);
        }

        private List<User> GetUsers()
        {
            var users = _userRepository.GetUsers();
            _userRepository.Dispose();
            return users.ToList();
        }
    }
}
