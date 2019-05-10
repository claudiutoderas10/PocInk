using PocInkDataLayer.Models;
using System.Collections.Generic;

namespace PocInkOld.Authentication
{
    public interface IAuthenticationService
    {
        User AuthenticateUser(string username, string password);
    }
}
