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
        protected readonly MessageViewModel _messageViewModel;

        public UpdateEntityViewModel(IDataService<TEntity> service, TEntity entity) : base()
        {
            _messageViewModel = new MessageViewModel();
            _dataService = service;

            if (entity == null)
                BackToListEntities();
            _entity = _dataService.Get(entity.id);
            if (entity == null)
                BackToListEntities();
        }


        public ICommand BackToListEntitiesCommand => new ActionCommand(p => BackToListEntities());

        public ICommand UpdateEntityCommand => new ActionCommand(p => UpdateEntity(), p => IsValid);

        public MessageViewModel MessageViewModel { get => _messageViewModel; }

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
                CRUDcompleteNotify?.Invoke(this, new CRUDOperationResultEventArgs(isUpdated, updatedEntity, errorMessage));
            }
            catch (Exception ex)
            {
                isUpdated = false;
                updatedEntity = null;
                errorMessage = ex.Message + "\nВнутренне исключение: " + ex?.InnerException?.InnerException?.Message ?? String.Empty;

                MessageViewModel.Message = errorMessage;
            }
        }

    }
}