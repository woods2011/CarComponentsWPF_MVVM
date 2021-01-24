﻿using System;
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
    }
}
