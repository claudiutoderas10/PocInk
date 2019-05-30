using GalaSoft.MvvmLight.Command;
using PocInk.Authentication;
using PocInk.Navigation;
using PocInkDAL.Models;
using PocInkDAL.Services;
using PocInkDataLayer;
using PocInkDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PocInk.ViewModels
{
    public class AdminViewModel : PocInkViewModelBase
    {
        private readonly INavigationService _navigationService;
        private IUserRepository _userRepository;
        private string _username;
        private string _email;
        private List<string> _roles;
        private List<User> _users;
        private string _selecteduser;
        private string _selectedRole;


        public List<string> Roles
        {
            get => _roles;
            set => SetProperty(nameof(Roles), ref _roles, value);
        }
        public List<User> Users
        {
            get => _users;
            set => SetProperty(nameof(Users), ref _users, value);
        }
        public string SelectedRole
        {
            get => _selectedRole;
            set => SetProperty(nameof(SelectedRole), ref _selectedRole, value);

        }
        public string SelectedUser
        {
            get => _selecteduser;
            set => SetProperty(nameof(SelectedUser), ref _selecteduser, value);
        }
        public string Username
        {
            get => _username;
            set => SetProperty(nameof(Username), ref _username, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(nameof(Email), ref _email, value);
        }

        public RelayCommand SaveCommand { get; }
        public RelayCommand GoBack { get; }

        public RelayCommand<Guid> RemoveUser { get; }

        public AdminViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;
            _userRepository = new UserRepository(new PocInkDBContext());

            SaveCommand = new RelayCommand(OnSave);
            GoBack = new RelayCommand(OnGoBack);

            RemoveUser = new RelayCommand<Guid>(OnRemoveUser);
            Roles = new List<string> { Role.Admin.ToString(), Role.User.ToString() };
            Users = GetUsers();
        }

        public override void OnNavigatedTo(object parameter = null)
        {

        }

        public override void OnNavigatingTo(object parameter = null)
        {
            _userRepository.Dispose();
        }


        private void OnGoBack()
        {
            _navigationService.NavigateTo<LoginViewModel>(null);
        }

        private List<User> GetUsers()
        {
            var usersList = new List<User>();
            usersList = _userRepository.GetUsers().ToList();
            return usersList;
        }

        private void OnRemoveUser(Guid userId)
        {
            var userToRemove = Users.FirstOrDefault(x => x.Id == userId);
            _userRepository.DeleteUser(userToRemove.Id);

            _userRepository.Save();
            Users = GetUsers();
            RaisePropertyChanged(nameof(Users));

        }

        private void OnSave()
        {
            var user = new User { Email = Email, UserName = Username, Role = SelectedRole };

            user.HashedPassword = AuthenticationHelper.CalculateHash("12345", user.UserName);

            _userRepository.InsertUser(user);
            _userRepository.Save();

            Username = string.Empty;
            SelectedRole = string.Empty;
            Email = string.Empty;
            Users = GetUsers();

        }

    }
}
