//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Veipshop.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tobacco_heating_systems
    {
        public int ths_id { get; set; }
        public Nullable<int> product_id { get; set; }
        public string battery_capacity { get; set; }
    
        public virtual Products Products { get; set; }
    }
}