using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarComponentsWPF.Models;

namespace CarComponentsWPF.Services.DataServices
{
    public class ManufacterDataService : GenericDataService<Manufacter>
    {
        public override IEnumerable<Manufacter> GetWithFilter(Dictionary<string, string> filterDictionary)
        {
            throw new NotImplementedException();
        }

        //public List<dynamic> Test(Dictionary<string, string> filterDictionary)
        //{
        //    using (CarCompDB8Entities context = new CarCompDB8Entities())
        //    {
        //        var a = from c in context.Components
        //                join cm in context.CarModels on c.id_CarModel equals cm.id
        //                select new { CompId = c.id, CarModelId = cm.id };

        //        var b = a;

        //        var b = a.ToList();
        //        //var b = a.ToList().FirstOrDefault();

        //        return b;

        //        //var a =context.Manufacters.Join();
        //    }

        //    throw new NotImplementedException();
        //}
    }
}
