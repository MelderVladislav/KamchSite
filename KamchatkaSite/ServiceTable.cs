//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KamchatkaSite
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServiceTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceTable()
        {
            this.ServiceImagesTable = new HashSet<ServiceImagesTable>();
        }
    
        public long ServiceID { get; set; }
        public long CategoryID { get; set; }
        public string ServiceNameRus { get; set; }
        public string ServiceNameCh { get; set; }
        public string ServiceDescriptionRus { get; set; }
        public string ServiceDescriptionCh { get; set; }
        public string ServiceMainPicture { get; set; }
        public decimal ServicePrice { get; set; }
    
        public virtual CategoryTable CategoryTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceImagesTable> ServiceImagesTable { get; set; }
    }
}
