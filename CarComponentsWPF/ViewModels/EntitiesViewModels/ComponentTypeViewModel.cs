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
    public class ComponentTypeViewModel : EntityViewModel<ComponentType>
    {
        private bool _isSortName = false;


        static ComponentTypeViewModel()
        {
            //Поля для поиска
            _propForSearchList.Add(nameof(ComponentType.Name));
        }

        public ComponentTypeViewModel() : base(new GenericDataService<ComponentType>(), new ObservableCollection<ComponentType>())
        {
        }
        

        public bool IsSortName
        {
            get => _isSortName;
            set { 
                OnPropertyChanged(ref _isSortName, value);
                if (IsSortName)
                    AddSortDescriptor(nameof(ComponentType.Name));
                else
                    RemoveSortDescriptor(nameof(ComponentType.Name));
            }
        }

        protected override void GetWithFilterEntities() { return; }

        protected override void CreateEntity()
        {
            CreateEntity(new CreateComponentTypeViewModel(_dataService, null));
        }

        protected override void UpdateEntity()
        {
            var entity = SelectedEntity;
            if (entity != null)
                UpdateEntity(new UpdateComponentTypeViewModel(_dataService, entity));
        }

        protected override void DeleteEntity()
        {
            var entity = SelectedEntity;
            if (entity != null)
                DeleteEntity(new DeleteComponentTypeViewModel(_dataService, entity));
        }
    }
}