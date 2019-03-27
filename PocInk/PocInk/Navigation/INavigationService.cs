using PocInk.ViewModels;
using System;

namespace PocInk.Navigation
{
    public interface INavigationService
    {
       void AddNavigableElement(Func<PocInkViewModelBase> viewModelSingletonGetter);
       void NavigateTo<T>(object parameter); 
    }
}
