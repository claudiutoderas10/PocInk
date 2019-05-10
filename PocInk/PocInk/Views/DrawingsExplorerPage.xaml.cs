using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using System.Windows;
using System.Windows.Controls;

namespace PocInk
{    
    public partial class DrawingsExplorer : Page
    { 
        public DrawingsExplorer()
        {
            InitializeComponent();         
        }
        private void InkCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is Microsoft.Toolkit.Wpf.UI.Controls.InkCanvas)
            {
                inkCanvas.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Mouse | CoreInputDeviceTypes.Pen | CoreInputDeviceTypes.Touch;
            }
        }

    }

}
