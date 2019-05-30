using PocInkDataLayer.Models;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace PocInk.Authentication
{
    public static class AuthenticationHelper
    {
        public static bool IsAdminLoggedIn()
        {
            return Thread.CurrentPrincipal.IsInRole("Admin");
        }
        public static bool IsAuthenticated
        {
            get { return Thread.CurrentPrincipal.Identity.IsAuthenticated; }
        }

        public static bool CanLogout()
        {
            return IsAuthenticated;
        }

        public static bool CanLogin()
        {
            return !IsAuthenticated;
        }

        public static string GetCurrentLoggedInUser()
        {
            if (IsAuthenticated)
                return string.Format("Signed in as {0}. {1}",
                      Thread.CurrentPrincipal.Identity.Name,
                      Thread.CurrentPrincipal.IsInRole("Admin") ? "You are an administrator!"
                          : "You are NOT a member of the administrators group.");

            return "Not authenticated!";
        }

        public static string CalculateHash(string clearTextPassword, string salt)
        {
            // Convert the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);
            // Use the hash algorithm to calculate the hash
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            // Return the hash as a base64 encoded string to be compared to the stored password
            return Convert.ToBase64String(hash);
        }

        public static void Login(IAuthenticationService authenticationService, string username, string password)
        {
            try
            {
                //Validate credentials through the authentication service
                User user = authenticationService.AuthenticateUser(username, password);

                //Get the current principal object
                UserPrincipal userPrincipal = Thread.CurrentPrincipal as UserPrincipal;
                if (userPrincipal == null)
                    throw new ArgumentException("The application's default thread principal must be set to a CustomPrincipal object on startup.");

                //Authenticate the user
                userPrincipal.Identity = new UserIdentity(user.UserName, user.Email, user.Role);

            }

            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException("Login failed! Please provide some valid credentials.");
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ERROR: {0}", ex.Message));
            }
        }
    }

}
