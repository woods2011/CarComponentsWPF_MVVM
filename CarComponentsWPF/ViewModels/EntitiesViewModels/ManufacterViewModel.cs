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
    public class ManufacterViewModel : EntityViewModel<Manufacter>
    {
        private bool _isGroupCountry = false;
        private bool _isSortCountry = false;
        private bool _isSortName = false;


        static ManufacterViewModel()
        {
            //Поля для поиска
            _propForSearchList.Add(nameof(Manufacter.Name));
            _propForSearchList.Add(nameof(Manufacter.Contry));
        }

        public ManufacterViewModel() : base(new GenericDataService<Manufacter>(), new ObservableCollection<Manufacter>())
        {
        }
        

        public bool IsGroupCountry
        {
            get => _isGroupCountry;
            set
            {
                OnPropertyChanged(ref _isGroupCountry, value);
                if (IsGroupCountry)
                    AddGroupDescriptor(nameof(Manufacter.Contry));
                else
                    RemoveGroupDescriptor(nameof(Manufacter.Contry));
            }
        }
        public bool IsSortCountry
        {
            get => _isSortCountry;
            set { 
                OnPropertyChanged(ref _isSortCountry, value);
                if (IsSortCountry)
                    AddSortDescriptor(nameof(Manufacter.Contry));
                else
                    RemoveSortDescriptor(nameof(Manufacter.Contry));
            }
        }
        public bool IsSortName
        {
            get => _isSortName;
            set { 
                OnPropertyChanged(ref _isSortName, value);
                if (IsSortName)
                    AddSortDescriptor(nameof(Manufacter.Name));
                else
                    RemoveSortDescriptor(nameof(Manufacter.Name));
            }
        }

        protected override void GetWithFilterEntities() { return; }

        protected override void CreateEntity()
        {
            CreateEntity(new CreateManufacterViewModel(_dataService, null));
        }

        protected override void UpdateEntity()
        {
            var entity = SelectedEntity;
            if (entity != null)
                UpdateEntity(new UpdateManufacterViewModel(_dataService, entity));
        }

        protected override void DeleteEntity()
        {
            var entity = SelectedEntity;
            if (entity != null)
                DeleteEntity(new DeleteManufacterViewModel(_dataService, entity));
        }
    }
}

