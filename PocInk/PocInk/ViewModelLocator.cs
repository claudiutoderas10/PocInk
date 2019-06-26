using GalaSoft.MvvmLight.Ioc;
using PocInk.ViewModels;

namespace PocInk
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModelInstance
        {
            get
            {
                return SimpleIoc.Default.GetInstance<MainViewModel>();
            }
        }
    }
}
