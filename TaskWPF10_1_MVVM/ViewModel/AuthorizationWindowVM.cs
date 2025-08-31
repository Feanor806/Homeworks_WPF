using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskWPF10_1_MVVM.Commands;
using TaskWPF10_1_MVVM.Model;

namespace TaskWPF10_1_MVVM.ViewModel
{
    internal class AuthorizationWindowVM : INotifyPropertyChanged
    {
        private string? _username;
        public string? Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }
        private string? _password;
        public string? Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        private string _statusMessage = "Введите учетные данные";
        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                _statusMessage = value;
                OnPropertyChanged();
            }
        }
        private bool _isSuccess = false;
        public bool IsSuccess
        {
            get => _isSuccess;
            set { _isSuccess = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }

        private bool CanLoginCommandExecute(object? parameter)
        {
            return !(Username == null || Password == null || Username == String.Empty || Password == String.Empty);
        }
        private void OnLoginCommandExecute(object? parameter)
        {
            IsSuccess = AuthModel.Authenticate(Username, Password);

            StatusMessage = IsSuccess?"Успешный вход. Добро пожаловать!":"Введите учетные данные";
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AuthorizationWindowVM()
        {
            LoginCommand = new RelayCommand(OnLoginCommandExecute, CanLoginCommandExecute);
        }
    }
}
