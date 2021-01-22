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
            TestCommand = new ActionCommand(p => TestFunc());
            TestCommand2 = new ActionCommand(p => TestFunc2());
        }


        public ICommand TestCommand { get; }

        public ICommand TestCommand2 { get; }

        private void TestFunc()
        {
            Console.WriteLine("KEK!!!");
            return;
        }

        private void TestFunc2()
        {
            Console.WriteLine("noKEK!!!");
            return;
        }
    }
}
