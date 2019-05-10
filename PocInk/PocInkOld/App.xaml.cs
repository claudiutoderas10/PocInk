using System;
using System.Windows;

namespace PocInkOld
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Authentication.UserPrincipal userPrincipal = new Authentication.UserPrincipal();
            AppDomain.CurrentDomain.SetThreadPrincipal(userPrincipal);
            Bootstrap.RegisterDependencies();
        }
    }
}
