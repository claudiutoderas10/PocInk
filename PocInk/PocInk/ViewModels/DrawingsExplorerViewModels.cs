using GalaSoft.MvvmLight.Command;
using PocInk.Navigation;

namespace PocInk.ViewModels
{
    public class DrawingsExplorerViewModel : PocInkViewModelBase
    {
        private readonly INavigationService _navigationService;

        public RelayCommand GoBack { get; }

        public DrawingsExplorerViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoBack = new RelayCommand(OnGoBack);
        }
        public override void OnNavigatedTo(object parameter = null)
        {
           
        }

        public override void OnNavigatingTo(object parameter = null)
        {
           
        }

        private void OnGoBack()
        {
            _navigationService.NavigateTo<LoginViewModel>(null);
        }
    }
}
