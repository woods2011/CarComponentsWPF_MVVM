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
    public interface ICRUDViewModel : IDisposable
    {
        //CRUDoperationTypes CRUDType { get; }

        event CRUDOperationResultEventHandler CRUDcompleteNotify;
    }

    //public enum CRUDoperationTypes
    //{
    //    Create,
    //    Update,
    //    Delete
    //}

    public class CRUDOperationResultEventArgs : EventArgs
    {
        public CRUDOperationResultEventArgs(bool? cRUDResult, IEntity resultEntity, string errorMessage)
        {
            CRUDResult = cRUDResult;
            ResultEntity = resultEntity;
            ErrorMessage = errorMessage;
        }

        public bool? CRUDResult { get; }
        public string ErrorMessage { get; }
        public IEntity ResultEntity { get; }
    }

    public delegate void CRUDOperationResultEventHandler(object sender, CRUDOperationResultEventArgs e);
}


