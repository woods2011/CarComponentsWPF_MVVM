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
    public class DeleteProviderViewModel : DeleteEntityViewModel<Provider>
    {
        public DeleteProviderViewModel(IDataService<Provider> service, Provider entity) : base(service, entity)
        {
        }
 
        
        public string Name { get => _entity.Name; set { _entity.Name = value; OnPropertyChanged(Name); } }
        public string PhoneNum { get => _entity.PhoneNum; set { _entity.PhoneNum = value; OnPropertyChanged(PhoneNum); } }
        public string Address { get => _entity.Address; set { _entity.Address = value; OnPropertyChanged(Address); } }

    }
}