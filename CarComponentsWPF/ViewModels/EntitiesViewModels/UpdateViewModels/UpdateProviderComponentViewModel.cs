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
using Component = CarComponentsWPF.Models.Component;

namespace CarComponentsWPF.ViewModels
{
    public class UpdateProviderComponentViewModel : UpdateEntityViewModel<ProviderComponent>
    {
        private Component _selectedComponent;
        private Provider _selectedProvider;

        public List<Component> ComponentList { get; private set; }
        public List<Provider> ProviderList { get; private set; }


        public UpdateProviderComponentViewModel(IDataService<ProviderComponent> service, List<Component> componentfList, List<Provider> providerList, ProviderComponent entity) : base(service, entity)
        {
            ComponentList = componentfList;
            ProviderList = providerList;

            _selectedComponent = componentfList.FirstOrDefault(m => m.id == _entity.id_CarComp);
            _selectedProvider = providerList.FirstOrDefault(m => m.id == _entity.id_Provider);

            _entity.Component = null;
            _entity.Provider = null;
        }

        [Required(ErrorMessage = "Комплектующая должна быть выбрана")]
        public Component SelectedComponent { get => _selectedComponent; set { _selectedComponent = value; _entity.id_CarComp = value?.id ?? 0; } }

        [Required(ErrorMessage = "Поставщик должен быть выбран")]
        public Provider SelectedProvider { get => _selectedProvider; set { _selectedProvider = value; _entity.id_Provider = value?.id ?? 0; } }


        [Required(ErrorMessage = "Розничная цена должна быть больше 0")]
        public string RetailPriceStr
        {
            get => RetailPrice > 0 ? RetailPrice.ToString() : String.Empty;
            set
            {
                bool flag = Int32.TryParse(value, out int val);
                if (flag)
                    RetailPrice = val;
                else
                    RetailPrice = 0;
            }
        }

        public int RetailPrice
        {
            get => _entity.RetailPrice;
            set
            {
                if (value > 0)
                    _entity.RetailPrice = value;
                else
                    _entity.RetailPrice = 0;

                OnPropertyChanged(nameof(RetailPrice));
                OnPropertyChanged(nameof(RetailPriceStr));
            }
        }


        [Required(ErrorMessage = "Количесто должно быть больше 0")]
        public string QuantityStr
        {
            get => QuantityPrice > 0 ? QuantityPrice.ToString() : String.Empty;
            set
            {
                bool flag = Int32.TryParse(value, out int val);
                if (flag)
                    QuantityPrice = val;
                else
                    QuantityPrice = 0;
            }
        }

        public int QuantityPrice
        {
            get => _entity.Quantity;
            set
            {
                if (value > 0)
                    _entity.Quantity = value;
                else
                    _entity.Quantity = 0;

                OnPropertyChanged(nameof(QuantityPrice));
                OnPropertyChanged(nameof(QuantityStr));
            }
        }
    }
}