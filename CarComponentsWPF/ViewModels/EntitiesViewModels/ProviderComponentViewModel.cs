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
using System.Windows.Input;
using CarComponentsWPF.Commands;
using Component = CarComponentsWPF.Models.Component;

namespace CarComponentsWPF.ViewModels
{
    public class ProviderComponentViewModel : EntityViewModel<ProviderComponent>
    {
        protected readonly IDataService<Component> _componentDataService;
        protected readonly IDataService<Provider> _providerDataService;

        private Component _selectedComponent = null;
        private Provider _selectedProvider = null;

        public List<Component> ComponentList { get; private set; }
        public List<Provider> ProviderlList { get; private set; }

        private bool _isSortRetailPrice = false;
        private bool _isSortQuantity = false;



        public ProviderComponentViewModel() : base(new ProviderComponentDataService(), new ObservableCollection<ProviderComponent>())
        {
            _componentDataService = new ComponentDataService();
            _providerDataService = new GenericDataService<Provider>();

            ComponentList = _componentDataService.GetAll().ToList();
            ProviderlList = _providerDataService.GetAll().ToList();
        }



        public Component SelectedComponent { get => _selectedComponent; set => OnPropertyChanged(ref _selectedComponent, value);}
        public Provider SelectedProvider { get => _selectedProvider; set => OnPropertyChanged(ref _selectedProvider, value); }

        public bool IsSortRetailPrice
        {
            get => _isSortRetailPrice;
            set
            {
                OnPropertyChanged(ref _isSortRetailPrice, value);
                if (IsSortRetailPrice)
                    AddSortDescriptor(nameof(ProviderComponent.RetailPrice));
                else
                    RemoveSortDescriptor(nameof(ProviderComponent.RetailPrice));
            }
        }

        public bool IsSortQuantity
        {
            get => _isSortQuantity;
            set
            {
                OnPropertyChanged(ref _isSortQuantity, value);
                if (IsSortQuantity)
                    AddSortDescriptor(nameof(ProviderComponent.Quantity));
                else
                    RemoveSortDescriptor(nameof(ProviderComponent.Quantity));
            }
        }



        protected override bool SearchEntities(object obj)
        {
            if (obj is ProviderComponent ProviderComponent)
            {
                var searchQueLow = CaseSensitive ? EntitiesSearchQuery : EntitiesSearchQuery.ToLower();

                if (CaseSensitive)
                    return
                        ProviderComponent.id.ToString().Contains(searchQueLow) ||
                        ProviderComponent.Component.Manufacter.Name.Contains(searchQueLow) ||
                        ProviderComponent.Component.ComponentType.Name.Contains(searchQueLow) ||
                        ProviderComponent.Component.CarModel.Name.Contains(searchQueLow) ||
                        ProviderComponent.Provider.Name.Contains(searchQueLow);
                else
                    return
                        ProviderComponent.id.ToString().ToLower().Contains(searchQueLow) ||
                        ProviderComponent.Component.Manufacter.Name.ToLower().Contains(searchQueLow) ||
                        ProviderComponent.Component.ComponentType.Name.ToLower().Contains(searchQueLow) ||
                        ProviderComponent.Component.CarModel.Name.ToLower().Contains(searchQueLow) ||
                        ProviderComponent.Provider.Name.ToLower().Contains(searchQueLow);
            }

            return false;
        }

        protected override void GetWithFilterEntities()
        {
            Dictionary<string, int> filterDictionary = new Dictionary<string, int>();

            var selectedComponent = SelectedComponent;
            var selectedProvider = SelectedProvider;

            if (selectedComponent != null)
                filterDictionary.Add(nameof(Component), selectedComponent.id);

            if (selectedProvider != null)
                filterDictionary.Add(nameof(Provider), selectedProvider.id);

            GetWithFilterEntities(filterDictionary);
        }

        protected override void CreateEntity()
        {
            CreateEntity(new CreateProviderComponentViewModel(_dataService, ComponentList, ProviderlList, null));
        }

        protected override void UpdateEntity()
        {
            var entity = SelectedEntity;
            if (entity != null)
                UpdateEntity(new UpdateProviderComponentViewModel(_dataService, ComponentList, ProviderlList, entity));
        }

        protected override void DeleteEntity()
        {
            var entity = SelectedEntity;
            if (entity != null)
                DeleteEntity(new DeleteProviderComponentViewModel(_dataService, entity));
        }



        public ICommand ResetFilterCommand => new ActionCommand(p => resetFilter());

        private void resetFilter()
        {
            SelectedComponent = null;
            SelectedProvider = null;
        }
    }
}




//private bool _isGroupManufacter = false;
//private bool _isGroupType = false;
//private bool _isGroupCarModel = false;

//private bool _isSortCarModel = false;

//static ComponentViewModel()
//{
//    //Поля для поиска
//    _propForSearchList.Add(nameof(ProviderComponent.id));
//    _propForSearchList.Add(nameof(ProviderComponent.Manufacter.Name));
//    _propForSearchList.Add(nameof(ProviderComponent.ComponentType.Name));
//    _propForSearchList.Add(nameof(ProviderComponent.CarModel.Name));
//}


//public bool IsGroupManufacter
//{
//    get => _isGroupManufacter;
//    set
//    {
//        OnPropertyChanged(ref _isGroupManufacter, value);
//        if (IsGroupManufacter)
//            AddGroupDescriptor(nameof(ProviderComponent.Manufacter.Name));
//        else
//            RemoveGroupDescriptor(nameof(ProviderComponent.Manufacter.Name));
//    }
//}

//public bool IsGroupType
//{
//    get => _isGroupType;
//    set
//    {
//        OnPropertyChanged(ref _isGroupType, value);
//        if (IsGroupType)
//            AddGroupDescriptor(nameof(ProviderComponent.ComponentType.Name));
//        else
//            RemoveGroupDescriptor(nameof(ProviderComponent.ComponentType.Name));
//    }
//}

//public bool IsGroupCarModel
//{
//    get => _isGroupCarModel;
//    set
//    {
//        OnPropertyChanged(ref _isGroupCarModel, value);
//        if (IsGroupCarModel)
//            AddGroupDescriptor(nameof(ProviderComponent.CarModel.Name));
//        else
//            RemoveGroupDescriptor(nameof(ProviderComponent.CarModel.Name));
//    }
//}


//public bool IsSortCarModel
//{
//    get => _isSortCarModel;
//    set { 
//        OnPropertyChanged(ref _isSortCarModel, value);
//        if (IsSortCarModel)
//            AddSortDescriptor(nameof(ProviderComponent.CarModel.Name));
//        else
//            RemoveSortDescriptor(nameof(ProviderComponent.CarModel.Name));
//    }
//}