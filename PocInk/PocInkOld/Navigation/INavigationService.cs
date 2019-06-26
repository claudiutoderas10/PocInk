using PocInkOld.ViewModels;
using System;

namespace PocInkOld.Navigation
{
    public interface INavigationService
    {
       void AddNavigableElement(Func<PocInkViewModelBase> viewModelSingletonGetter);
       void NavigateTo<T>(object parameter); 
    }
}
