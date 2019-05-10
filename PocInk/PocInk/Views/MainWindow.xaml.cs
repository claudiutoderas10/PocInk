﻿using System.Windows;
using System.Windows.Controls;
using PocInk.ViewModels;

namespace PocInk
{    
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
