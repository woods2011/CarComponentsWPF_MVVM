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
    public class CreateManufacterViewModel : CreateEntityViewModel<Manufacter>
    {
        public CreateManufacterViewModel(IDataService<Manufacter> service, Manufacter entity) : base(service, entity)
        {
        }

        //public CreateManufacterViewModel() : base(new ManufacterDataService(), new Manufacter()) //Закомментировать
        //{
        //    throw new Exception("DesignTimeCTOR");
        //}


        [Required(ErrorMessage = "Название производителя не должно быть пустым")]
        public string Name { get => _entity.Name; set { _entity.Name = value; OnPropertyChanged(Name); } }

        [Required(ErrorMessage = "Название страны производителя не должно быть пустым")]
        public string Country { get => _entity.Contry; set { _entity.Contry = value; OnPropertyChanged(Country); } }

        //public CRUDoperationTypes CRUDType { get; } = CRUDoperationTypes.Create;
        //public override bool IsValid => true;
        //public override string this[string columnName] => String.Empty;
        //public override string Error => String.Empty;
    }
}


//[Required(ErrorMessage = "Название производителя не должно быть пустым")]
//public string Name { get => _entity?.Name; set { if (_entity != null) { _entity.Name = value; OnPropertyChanged(Name); } } }

//[Required(ErrorMessage = "Название страны производителя не должно быть пустым")]
//public string Country { get => _entity?.Contry; set { if (_entity != null) { _entity.Contry = value; OnPropertyChanged(Country); } } }