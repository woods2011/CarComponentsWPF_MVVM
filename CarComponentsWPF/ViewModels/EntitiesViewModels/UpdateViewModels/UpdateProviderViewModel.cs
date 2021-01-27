using CarComponentsWPF.Models;
using CarComponentsWPF.Services.DataServices;
using System;
using CarComponentsWPF.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace CarComponentsWPF.ViewModels
{
    public class UpdateProviderViewModel : UpdateEntityViewModel<Provider>
    {

        public UpdateProviderViewModel(IDataService<Provider> service, Provider entity) : base(service, entity)
        {
            //Name = _entity.Name;
            //PhoneNum = _entity.PhoneNum;
            //Address = _entity.Address;
        }

        [Required(ErrorMessage = "Название поставщика не должно быть пустым")]
        public string Name { get => _entity.Name; set { _entity.Name = value; OnPropertyChanged(Name); } }

        [Required(ErrorMessage = "Телефон не должен быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Телефон должен содержать как минимум 3 символа")]
        public string PhoneNum { get => _entity.PhoneNum; set { _entity.PhoneNum = value; OnPropertyChanged(PhoneNum); } }

        [Required(ErrorMessage = "Адрес не должен быть пустым")]
        public string Address { get => _entity.Address; set { _entity.Address = value; OnPropertyChanged(Address); } }

    }
}