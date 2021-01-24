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
    public abstract class UpdateEntityViewModel<TEntity> : BaseViewModel, ICRUDViewModel where TEntity : class, IEntity
    {
        public event CRUDOperationResultEventHandler CRUDcompleteNotify;

        protected IDataService<TEntity> _dataService;
        protected readonly TEntity _entity;

        public UpdateEntityViewModel(IDataService<TEntity> service, TEntity entity) : base()
        {
            _dataService = service;
            _entity = entity;
        }


        public ICommand BackToListEntitiesCommand => new ActionCommand(p => BackToListEntities());

        public ICommand CreateEntityCommand => new ActionCommand(p => UpdateEntity(), p => IsValid);



        protected void BackToListEntities()
        {
            CRUDcompleteNotify?.Invoke(this, new CRUDOperationResultEventArgs(null, null, null));
        }

        protected void UpdateEntity()
        {
            TEntity entity = _entity;

            bool isUpdated = true;
            TEntity updatedEntity;
            string errorMessage = String.Empty;

            try
            {
                updatedEntity = _dataService.Update(entity);
            }
            catch (Exception ex)
            {
                isUpdated = false;
                updatedEntity = null;
                errorMessage = ex.Message;
            }

            CRUDcompleteNotify?.Invoke(this, new CRUDOperationResultEventArgs(isUpdated, updatedEntity, errorMessage));
        }



        //public CRUDoperationTypes CRUDType { get; } = CRUDoperationTypes.Create;
        //public override bool IsValid => true;
        //public override string this[string columnName] => String.Empty;
        //public override string Error => String.Empty;
    }
}