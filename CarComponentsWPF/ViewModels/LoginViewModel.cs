using CarComponentsWPF.Commands;
using CarComponentsWPF.Services.DataServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarComponentsWPF.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private string _password;

        private readonly IAuthenticationService _authService;
        private readonly MessageViewModel _messageViewModel;

        public event TryAuthResultEventHandler LoginResultNotify;


        public LoginViewModel(IAuthenticationService authService)
        {
            _messageViewModel = new MessageViewModel();
            _authService = authService;
            TryAuthCommand = new ActionCommand(p => TryAuth(), p => IsValid);
            TestAuthCommand = new ActionCommand(p => TestAuth());
        }


        public MessageViewModel MessageViewModel => _messageViewModel;


        [Required(ErrorMessage = "Логин не должен быть пустым")]
        public string Username { get => _username; set => OnPropertyChanged(ref _username, value); }


        [Required(ErrorMessage = "Пароль не должен быть пустым")]
        public string Password { get => _password; set => OnPropertyChanged(ref _password, value); }


        public ICommand TryAuthCommand { get; }

        public ICommand TestAuthCommand { get; }


        private void TryAuth()
        {
            bool authResult = _authService.Login(_username, _password);
            if (authResult)
                LoginResultNotify?.Invoke(this, new TryAuthResultEventArgs(true, ""));
            else
                MessageViewModel.Message = "Неверный логин или пароль";

            return;
        }
        private void TestAuth()
        {
            Username = "TestUser2000";
            Password = "!Sfbovdolkntw2002";
        }

    }
}
