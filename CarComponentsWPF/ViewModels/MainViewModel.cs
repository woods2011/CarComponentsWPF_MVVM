using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarComponentsWPF.Commands;

namespace CarComponentsWPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                OnPropertyChanged(ref _selectedViewModel, value);
            }
        }

        public ICommand UpdateViewCommand { get; set; }


        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
            //SelectedViewModel2 = new AccountViewModel();
        }










        private object _selectedViewModel2;
        public object SelectedViewModel2
        {
            get { return _selectedViewModel2; }
            set
            {
                OnPropertyChanged(ref _selectedViewModel2, value);
            }
        }

        private bool _isVisible;
        public bool IsVisible { get => _isVisible; set { OnPropertyChanged(ref _isVisible, value); OnPropertyChanged(nameof(IsNotVisible)); } }

        public bool IsNotVisible { get => !IsVisible; }
    }
}
