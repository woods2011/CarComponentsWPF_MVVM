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
    public class ProviderViewModel : EntityViewModel<Provider>
    {
        private bool _isSortName = false;


        static ProviderViewModel()
        {
            //Поля для поиска
            _propForSearchList.Add(nameof(Provider.Name));
            _propForSearchList.Add(nameof(Provider.Address));
            _propForSearchList.Add(nameof(Provider.PhoneNum));
        }

        public ProviderViewModel() : base(new GenericDataService<Provider>(), new ObservableCollection<Provider>())
        {
        }
        

        public bool IsSortName
        {
            get => _isSortName;
            set { 
                OnPropertyChanged(ref _isSortName, value);
                if (IsSortName)
                    AddSortDescriptor(nameof(Provider.Name));
                else
                    RemoveSortDescriptor(nameof(Provider.Name));
            }
        }

        protected override void GetWithFilterEntities() { return; }

        protected override void CreateEntity()
        {
            CreateEntity(new CreateProviderViewModel(_dataService, null));
        }

        protected override void UpdateEntity()
        {
            var entity = SelectedEntity;
            if (entity != null)
                UpdateEntity(new UpdateProviderViewModel(_dataService, entity));
        }

        protected override void DeleteEntity()
        {
            var entity = SelectedEntity;
            if (entity != null)
                DeleteEntity(new DeleteProviderViewModel(_dataService, entity));
        }
    }
}