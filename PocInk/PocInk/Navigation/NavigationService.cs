using PocInk.Navigation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows;

namespace PocInk.ViewModels
{
    public class NavigationService:INavigationService
    {
        private Dictionary<Type, Uri> _registeredViews;
        private Dictionary<Type, Func<PocInkViewModelBase>> _registeredViewModels;
        private List<string> _allXamlPages;     
        public PocInkViewModelBase CurrentViewModel;

        public NavigationService()
        {         
            _registeredViews = new Dictionary<Type, Uri>();
            _registeredViewModels = new Dictionary<Type, Func<PocInkViewModelBase>>();
            _allXamlPages = GetAllXamlPages();
        }

        private List<string> GetAllXamlPages()
        {
            // We find all xaml pages in the current project.   
            Assembly procInkProjectAssembly;
            procInkProjectAssembly = Assembly.GetExecutingAssembly();
            var stream = procInkProjectAssembly.GetManifestResourceStream(procInkProjectAssembly.GetName().Name + ".g.resources");
            var resourceReader = new ResourceReader(stream);
            List<string> pages = new List<string>();
            foreach (DictionaryEntry resource in resourceReader)
            {
                string s = resource.Key.ToString();
                if (s.Contains("page.baml"))
                {
                    pages.Add(s.Remove(s.IndexOf(".baml")));
                }
            }
            return pages;
        }

        private Type ResolveViewModelTypeFromSingletonGetterFunc<T>(Func<T> viewModelSingletonGetterFunc)
        {
            MethodInfo methodInfo = viewModelSingletonGetterFunc.Method;
            return methodInfo.ReturnParameter.ParameterType;
        }

        private Uri ResolvePageUriFromViewModelType(Type viewModelType)
        {
            string pageName = string.Empty;
            int index = viewModelType.Name.IndexOf("ViewModel");
            pageName = viewModelType.Name.Remove(index);
            string pagePath = String.Format("{0}.xaml", _allXamlPages.Where(page => page.Contains(pageName.ToLower())).FirstOrDefault());
            string cleanedPath = pagePath.Remove(0, "views/".Length); 
            return new Uri(cleanedPath, UriKind.Relative);
        }       

        private void NavigateTo(Type key, object parameter = null)
        {
            CurrentViewModel?.OnNavigatingTo(parameter);
            CurrentViewModel = _registeredViewModels[key].Invoke();
            Uri uri = _registeredViews[key];
            ((MainWindow)Application.Current.MainWindow).Frame.Source = uri;
            ((MainWindow)Application.Current.MainWindow).Frame.DataContext = CurrentViewModel;
            CurrentViewModel.OnNavigatedTo(parameter);
        }

        public void AddNavigableElement(Func<PocInkViewModelBase> viewModelSingletonGetter)
        {
            //It`s a Func,because we want our viewmodels to be instantiated only when we need them via IOC.
            //First we get the type of our viewmodel to register for the Func.
            Type vmType = ResolveViewModelTypeFromSingletonGetterFunc(viewModelSingletonGetter);
            Uri uriPage = ResolvePageUriFromViewModelType(vmType);
            _registeredViews.Add(vmType, uriPage);
            _registeredViewModels.Add(vmType, viewModelSingletonGetter);
        }

        public void NavigateTo<GenericNavigableViewModelType>(object parameter = null)
        {
            Type key = typeof(GenericNavigableViewModelType);
            NavigateTo(key, parameter);
        }

       
    }
}
