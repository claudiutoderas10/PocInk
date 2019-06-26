using GalaSoft.MvvmLight;
using PocInkOld.Navigation;

namespace PocInkOld.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public void ShowLoginView()
        {
            _navigationService.NavigateTo<LoginViewModel>(null);
        }
    }
}
