//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inventario.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public producto()
        {
            this.detalle_factura = new HashSet<detalle_factura>();
        }
    
        public int codigo { get; set; }
        public string nombre_producto { get; set; }
        public Nullable<int> tipo_producto { get; set; }
        public string descripcion { get; set; }
        public Nullable<decimal> precio { get; set; }
        public Nullable<int> cantidad_min { get; set; }
        public Nullable<int> cantidad_max { get; set; }
        public Nullable<int> proveedor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalle_factura> detalle_factura { get; set; }
        public virtual proveedor proveedor1 { get; set; }
        public virtual tipo_producto tipo_producto1 { get; set; }
    }
}
