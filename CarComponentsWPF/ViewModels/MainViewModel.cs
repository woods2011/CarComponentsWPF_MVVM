using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarComponentsWPF.Commands;
using CarComponentsWPF.Services.DataServices;

namespace CarComponentsWPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        private bool _isAuth;

        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
            IsAuth = false;
            var VM = new LoginViewModel(new AuthenticationService());
            VM.LoginResultNotify += TryAuthHander;
            SelectedViewModel = VM;
        }


        public BaseViewModel SelectedViewModel { get => _selectedViewModel; set => OnPropertyChanged(ref _selectedViewModel, value); }

        public bool IsAuth { get => _isAuth; private set => OnPropertyChanged(ref _isAuth, value); }


        public ICommand UpdateViewCommand { get; set; }


        private void TryAuthHander(object sender, TryAuthResultEventArgs e)
        {
            if (SelectedViewModel is LoginViewModel curVM)
                if (sender is LoginViewModel logVM)
                    if (logVM == SelectedViewModel)
                        if (e.AuthResult.HasValue)
                            if (e.AuthResult.Value)
                            {
                                curVM.LoginResultNotify -= TryAuthHander;
                                IsAuth = true;
                                SelectedViewModel = new HomeViewModel();
                                return;
                            }

            Console.WriteLine("MaybeLogicError: TryAuthHander(object sender, TryAuthResultEventArgs e)");
        }


    }
}
