using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarComponentsWPF.ViewModels;

namespace CarComponentsWPF.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var param = parameter.ToString();
            Console.WriteLine(param);
            if (param == null)
                return;

            switch (param)
            {
                case "Home": viewModel.SelectedViewModel = new HomeViewModel(); break;
                case "Manufacter": viewModel.SelectedViewModel = new ManufacterViewModel(); break;
                case "ComponentType": viewModel.SelectedViewModel = new ComponentTypeViewModel(); break;
                case "CarModel": viewModel.SelectedViewModel = new CarModelViewModel(); break;
                case "Component": viewModel.SelectedViewModel = new ComponentViewModel(); break;
                case "Provider": viewModel.SelectedViewModel = new ProviderViewModel(); break;
            }

            return;
        }
    }
}
