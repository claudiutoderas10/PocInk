using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using PocInkDataLayer;
using PocInkDataLayer.Models;
using PocInkDAL.Services;

namespace PocInk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IUserRepository _userRepository;
        private IInkDrawingRepository _inkDrawingRepository;

        public MainWindow()
        {
            InitializeComponent();
            var dbContext = new PocInkDBContext();

            _userRepository = new UserRepository(dbContext);
            _inkDrawingRepository = new InkDrawingRepository(dbContext);

            //This will be removed,only added to see if database works
            TestDb();
        }

        private void TestDb()
        {
            if (!_userRepository.GetUsers().Any())
            {
                _userRepository.InsertUser(new User { Id = Guid.NewGuid(), UserName = "Admin", HashedPassword = "12345" });
            }

            if (!_inkDrawingRepository.GetInkDrawings().Any())
            {
                _inkDrawingRepository.InsertInkDrawing(new InkDrawing { DrawingId = Guid.NewGuid(), Title = "Cel mai frumos desen" });
            }

            _userRepository.Save();
            _inkDrawingRepository.Save();


            var users = _userRepository.GetUsers();
            var inkDrawings = _inkDrawingRepository.GetInkDrawings();

            UserNameTextBlock.Text = users.FirstOrDefault().UserName;
            DrawingTitleTextBlock.Text = inkDrawings.FirstOrDefault().Title;

            _userRepository.Dispose();
            _inkDrawingRepository.Dispose();
        }

    }

}
