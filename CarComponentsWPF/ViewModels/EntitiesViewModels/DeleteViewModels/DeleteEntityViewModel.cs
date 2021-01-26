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
    public abstract class DeleteEntityViewModel<TEntity> : BaseViewModel, ICRUDViewModel where TEntity : class, IEntity
    {
        public event CRUDOperationResultEventHandler CRUDcompleteNotify;

        protected readonly IDataService<TEntity> _dataService;
        protected readonly TEntity _entity;
        protected readonly MessageViewModel _messageViewModel;

        public DeleteEntityViewModel(IDataService<TEntity> service, TEntity entity) : base()
        {
            _dataService = service;
            _entity = entity;

            _messageViewModel = new MessageViewModel();
        }


        public ICommand BackToListEntitiesCommand => new ActionCommand(p => BackToListEntities());

        public ICommand DeleteEntityCommand => new ActionCommand(p => DeleteEntity());

        public MessageViewModel MessageViewModel { get => _messageViewModel; }

        protected void BackToListEntities()
        {
            CRUDcompleteNotify?.Invoke(this, new CRUDOperationResultEventArgs(null, null, null));
        }

        protected void DeleteEntity()
        {
            int id = _entity.id;

            bool isDeleted;
            TEntity deletedEntity = _entity;
            string errorMessage = String.Empty;

            try
            {
                isDeleted = _dataService.Delete(id);
                if (!isDeleted)
                {
                    errorMessage = "Не удалось удалить экземпляр сущности";
                    MessageViewModel.Message = errorMessage;
                }
                else {
                    CRUDcompleteNotify?.Invoke(this, new CRUDOperationResultEventArgs(isDeleted, deletedEntity, errorMessage));
                }

            }
            catch (Exception ex)
            {
                isDeleted = false;
                errorMessage = "Не удалось удалить экземпляр сущности\n" + ex.Message + "\nВнутренне исключение: " + ex?.InnerException?.InnerException?.Message ?? String.Empty;

                MessageViewModel.Message = errorMessage;
            }
        }




    }
}