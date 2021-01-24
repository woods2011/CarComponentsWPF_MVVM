using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarComponentsWPF.Models;

namespace CarComponentsWPF.Services.DataServices
{
    public class ComponentDataService : GenericDataService<Component>
    {
        public override IEnumerable<Component> GetWithFilter(Dictionary<string, string> filterDictionary)
        {
            throw new NotImplementedException();
        }
    }
}
