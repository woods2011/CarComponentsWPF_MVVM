﻿using CarComponentsWPF.Models;
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
    public class DeleteManufacterViewModel : DeleteEntityViewModel<Manufacter>
    {
        public DeleteManufacterViewModel(IDataService<Manufacter> service, Manufacter entity) : base(service, entity)
        {
        }
 
        
        public string Name { get => _entity.Name; set { _entity.Name = value; OnPropertyChanged(Name); } }

        public string Country { get => _entity.Contry; set { _entity.Contry = value; OnPropertyChanged(Country); } }

    }
}