using PocInkDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PocInk.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public User AuthenticateUser(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = Guid.NewGuid(), UserName = "Mark", Email = "markCom@.com", HashedPassword = "MB5PYIsbI2YzCUe34Q5ZU2VferIoI4Ttd+ydolWV0OE=", Role = "Administrators" });
            users.Add(new User { Id = Guid.NewGuid(), UserName = "John", Email = "john@.com", HashedPassword = "hMaLizwzOQ5LeOnMuj+C6W75Zl5CXXYbwDSHWW9ZOXc="});


            User userData = users.FirstOrDefault(u => u.UserName.Equals(username)
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
    }
}
