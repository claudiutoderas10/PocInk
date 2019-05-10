﻿using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using PocInkOld.Authentication;
using PocInkOld.Navigation;
using PocInkOld.ViewModels;

namespace PocInkOld
{
    public static class Bootstrap
    {
        public static void RegisterDependencies()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            RegisterViewModels();
            RegisterServices();          
        }

        private static void RegisterViewModels()
        {
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<DrawingsExplorerViewModel>();

        }

        private static void RegisterServices()
        {
            SimpleIoc.Default.Register<IAuthenticationService, AuthenticationService>();
            SimpleIoc.Default.Register<INavigationService, NavigationService>();

            SetupNavigationService();
        }

        private static void SetupNavigationService()
        {
            var navigationService = SimpleIoc.Default.GetInstance<INavigationService>();
            navigationService.AddNavigableElement(SimpleIoc.Default.GetInstance<LoginViewModel>);
            navigationService.AddNavigableElement(SimpleIoc.Default.GetInstance<DrawingsExplorerViewModel>);
          
        }
    }
}
