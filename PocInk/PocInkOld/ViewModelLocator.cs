using GalaSoft.MvvmLight.Ioc;
using PocInkOld.ViewModels;

namespace PocInkOld
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
