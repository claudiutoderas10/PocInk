using PocInkDataLayer.Models;
using System.Collections.Generic;

namespace PocInk.Authentication
{
    public interface IAuthenticationService
    {
        User AuthenticateUser(string username, string password);
    }
}
