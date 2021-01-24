using CarComponentsWPF.Models;
using CarComponentsWPF.Services.DataServices;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarComponentsWPF.ViewModels
{
    public class ManufacterViewModel : EntityViewModel<Manufacter>
    {
        public ManufacterViewModel() : base(new ManufacterDataService(), new ObservableCollection<Manufacter>())
        {

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
            throw new NotImplementedException();
        }
    }
}
