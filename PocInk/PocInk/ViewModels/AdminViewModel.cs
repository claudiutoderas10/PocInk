
using GalaSoft.MvvmLight.Command;
using PocInk.Helpers;
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

        public RelayCommand<Guid> RemoveUser { get; }

        public AdminViewModel()
        {
            _userRepository = new UserRepository(new PocInkDBContext());

            SaveCommand = new RelayCommand(OnSave);
            RemoveUser = new RelayCommand<Guid>(OnRemoveUser);
            Roles = new List<string> { Role.Admin.ToString(), Role.User.ToString() };
            Users = GetUsers();
        }

        public override void OnNavigatedTo(object parameter = null)
        {

        }

        public override void OnNavigatingTo(object parameter = null)
        {

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
            _userRepository.InsertUser(userToRemove);
            _userRepository.Save();
            Users = GetUsers();
            RaisePropertyChanged(nameof(Users));

        }

        private void OnSave()
        {
            foreach (var user in Users)
            {
                _userRepository.InsertUser(user);
            }
            _userRepository.Save();
        }       

    }
}
