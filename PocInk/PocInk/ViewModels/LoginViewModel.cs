using GalaSoft.MvvmLight.Command;
using PocInk.Authentication;
using PocInkDataLayer.Models;
using System;
using System.Threading;

namespace PocInk.ViewModels
{
    public class LoginViewModel : PocInkViewModelBase
    {
        private readonly IAuthenticationService _authenticationService;
        private string _username;
        private string _password;

        private string _status;

        public RelayCommand LoginCommand { get; }

        public string Username
        {
            get => _username;
            set { SetProperty(nameof(Username), ref _username, value); }
        }

        public string Password
        {
            get => _password;
            set { SetProperty(nameof(Password), ref _password, value); }
        }

        public string Status
        {
            get { return _status; }
            set { SetProperty(nameof(Status), ref _status, value); }
        }

        public string AuthenticatedUser
        {
            get
            {
                if (IsAuthenticated)
                    return string.Format("Signed in as {0}. {1}",
                          Thread.CurrentPrincipal.Identity.Name,
                          Thread.CurrentPrincipal.IsInRole("Administrators") ? "You are an administrator!"
                              : "You are NOT a member of the administrators group.");

                return "Not authenticated!";
            }
        }

        public bool IsAuthenticated
        {
            get { return Thread.CurrentPrincipal.Identity.IsAuthenticated; }
        }

        private bool CanLogin()
        {
            return !IsAuthenticated;
        }

        //private bool CanLogout(object parameter)
        //{
        //    return IsAuthenticated;
        //}


        public LoginViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            LoginCommand = new RelayCommand(Login,CanLogin);
        }

        private void Login()
        {
            try
            {
                //Validate credentials through the authentication service
                User user = _authenticationService.AuthenticateUser(Username, Password);

                //Get the current principal object
                UserPrincipal userPrincipal = Thread.CurrentPrincipal as UserPrincipal;
                if (userPrincipal == null)
                    throw new ArgumentException("The application's default thread principal must be set to a CustomPrincipal object on startup.");

                //Authenticate the user
                userPrincipal.Identity = new UserIdentity(user.UserName, user.Email, user.Role);

            }

            catch (UnauthorizedAccessException)
            {
                Status = "Login failed! Please provide some valid credentials.";
            }
            catch (Exception ex)
            {
                Status = string.Format("ERROR: {0}", ex.Message);
            }
        }
    }
}
