using CarComponentsWPF.Models;
using CarComponentsWPF.Services.DataServices;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.ComponentModel;

namespace CarComponentsWPF.ViewModels
{
    public class ManufacterViewModel : EntityViewModel<Manufacter>
    {
        public ManufacterViewModel() : base(new ManufacterDataService(), new ObservableCollection<Manufacter>())
        {
            var a = new SortDescription(nameof(Manufacter.Contry), ListSortDirection.Ascending);

            _entitiesCollectionView.GroupDescriptions.Add(new PropertyGroupDescription(nameof(Manufacter.Contry)));
            _entitiesCollectionView.SortDescriptions.Add(a);
            _entitiesCollectionView.SortDescriptions.Add(new SortDescription(nameof(Manufacter.Name), ListSortDirection.Descending));

            _entitiesCollectionView.SortDescriptions.Remove(a);
            //_entitiesCollectionView.SortDescriptions.Add(a);
        }




        protected override bool SearchEntities(object obj)
        {
            if (obj is Manufacter manufacter)
            {
                var searchQueLow = EntitiesSearchQuery.ToLower();

                return manufacter.Name.ToLower().Contains(searchQueLow) ||
                    manufacter.Contry.ToLower().Contains(searchQueLow);
            }            

            return false;
        }

        protected override void GetWithFilterEntities()
        {
            Console.WriteLine("GetWithFIlter");
            //throw new NotImplementedException();
        }

        protected override void CreateEntity()
        {
            CreateEntity(new CreateManufacterViewModel(_dataService, new Manufacter()));
        }

        protected override void UpdateEntity()
        {
            throw new NotImplementedException();
        }

        protected override void DeleteEntity()
        {
            throw new NotImplementedException();
        }
    }
}
