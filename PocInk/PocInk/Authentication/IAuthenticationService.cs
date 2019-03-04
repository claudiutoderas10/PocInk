using PocInkDataLayer.Models;

namespace PocInk.Authentication
{
    public interface IAuthenticationService
    {
        User AuthenticateUser(string username, string password);
    }
}
