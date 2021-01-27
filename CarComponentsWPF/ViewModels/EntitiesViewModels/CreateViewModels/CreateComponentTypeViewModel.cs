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
using System.ComponentModel.DataAnnotations;

namespace CarComponentsWPF.ViewModels
{
    public class CreateComponentTypeViewModel : CreateEntityViewModel<ComponentType>
    {
        public CreateComponentTypeViewModel(IDataService<ComponentType> service, ComponentType entity) : base(service, entity)
        {
        }


        [Required(ErrorMessage = "Название типа комплектующей не должно быть пустым")]
        public string Name { get => _entity.Name; set { _entity.Name = value; OnPropertyChanged(Name); } }

    }
}

