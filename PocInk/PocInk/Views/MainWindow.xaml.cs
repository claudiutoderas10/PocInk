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
using PocInkDataLayer;
using PocInkDataLayer.Models;

namespace PocInk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //This will be removed,only added to see if database works
            TestDb();
        }

        private void TestDb()
        {
            using (var context = new PocInkDBContext())
            {
                if (!context.Users.Any())
                {
                    context.Users.Add(new User { Id = Guid.NewGuid(), UserName = "Admin", Password = "12345" });
                }

                if (!context.InkDrawings.Any())
                {
                    context.InkDrawings.Add(new InkDrawing { DrawingId = Guid.NewGuid(), LocalFileId = 1, Title = "Cel mai frumos desen" });
                }

                context.SaveChanges();

                DrawingTitleTextBlock.Text = context.InkDrawings.FirstOrDefault().Title;
                UserNameTextBlock.Text = context.Users.FirstOrDefault().UserName;


            }

        }


    }
}
