using OrderManagementSystem.Command;
using OrderManagementSystem.Models;
using System.ComponentModel;
using System.Windows.Input;

namespace OrderManagementSystem.ViewModels
{
    public class UserManagerViewModel : ViewModelBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private string _firstName;
        private string _lastName;
        private string _email;
        private User _selectedUser;
        private BindingList<User> _users;

        public UserManagerViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Users = new BindingList<User>((System.Collections.Generic.IList<User>)_unitOfWork.UserManager.GetAll());
        }

        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        public User SelectedUser
        {
            get { return _selectedUser; }
            set { SetProperty(ref _selectedUser, value); }
        }

        public BindingList<User> Users
        {
            get { return _users; }
            set { SetProperty(ref _users, value); }
        }


        public ICommand AddUserCommand => new RelayCommand(AddUser, CanAddUser);
        public ICommand RemoveUserCommand => new RelayCommand(RemoveUser, CanRemoveUser);
        public ICommand EditUserCommand => new RelayCommand(EditUser, CanEdituser);

        private void AddUser()
        {
            User newUser = new User() { FirstName = this.FirstName, LastName = this.LastName, Email = this.Email };
            _unitOfWork.UserManager.Add(newUser);
            _unitOfWork.Save();

            Users.Add(newUser);
            ClearForm();
        }

        private bool CanAddUser()
        {
            return !string.IsNullOrWhiteSpace(FirstName)
                && !string.IsNullOrWhiteSpace(LastName)
                && !string.IsNullOrWhiteSpace(Email);
        }

        private void RemoveUser()
        {
            if (SelectedUser != null)
            {
                _unitOfWork.UserManager.Remove(SelectedUser);
                _unitOfWork.Save();
                Users.Remove(SelectedUser);

                ClearForm();
            }
        }

        private bool CanRemoveUser()
        {
            return SelectedUser != null;
        }

        private void EditUser()
        {
            if (SelectedUser != null)
            {
                if (this.FirstName != SelectedUser.FirstName)
                    SelectedUser.FirstName = this.FirstName;
                if (this.LastName != SelectedUser.LastName)
                    SelectedUser.LastName = this.LastName;
                if (this.Email != SelectedUser.Email)
                    SelectedUser.Email = this.Email;

                _unitOfWork.Save();

                int index = Users.IndexOf(SelectedUser);
                if (index >= 0)
                {
                    Users.ResetItem(index);
                }
                ClearForm();
            }
        }

        private bool CanEdituser()
        {
            return (SelectedUser != null)
                && !string.IsNullOrWhiteSpace(FirstName)
                && !string.IsNullOrWhiteSpace(LastName) 
                && !string.IsNullOrWhiteSpace(Email);
        }

        private void ClearForm()
        {
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.Email = string.Empty;
            this.SelectedUser = null;
        }
    }
}
