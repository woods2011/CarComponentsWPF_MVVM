using CarComponentsWPF.Models;
using CarComponentsWPF.Services.DataServices;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.ComponentModel;

namespace CarComponentsWPF.ViewModels
{
    public class CarModelViewModel : EntityViewModel<CarModel>
    {
        private bool _isSortName = false;


        static CarModelViewModel()
        {
            //Поля для поиска
            _propForSearchList.Add(nameof(CarModel.Name));
        }

        public CarModelViewModel() : base(new GenericDataService<CarModel>(), new ObservableCollection<CarModel>())
        {
        }
        

        public bool IsSortName
        {
            get => _isSortName;
            set { 
                OnPropertyChanged(ref _isSortName, value);
                if (IsSortName)
                    AddSortDescriptor(nameof(CarModel.Name));
                else
                    RemoveSortDescriptor(nameof(CarModel.Name));
            }
        }

        protected override void GetWithFilterEntities() { return; }

        protected override void CreateEntity()
        {
            CreateEntity(new CreateCarModelViewModel(_dataService, null));
        }

        protected override void UpdateEntity()
        {
            var entity = SelectedEntity;
            if (entity != null)
                UpdateEntity(new UpdateCarModelViewModel(_dataService, entity));
        }

        protected override void DeleteEntity()
        {
            var entity = SelectedEntity;
            if (entity != null)
                DeleteEntity(new DeleteCarModelViewModel(_dataService, entity));
        }
    }
}
