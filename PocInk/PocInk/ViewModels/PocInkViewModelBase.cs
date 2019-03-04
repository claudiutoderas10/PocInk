using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;

namespace PocInk.ViewModels
{
    public class PocInkViewModelBase:ViewModelBase
    {
        public bool SetProperty<T>(string propertyName, ref T field, T newValue = default(T), List<RelayCommand> commands = null, bool broadcast = false)
        {
            if (!Set(nameof(propertyName), ref field, newValue))
                return false;

            RaisePropertyChanged(propertyName);
            commands?.ForEach(x => x.RaiseCanExecuteChanged());
            return true;
        }
    }
}
