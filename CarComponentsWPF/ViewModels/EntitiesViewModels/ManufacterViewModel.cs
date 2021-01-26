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
            //Поля для фильтрации
            _propForSearchList.Add(nameof(Manufacter.Name));
            _propForSearchList.Add(nameof(Manufacter.Contry));
        }

        public ManufacterViewModel() : base(new ManufacterDataService(), new ObservableCollection<Manufacter>())
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


        //protected override bool SearchEntities(object obj)
        //{
        //    if (obj is Manufacter manufacter)
        //    {
        //        var searchQueLow = EntitiesSearchQuery.ToLower();

        //        return manufacter.Name.ToLower().Contains(searchQueLow) ||
        //            manufacter.Contry.ToLower().Contains(searchQueLow);
        //    }

        //    return false;
        //}

        protected override void GetWithFilterEntities() { return; }

        protected override void CreateEntity()
        {
            CreateEntity(new CreateManufacterViewModel(_dataService, new Manufacter()));
        }

        protected override void UpdateEntity()
        {
            var entity = SelectedEntity;
            if (entity != null)
                UpdateEntity(new CreateManufacterViewModel(_dataService, entity));
        }

        protected override void DeleteEntity()
        {
            //var entity = SelectedEntity;
            //if (entity != null)
            //    DeleteEntity(new CreateManufacterViewModel(_dataService, entity));
        }
    }
}




//public bool IsGroupCountry { get => _isGroupCountry; set => OnPropertyChanged(ref _isGroupCountry, value); }
//public bool IsSortAscCountry { get => _isSortAscCountry; set { OnPropertyChanged(ref _isSortAscCountry, value); if (IsSortAscCountry) IsSortDescCountry = false; } }
//public bool IsSortDescCountry { get => _isSortDescCountry; set { OnPropertyChanged(ref _isSortDescCountry, value); if (IsSortDescCountry) IsSortAscCountry = false; } }
//public bool IsSortAscName { get => _isSortAscName; set => OnPropertyChanged(ref _isSortAscName, value); }
//public bool IsSortDescName { get => _isSortDescName; set => OnPropertyChanged(ref _isSortDescName, value); }