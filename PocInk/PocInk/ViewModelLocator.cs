using GalaSoft.MvvmLight.Ioc;
using PocInk.ViewModels;

namespace PocInk
{
    public class ViewModelLocator
    {
        public LoginViewModel LoginInstance
        {
            get=> SimpleIoc.Default.GetInstance<LoginViewModel>();                    
        }
    }
}
