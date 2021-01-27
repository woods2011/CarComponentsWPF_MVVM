using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarComponentsWPF.Models;

namespace CarComponentsWPF.Services.DataServices
{
    public class ProviderComponentDataService : GenericDataService<ProviderComponent>
    {
        public override IEnumerable<ProviderComponent> GetWithFilter(Dictionary<string, int> filterDictionary)
        {
            throw new NotImplementedException();
        }
    }
}
