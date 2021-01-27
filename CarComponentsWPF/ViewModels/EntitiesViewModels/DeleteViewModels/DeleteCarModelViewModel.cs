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

namespace CarComponentsWPF.ViewModels
{
    public class DeleteCarModelViewModel : DeleteEntityViewModel<CarModel>
    {
        public DeleteCarModelViewModel(IDataService<CarModel> service, CarModel entity) : base(service, entity)
        {
        }
        
        public string Name { get => _entity.Name; set { _entity.Name = value; OnPropertyChanged(Name); } }

    }
}