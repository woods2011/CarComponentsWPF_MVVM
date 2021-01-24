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
    public abstract class CreateEntityViewModel<TEntity> : BaseViewModel, ICRUDViewModel where TEntity : class, IEntity
    {
        public CRUDoperationTypes CRUDType { get; } = CRUDoperationTypes.Create;

        public event CRUDOperationResultEventHandler CRUDcompleteNotify;

        protected IDataService<TEntity> _dataService;

        public CreateEntityViewModel(IDataService<TEntity> service) : base()
        {
            _dataService = service;
        }




        public ICommand BackToListEntitiesCommand => new ActionCommand(p => BackToListEntities());

        public ICommand CreateEntityCommand => new ActionCommand(p => CreateEntity(), p => IsValid);



        protected void BackToListEntities()
        {
            CRUDcompleteNotify?.Invoke(this, new CRUDOperationResultEventArgs(null, null, null));
        }

        protected abstract bool TryCreateEntity(out TEntity createdEntity, out string errorMessage);

        protected void CreateEntity()
        {
            TEntity createdEntity;
            string errorMessage;

            bool isCreated = TryCreateEntity(out createdEntity, out errorMessage);
            CRUDcompleteNotify?.Invoke(this, new CRUDOperationResultEventArgs(isCreated, CRUDType, createdEntity, errorMessage));
        }
        
        //public override bool IsValid => true;
        //public override string this[string columnName] => String.Empty;
        //public override string Error => String.Empty;
    }
}