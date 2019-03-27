using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using PocInk.Authentication;
using PocInk.Navigation;

namespace PocInk.ViewModels
{
    public class LoginViewModel : PocInkViewModelBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly INavigationService _navigationService;

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

        public LoginViewModel(IAuthenticationService authenticationService, INavigationService navigationService)
        {
            _authenticationService = authenticationService;
            _navigationService = navigationService;
            LoginCommand = new RelayCommand(Login, AuthenticationHelper.CanLogin);
        }

        private void Login()
        {
            AuthenticationHelper.Login(_authenticationService, Username, Password);
            Status = AuthenticationHelper.GetCurrentLoggedInUser();
            NavigateToMainPage();

        }
        private void NavigateToMainPage()
        {
            if (AuthenticationHelper.IsAuthenticated)
            {
                SimpleIoc.Default.GetInstance<INavigationService>().NavigateTo<DrawingsExplorerViewModel>(null);
            }
        }

        public override void OnNavigatedTo(object parameter = null)
        {

        }

        public override void OnNavigatingTo(object parameter = null)
        {
            //cleanup
        }
    }
}
