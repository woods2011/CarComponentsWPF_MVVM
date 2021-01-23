using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarComponentsWPF.Models
{
    public interface IEntity
    {
        int id { get; set; }
    }

    public partial class Manufacter : IEntity { }
    public partial class ComponentType: IEntity { }
    public partial class CarModel : IEntity { }
    public partial class Component : IEntity { }
    public partial class Provider : IEntity { }
    public partial class ProviderComponent : IEntity { }

}
