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

namespace CarComponentsWPF.ViewModels
{
    public abstract class EntityViewModel<TEntity> : BaseViewModel where TEntity : class, IEntity
    {
        protected readonly IDataService<TEntity> _dataService;
        protected readonly ICollectionView _entitiesCollectionView;
        private string _entitiesSearchQuery = string.Empty;
        private TEntity _selectedEntity;
        protected readonly static List<string> _propForSearchList;

        private ICRUDViewModel _messageViewModel;
        private ICRUDViewModel _createEntityViewModel;
        private ICRUDViewModel _updateEntityViewModel;
        private ICRUDViewModel _deleteEntityViewModel;
        private bool _caseSensitive = false;

        static EntityViewModel() { _propForSearchList = new List<string>(); }
        public EntityViewModel(IDataService<TEntity> service, ObservableCollection<TEntity> entities) : base()
        {
            _dataService = service;
            Entities = entities;
            _entitiesCollectionView = CollectionViewSource.GetDefaultView(Entities);
            _entitiesCollectionView.Filter = SearchEntities;

            CreateEntityViewModel = null;
            UpdateEntityViewModel = null;
            DeleteEntityViewModel = null;
        }


        public ICRUDViewModel MessageViewModel { get => _messageViewModel; private set { OnPropertyChanged(ref _messageViewModel, value); OnPropertyChanged(nameof(IsMessageVMactive)); } }
        public ICRUDViewModel CreateEntityViewModel
        {
            get => _createEntityViewModel;
            private set
            {
                if (CreateEntityViewModel != null)
                    CreateEntityViewModel.CRUDcompleteNotify -= CreateHandler;
                OnPropertyChanged(ref _createEntityViewModel, value);
                OnPropertyChanged(nameof(IsCreateVMactive));
                OnPropertyChanged(nameof(IsGeneralVMactive));
                if (CreateEntityViewModel != null)
                    CreateEntityViewModel.CRUDcompleteNotify += CreateHandler;
            }
        }
        public ICRUDViewModel UpdateEntityViewModel
        {
            get => _updateEntityViewModel;
            private set
            {
                if (UpdateEntityViewModel != null)
                    UpdateEntityViewModel.CRUDcompleteNotify -= UpdateHandler;
                OnPropertyChanged(ref _updateEntityViewModel, value);
                OnPropertyChanged(nameof(IsUpdateVMactive));
                OnPropertyChanged(nameof(IsGeneralVMactive));
                if (UpdateEntityViewModel != null)
                    UpdateEntityViewModel.CRUDcompleteNotify += UpdateHandler;
            }
        }
        public ICRUDViewModel DeleteEntityViewModel
        {
            get => _deleteEntityViewModel;
            private set
            {
                if (DeleteEntityViewModel != null)
                    DeleteEntityViewModel.CRUDcompleteNotify -= DeleteHandler;
                OnPropertyChanged(ref _deleteEntityViewModel, value);
                OnPropertyChanged(nameof(IsDeleteVMactive));
                OnPropertyChanged(nameof(IsGeneralVMactive));
                if (DeleteEntityViewModel != null)
                    DeleteEntityViewModel.CRUDcompleteNotify += DeleteHandler;
            }
        }
        public bool IsMessageVMactive { get => MessageViewModel != null; }
        public bool IsCreateVMactive { get => CreateEntityViewModel != null; }
        public bool IsUpdateVMactive { get => UpdateEntityViewModel != null; }
        public bool IsDeleteVMactive { get => DeleteEntityViewModel != null; }
        public bool IsGeneralVMactive { get => !(IsCreateVMactive || IsUpdateVMactive || IsDeleteVMactive); }


        protected virtual bool SearchEntities(object obj)
        {
            if (obj is TEntity entity)
            {
                Type type = typeof(TEntity);
                string searchQueLow = CaseSensitive ? EntitiesSearchQuery : EntitiesSearchQuery.ToLower();
                string propValue;

                foreach (var prop in _propForSearchList)
                {
                    propValue = (type.GetProperty(prop)?.GetValue(entity) as String);
                    propValue = CaseSensitive ? propValue : propValue?.ToLower();
                    if (propValue?.Contains(searchQueLow) ?? true)
                        return true;
                }
            }

            return false;
        }

        protected void AddGroupDescriptor(string propName)
        {
            _entitiesCollectionView.GroupDescriptions.Add(new PropertyGroupDescription(propName));
        }
        protected void AddSortDescriptor(string propName)
        {
            _entitiesCollectionView.SortDescriptions.Add(new SortDescription(propName, ListSortDirection.Ascending));
        }

        protected void RemoveGroupDescriptor(string propName)
        {
            var propGroupDescr = _entitiesCollectionView.GroupDescriptions.OfType<PropertyGroupDescription>().FirstOrDefault(grd => grd.PropertyName == propName);
            if (propGroupDescr != null)
                _entitiesCollectionView.GroupDescriptions.Remove(propGroupDescr);
        }
        protected void RemoveSortDescriptor(string propName)
        {
            var propSortDescr = _entitiesCollectionView.SortDescriptions.FirstOrDefault(sd => sd.PropertyName == propName);
            if (propSortDescr != null)
                _entitiesCollectionView.SortDescriptions.Remove(propSortDescr);
        }
        protected void SwitchSortDescriptor(string propName)
        {
            var propSortDescr = _entitiesCollectionView.SortDescriptions.FirstOrDefault(sd => sd.PropertyName == propName);
            if (propSortDescr != default)
                propSortDescr.Direction = 1 - propSortDescr.Direction;
            //if (propSortDescr.Direction == ListSortDirection.Ascending)
            //    propSortDescr.Direction = ListSortDirection.Descending;
            //else
            //    propSortDescr.Direction = ListSortDirection.Ascending;
        }

        public ObservableCollection<TEntity> Entities { get; private set; }    //Заменить на ICollection

        public TEntity SelectedEntity { get => _selectedEntity; set { OnPropertyChanged(ref _selectedEntity, value); OnPropertyChanged(nameof(CanModify)); } } //Console.WriteLine(value?.id.ToString() ?? "null");

        public string EntitiesSearchQuery { get => _entitiesSearchQuery; set { OnPropertyChanged(ref _entitiesSearchQuery, value); _entitiesCollectionView.Refresh(); } }

        public bool CaseSensitive { get => _caseSensitive; set { _caseSensitive = value; _entitiesCollectionView.Refresh(); } }

        public bool CanModify { get => SelectedEntity != null; }



        public ICommand GetAllEntitiesCommand => new ActionCommand(p => GetAllEntities());

        public ICommand GetWithFilterEntitiesCommand => new ActionCommand(p => GetWithFilterEntities());

        /// <summary>
        /// Gets the command that invokes the creation of a new <see cref="Customer"/>.
        /// </summary>
        public ICommand CreateEntityCommand => new ActionCommand(p => CreateEntity());

        /// <summary>
        /// Gets the command that invokes the deletion of the <see cref="SelectedCustomer"/>.
        /// </summary>
        public ICommand DeleteEntityCommand => new ActionCommand(p => DeleteEntity(), p => CanModify);

        /// <summary>
        /// Gets the command that invokes an update of the <see cref="SelectedCustomer"/>.
        /// </summary>
        public ICommand UpdateEntityCommand => new ActionCommand(p => UpdateEntity(), p => CanModify);



        protected abstract void GetWithFilterEntities();

        protected void GetWithFilterEntities(Dictionary<string, int> filterDictionary)
        {
            Entities.Clear();
            SelectedEntity = null;

            foreach (var entity in _dataService.GetWithFilter(filterDictionary))
                Entities.Add(entity);
        }

        protected void GetAllEntities()
        {
            //Console.WriteLine("GetAllEntities");
            Entities.Clear();
            SelectedEntity = null;

            foreach (var entity in _dataService.GetAll())
            {
                Entities.Add(entity);
                //Console.WriteLine("anotherone");
            }
        }

        protected abstract void CreateEntity();
        protected void CreateEntity(ICRUDViewModel cRUDViewModel)
        {
            CreateEntityViewModel = cRUDViewModel;
        }
        protected void CreateHandler(object sender, CRUDOperationResultEventArgs result)
        {
            //var cVMcur = CreateEntityViewModel;
            //if (cVMcur != null)
            //{
            //    cVMcur.CRUDcompleteNotify -= CreateHandler;
            //    CreateEntityViewMode = null;
            //}
            //return;

            //На всякий случай

            var cVMcur = CreateEntityViewModel;

            if (sender is ICRUDViewModel cVM)
            {
                if (cVM != cVMcur)
                    Console.WriteLine("problemsCreate");
                cVM.CRUDcompleteNotify -= CreateHandler;
            }

            CreateEntityViewModel = null;


            if (result.CRUDResult.HasValue)
            {
                if (result.CRUDResult.Value)
                {
                    if (result.ResultEntity is TEntity entity)
                        Entities.Add(entity);
                }
                else
                {
                    string error = result.ErrorMessage;
                    if (!String.IsNullOrEmpty(error))
                        Console.WriteLine(error);           //Переделать
                }
            }
        }

        protected abstract void UpdateEntity();
        protected void UpdateEntity(ICRUDViewModel cRUDViewModel)
        {
            int? id = SelectedEntity?.id;
            if (id.HasValue)
            {
                UpdateEntityViewModel = cRUDViewModel;
            }
        }
        protected void UpdateHandler(object sender, CRUDOperationResultEventArgs result)
        {
            var cVMcur = UpdateEntityViewModel;

            if (sender is ICRUDViewModel cVM)
            {
                if (cVM != cVMcur)
                    Console.WriteLine("problemsUpdate");
                cVM.CRUDcompleteNotify -= UpdateHandler;
            }

            UpdateEntityViewModel = null;


            if (result.CRUDResult.HasValue)
            {
                if (result.CRUDResult.Value)
                {
                    if (result.ResultEntity is TEntity entity)
                    {
                        TEntity oldEntity = Entities.FirstOrDefault(p => p.id == entity.id);
                        if (oldEntity != null)
                        {
                            Entities.Add(entity);
                            if (SelectedEntity == oldEntity)
                                SelectedEntity = entity;
                            Entities.Remove(oldEntity);
                        }
                    }
                }
                else
                {
                    string error = result.ErrorMessage;
                    if (!String.IsNullOrEmpty(error))
                        Console.WriteLine(error);           //Переделать
                }
            }
        }

        protected abstract void DeleteEntity();
        protected void DeleteEntity(ICRUDViewModel cRUDViewModel)
        {
            int? id = SelectedEntity?.id;
            if (id.HasValue)
            {
                DeleteEntityViewModel = cRUDViewModel;
            }
        }
        protected void DeleteHandler(object sender, CRUDOperationResultEventArgs result)
        {
            var cVMcur = DeleteEntityViewModel;

            if (sender is ICRUDViewModel cVM)
            {
                if (cVM != cVMcur)
                    Console.WriteLine("problemsDelete");
                cVM.CRUDcompleteNotify -= DeleteHandler;
            }

            DeleteEntityViewModel = null;


            if (result.CRUDResult.HasValue)
            {
                if (result.CRUDResult.Value)
                {
                    int? id = result.ResultEntity?.id;
                    if (id.HasValue)
                    {
                        TEntity entity = Entities.FirstOrDefault(p => p.id == id);
                        if (entity != null)
                        {
                            if (SelectedEntity == entity)
                                SelectedEntity = null;
                            Entities.Remove(entity);
                        }
                    }
                }
                else
                {
                    string error = result.ErrorMessage;
                    if (!String.IsNullOrEmpty(error))
                        Console.WriteLine(error);           //Переделать
                }
            }
        }




        public override void Dispose()
        {
            CreateEntityViewModel = null;
            UpdateEntityViewModel = null;
            DeleteEntityViewModel = null;
            base.Dispose();
        }


        public override bool IsValid => true;
        public override string this[string columnName] => String.Empty;
        public override string Error => String.Empty;

    }
}












//public ObservableCollection<TEntity> Entities { get => _entities; private set => OnPropertyChanged(ref _entities, value); }