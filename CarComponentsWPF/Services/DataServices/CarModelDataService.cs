using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarComponentsWPF.Models;

namespace CarComponentsWPF.Services.DataServices
{
    public class CarModelDataService : GenericDataService<CarModel>
    {
        public override IEnumerable<CarModel> GetWithFilter(Dictionary<string, string> filterDictionary)
        {
            throw new NotImplementedException();
        }
    }
}
