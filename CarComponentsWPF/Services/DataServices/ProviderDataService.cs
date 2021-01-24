using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarComponentsWPF.Models;

namespace CarComponentsWPF.Services.DataServices
{
    public class ProviderDataService : GenericDataService<Provider>
    {
        public override IEnumerable<Provider> GetWithFilter(Dictionary<string, string> filterDictionary)
        {
            throw new NotImplementedException();
        }
    }
}
