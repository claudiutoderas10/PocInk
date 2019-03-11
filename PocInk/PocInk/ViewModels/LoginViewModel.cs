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

        public LoginViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            LoginCommand = new RelayCommand(Login,AuthenticationHelper.CanLogin);
        }

        private void Login()
        {
            AuthenticationHelper.Login(_authenticationService, Username, Password);
            Status=AuthenticationHelper.GetCurrentLoggedInUser();
            NavigateToMainPage();

        }
        private void NavigateToMainPage()
        {
            ////if(IsAuthenticated)
            ////{
            ////    // navigate
            ////}
        }
    }
}
