using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using CarComponentsWPF.Commands;
using CarComponentsWPF.Models;
using CarComponentsWPF.Views;

namespace CarComponentsWPF.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        private string _username = "abdasd";
        private string _password = "abdasd";

        public AccountViewModel()
        {
            TestCommand = new ActionCommand(p => TestFunc(), p => IsValid);
        }

        [Required(ErrorMessage = "Must not be empty.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Must be at least 5 characters.")]
        public string Username
        {
            get { return _username; }
            set
            {
                OnPropertyChanged(ref _username, value);
            }
        }


        [Required(ErrorMessage = "Must not be empty.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Must be at least 3 characters.")]
        public string Password
        {
            get { return _password; }
            set
            {
                OnPropertyChanged(ref _password, value);
            }
        }

        public ICommand TestCommand { get; }

        private void TestFunc()
        {
            //using (CarCompDB8Entities db = new CarCompDB8Entities())
            //{
            //    var manuf = db.Manufacters.FirstOrDefault();
            //    Console.WriteLine(manuf.Name);
            //    foreach (var el in manuf.Components)
            //    {
            //        Console.WriteLine(el.Manufacter.Name);
            //        break;
            //    }
            //}
            var window = new MainWindow();
            window.ShowDialog();

            Console.WriteLine("KEK!!!");
            return;
        }
    }
}
