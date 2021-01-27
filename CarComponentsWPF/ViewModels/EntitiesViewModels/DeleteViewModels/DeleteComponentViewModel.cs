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
using Component = CarComponentsWPF.Models.Component;

namespace CarComponentsWPF.ViewModels
{
    public class DeleteComponentViewModel : DeleteEntityViewModel<Component>
    {
        public DeleteComponentViewModel(IDataService<Component> service, Component entity) : base(service, entity)
        {
        }

        public string ManufacterName { get => _entity.Manufacter.Name; }

        public string CompTypeName { get => _entity.ComponentType.Name; }

        public string CarModelName { get => _entity.CarModel.Name; }

        public string PrimeCost { get => _entity.PrimeCost.ToString(); }

    }
}