//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarComponentsWPF.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProviderComponent
    {
        public int id { get; set; }
        public int id_CarComp { get; set; }
        public int id_Provider { get; set; }
        public int RetailPrice { get; set; }
        public int Quantity { get; set; }
    
        public virtual Component Component { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
