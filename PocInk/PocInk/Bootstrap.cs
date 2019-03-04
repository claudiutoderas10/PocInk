
using GalaSoft.MvvmLight.Ioc;
using PocInk.Authentication;
using PocInk.ViewModels;

namespace PocInk
{
    public static class Bootstrap
    {
        public static void RegisterDependencies()
        {
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<IAuthenticationService, AuthenticationService>();

        }
    }
}
