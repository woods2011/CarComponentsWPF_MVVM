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
    public class DeleteProviderComponentViewModel : DeleteEntityViewModel<ProviderComponent>
    {
        public DeleteProviderComponentViewModel(IDataService<ProviderComponent> service, ProviderComponent entity) : base(service, entity)
        {
        }

        public string ComponentId { get => _entity.Component.id.ToString(); }

        public string ManufacterName { get => _entity.Component.Manufacter.Name; }

        public string CompTypeName { get => _entity.Component.ComponentType.Name; }

        public string CarModelName { get => _entity.Component.CarModel.Name; }

        public string ProviderName { get => _entity.Provider.Name; }

        public string RetailPrice { get => _entity.RetailPrice.ToString(); }

        public string Quantity { get => _entity.Quantity.ToString(); }

    }
}