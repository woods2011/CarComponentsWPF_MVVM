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
    public class UpdateComponentViewModel : UpdateEntityViewModel<Component>
    {
        private Manufacter _selectedManuf;
        private ComponentType _selectedCompType;
        private CarModel _selectedCarModel;

        public List<Manufacter> ManufList { get; private set; }
        public List<ComponentType> CompTypeList { get; private set; }
        public List<CarModel> CarModelList { get; private set; }


        public UpdateComponentViewModel(IDataService<Component> service, List<Manufacter> manufList, List<ComponentType> compTypesList, List<CarModel> carModelsList, Component entity) : base(service, entity)
        {
            ManufList = manufList;
            CompTypeList = compTypesList;
            CarModelList = carModelsList;

            _selectedManuf = manufList.FirstOrDefault(m => m.id == _entity.id_Manuf);
            _selectedCompType = compTypesList.FirstOrDefault(m => m.id == _entity.id_CompType);
            _selectedCarModel = carModelsList.FirstOrDefault(m => m.id == _entity.id_CarModel);

            _entity.Manufacter = null;
            _entity.ComponentType = null;
            _entity.CarModel = null;
        }

        [Required(ErrorMessage = "Производитель должен быть выбран")]
        public Manufacter SelectedManuf { get => _selectedManuf; set { _selectedManuf = value; _entity.id_Manuf = value?.id ?? 0; } }

        [Required(ErrorMessage = "Тип комплектующей должен быть выбран")]
        public ComponentType SelectedCompType { get => _selectedCompType; set { _selectedCompType = value; _entity.id_CompType = value?.id ?? 0; } }

        [Required(ErrorMessage = "Модель авто должа быть выбрана")]
        public CarModel SelectedCarModel { get => _selectedCarModel; set { _selectedCarModel = value; _entity.id_CarModel = value?.id ?? 0; } }


        [Required(ErrorMessage = "Себестоимость должна быть больше 0")]
        public string PrimeCostStr
        {
            get => PrimeCost > 0 ? PrimeCost.ToString() : String.Empty;
            set
            {
                bool flag = Int32.TryParse(value, out int val);
                if (flag)
                    PrimeCost = val;
                else
                    PrimeCost = 0;
            }
        }

        public int PrimeCost
        {
            get => _entity.PrimeCost;
            set
            {
                if (value > 0)
                    _entity.PrimeCost = value;
                else
                    _entity.PrimeCost = 0;

                OnPropertyChanged(nameof(PrimeCost));
                OnPropertyChanged(nameof(PrimeCostStr));
            }
        }
    }


    //[Required(ErrorMessage = "Название производителя не должно быть пустым")]
    //public string Name { get => _entity.Name; set { _entity.Name = value; OnPropertyChanged(Name); } }

    //[Required(ErrorMessage = "Название страны производителя не должно быть пустым")]
    //public string Country { get => _entity.Contry; set { _entity.Contry = value; OnPropertyChanged(Country); } }

}