using System.Security.Principal;

namespace PocInkOld.Authentication
{
    public class UserIdentity : IIdentity
    {
        public UserIdentity(string name, string email, string role)
        {
            Name = name;
            Email = email;
            Role = role;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Role { get; private set; }

        #region IIdentity Members
        public string AuthenticationType { get { return "Custom authentication"; } }

        public bool IsAuthenticated { get { return !string.IsNullOrEmpty(Name); } }
        #endregion
    }
}
