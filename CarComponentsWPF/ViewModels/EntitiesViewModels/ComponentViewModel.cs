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
using Component = CarComponentsWPF.Models.Component;
using System.Windows.Input;
using CarComponentsWPF.Commands;

namespace CarComponentsWPF.ViewModels
{
    public class ComponentViewModel : EntityViewModel<Component>
    {
        protected readonly IDataService<Manufacter> _manufDataService;
        protected readonly IDataService<ComponentType> _compTypeDataService;
        protected readonly IDataService<CarModel> _carModelDataService;

        private Manufacter _selectedManuf = null;
        private ComponentType _selectedCompType = null;
        private CarModel _selectedCarModel = null;

        public List<Manufacter> ManufList { get; private set; }
        public List<ComponentType> CompTypeList { get; private set; }
        public List<CarModel> CarModelList { get; private set; }

        private bool _isSortPrimeCost = false;



        public ComponentViewModel() : base(new ComponentDataService(), new ObservableCollection<Component>())
        {
            _manufDataService = new GenericDataService<Manufacter>();
            _compTypeDataService = new GenericDataService<ComponentType>();
            _carModelDataService = new GenericDataService<CarModel>();

            ManufList = _manufDataService.GetAll().ToList();
            CompTypeList = _compTypeDataService.GetAll().ToList();
            CarModelList = _carModelDataService.GetAll().ToList();
        }



        public Manufacter SelectedManuf { get => _selectedManuf; set => OnPropertyChanged(ref _selectedManuf, value);}
        public ComponentType SelectedCompType { get => _selectedCompType; set => OnPropertyChanged(ref _selectedCompType, value); }
        public CarModel SelectedCarModel { get => _selectedCarModel; set => OnPropertyChanged(ref _selectedCarModel, value); }

        public bool IsSortPrimeCost
        {
            get => _isSortPrimeCost;
            set
            {
                OnPropertyChanged(ref _isSortPrimeCost, value);
                if (IsSortPrimeCost)
                    AddSortDescriptor(nameof(Component.PrimeCost));
                else
                    RemoveSortDescriptor(nameof(Component.PrimeCost));
            }
        }



        protected override bool SearchEntities(object obj)
        {
            if (obj is Component component)
            {
                var searchQueLow = CaseSensitive ? EntitiesSearchQuery : EntitiesSearchQuery.ToLower();

                if (CaseSensitive)
                    return
                        component.id.ToString().Contains(searchQueLow) ||
                        component.Manufacter.Name.Contains(searchQueLow) ||
                        component.ComponentType.Name.Contains(searchQueLow) ||
                        component.CarModel.Name.Contains(searchQueLow);
                else
                    return
                        component.id.ToString().ToLower().Contains(searchQueLow) ||
                        component.Manufacter.Name.ToLower().Contains(searchQueLow) ||
                        component.ComponentType.Name.ToLower().Contains(searchQueLow) ||
                        component.CarModel.Name.ToLower().Contains(searchQueLow);
            }

            return false;
        }

        protected override void GetWithFilterEntities()
        {
            Dictionary<string, int> filterDictionary = new Dictionary<string, int>();

            var selectedManuf = SelectedManuf;
            var selectedCompType = SelectedCompType;
            var selectedCarModel = SelectedCarModel;

            if (selectedManuf != null)
                filterDictionary.Add(nameof(Manufacter), selectedManuf.id);

            if (selectedCompType != null)
                filterDictionary.Add(nameof(ComponentType), selectedCompType.id);

            if (selectedCarModel != null)
                filterDictionary.Add(nameof(CarModel), selectedCarModel.id);

            GetWithFilterEntities(filterDictionary);
        }

        protected override void CreateEntity()
        {
            CreateEntity(new CreateComponentViewModel(_dataService, ManufList, CompTypeList, CarModelList, null));
        }

        protected override void UpdateEntity()
        {
            var entity = SelectedEntity;
            if (entity != null)
                UpdateEntity(new UpdateComponentViewModel(_dataService, ManufList, CompTypeList, CarModelList, entity));
        }

        protected override void DeleteEntity()
        {
            var entity = SelectedEntity;
            if (entity != null)
                DeleteEntity(new DeleteComponentViewModel(_dataService, entity));
        }



        public ICommand ResetFilterCommand => new ActionCommand(p => resetFilter());

        private void resetFilter()
        {
            SelectedManuf = null;
            SelectedCompType = null;
            SelectedCarModel = null;
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
//    _propForSearchList.Add(nameof(Component.id));
//    _propForSearchList.Add(nameof(Component.Manufacter.Name));
//    _propForSearchList.Add(nameof(Component.ComponentType.Name));
//    _propForSearchList.Add(nameof(Component.CarModel.Name));
//}


//public bool IsGroupManufacter
//{
//    get => _isGroupManufacter;
//    set
//    {
//        OnPropertyChanged(ref _isGroupManufacter, value);
//        if (IsGroupManufacter)
//            AddGroupDescriptor(nameof(Component.Manufacter.Name));
//        else
//            RemoveGroupDescriptor(nameof(Component.Manufacter.Name));
//    }
//}

//public bool IsGroupType
//{
//    get => _isGroupType;
//    set
//    {
//        OnPropertyChanged(ref _isGroupType, value);
//        if (IsGroupType)
//            AddGroupDescriptor(nameof(Component.ComponentType.Name));
//        else
//            RemoveGroupDescriptor(nameof(Component.ComponentType.Name));
//    }
//}

//public bool IsGroupCarModel
//{
//    get => _isGroupCarModel;
//    set
//    {
//        OnPropertyChanged(ref _isGroupCarModel, value);
//        if (IsGroupCarModel)
//            AddGroupDescriptor(nameof(Component.CarModel.Name));
//        else
//            RemoveGroupDescriptor(nameof(Component.CarModel.Name));
//    }
//}


//public bool IsSortCarModel
//{
//    get => _isSortCarModel;
//    set { 
//        OnPropertyChanged(ref _isSortCarModel, value);
//        if (IsSortCarModel)
//            AddSortDescriptor(nameof(Component.CarModel.Name));
//        else
//            RemoveSortDescriptor(nameof(Component.CarModel.Name));
//    }
//}