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
    
    public partial class Component
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Component()
        {
            this.ProviderComponents = new HashSet<ProviderComponent>();
        }
    
        public int id { get; set; }
        public int id_Manuf { get; set; }
        public int id_CompType { get; set; }
        public int id_CarModel { get; set; }
        public int PrimeCost { get; set; }
    
        public virtual CarModel CarModel { get; set; }
        public virtual ComponentType ComponentType { get; set; }
        public virtual Manufacter Manufacter { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProviderComponent> ProviderComponents { get; set; }
    }
}
