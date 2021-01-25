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
        public event CRUDOperationResultEventHandler CRUDcompleteNotify;

        protected IDataService<TEntity> _dataService;
        protected readonly TEntity _entity;

        public CreateEntityViewModel(IDataService<TEntity> service, TEntity entity) : base()
        {
            _dataService = service;
            _entity = entity;
        }


        public ICommand BackToListEntitiesCommand => new ActionCommand(p => BackToListEntities());

        public ICommand CreateEntityCommand => new ActionCommand(p => CreateEntity(), p => IsValid);



        protected void BackToListEntities()
        {
            CRUDcompleteNotify?.Invoke(this, new CRUDOperationResultEventArgs(null, null, null));
        }

        protected void CreateEntity()
        {
            TEntity entity = _entity;

            bool isCreated = true;
            TEntity createdEntity;
            string errorMessage = String.Empty;

            try
            {
                createdEntity = _dataService.Create(entity);
            }
            catch (Exception ex)
            {
                isCreated = false;
                createdEntity = null;
                errorMessage = ex.Message + "\nВнутренне исключение: " + ex?.InnerException?.InnerException?.Message ?? String.Empty;
            }

            CRUDcompleteNotify?.Invoke(this, new CRUDOperationResultEventArgs(isCreated, createdEntity, errorMessage));
        }



        //public CRUDoperationTypes CRUDType { get; } = CRUDoperationTypes.Create;
        //public override bool IsValid => true;
        //public override string this[string columnName] => String.Empty;
        //public override string Error => String.Empty;
    }
}