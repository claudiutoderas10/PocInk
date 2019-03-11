using PocInk.Authentication;
using System;
using System.Windows;

namespace PocInk
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            UserPrincipal userPrincipal = new UserPrincipal();
            AppDomain.CurrentDomain.SetThreadPrincipal(userPrincipal);
            Bootstrap.RegisterDependencies();           
        }
    }
}
