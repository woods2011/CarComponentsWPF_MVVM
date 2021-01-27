using CarComponentsWPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarComponentsWPF.ViewModels
{
    public class MessageViewModel : BaseViewModel
    {
        private string _message;
        public string Message { get => _message; set { OnPropertyChanged(ref _message, value); OnPropertyChanged(nameof(HasMessage)); } }

        public bool HasMessage => !string.IsNullOrEmpty(Message);


        public ICommand OkCommand => new ActionCommand(p => Message = String.Empty);


        public override bool IsValid => true;
        public override string this[string columnName] => String.Empty;
        public override string Error => String.Empty;
    }
}
