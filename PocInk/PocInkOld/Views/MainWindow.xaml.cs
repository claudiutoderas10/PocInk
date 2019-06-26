using PocInkOld.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PocInkOld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ((MainViewModel)DataContext).ShowLoginView(); // we need to have our view loaded to start navigating
            Frame.LoadCompleted += (s, e) => UpdateFrameDataContext();
            Frame.DataContextChanged += (s, e) => UpdateFrameDataContext();
        }

        private void UpdateFrameDataContext()
        {
            Page view = (Page)Frame.Content;
            if (view != null)
            {
                view.DataContext = Frame.DataContext;
            }
        }
    }
}
