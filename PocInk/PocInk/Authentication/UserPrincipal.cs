using System;
using System.Linq;
using System.Security.Principal;

namespace PocInk.Authentication
{
    public class UserPrincipal : IPrincipal
    {
        private UserIdentity _identity;

        public UserIdentity Identity
        {
            //untill we set it this will be an Unauthenticated User
            get { return _identity ?? new AnonymousIdentity(); }
            set { _identity = value; }
        }

        #region IPrincipal Members
        IIdentity IPrincipal.Identity
        {
            get { return this.Identity; }
        }

        public bool IsInRole(string role)
        {
            return _identity.Role.Equals(role);
        }
        #endregion
    }
}
