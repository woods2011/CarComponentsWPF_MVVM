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
        private TEntity _selectedEntity;
        protected IDataService<TEntity> _dataService;
        protected readonly ICollectionView _entitiesCollectionView;
        private string _entitiesSearchQuery = string.Empty;

        private ICRUDViewModel _createEntityViewModel = null;
        private ICRUDViewModel _updateEntityViewModel = null;
        private ICRUDViewModel _removeEntityViewModel = null;

        public EntityViewModel(IDataService<TEntity> service, ObservableCollection<TEntity> entities) : base()
        {
            Entities = entities;
            _entitiesCollectionView = CollectionViewSource.GetDefaultView(Entities);
            _entitiesCollectionView.Filter = SearchEntities;
            _dataService = service;
        }

        protected abstract bool SearchEntities(object obj);

        public ObservableCollection<TEntity> Entities { get; private set; }    //Заменить на ICollection

        public TEntity SelectedEntity { get => _selectedEntity; set { OnPropertyChanged(ref _selectedEntity, value); OnPropertyChanged(nameof(CanModify)); } } //Console.WriteLine(value?.id.ToString() ?? "null");

        public string EntitiesSearchQuery { get => _entitiesSearchQuery; set { OnPropertyChanged(ref _entitiesSearchQuery, value); _entitiesCollectionView.Refresh(); } }

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
        
        protected void GetWithFilterEntities(Dictionary<string, string> filterDictionary)
        {
            Entities.Clear();
            SelectedEntity = null;

            foreach (var entity in _dataService.GetWithFilter(filterDictionary))
                Entities.Add(entity);
        }

        protected void GetAllEntities()
        {
            Console.WriteLine("GetAllEntities");
            Entities.Clear();
            SelectedEntity = null;

            foreach (var entity in _dataService.GetAll())
            {
                Entities.Add(entity);
                Console.WriteLine("anotherone");
            }
        }

        protected abstract void CreateEntity();
        private void CreateEntity(ICRUDViewModel cRUDViewModel)
        {
            _createEntityViewModel = cRUDViewModel;
            _createEntityViewModel.CRUDcompleteNotify += CreateHandler;
        }

        private void CreateHandler(object sender, CRUDOperationResultEventArgs e)
        {
            _createEntityViewModel = null;
        }

        protected void UpdateEntity()
        {
            int? id = SelectedEntity?.id;
            if (id.HasValue)
            {

            }
        }

        protected void DeleteEntity()
        {
            int? id = SelectedEntity?.id;
            if (id.HasValue)
            {

            }
        }





        public override bool IsValid => true;
        public override string this[string columnName] => String.Empty;
        public override string Error => String.Empty;
    }
}












//public ObservableCollection<TEntity> Entities { get => _entities; private set => OnPropertyChanged(ref _entities, value); }