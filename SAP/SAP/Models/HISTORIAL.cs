namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HISTORIAL")]
    public partial class HISTORIAL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HISTORIAL()
        {
            ingreso = new HashSet<INGRESO>();
            descuento = new HashSet<DESCUENTO>();
        }

        [Key]
        public int ID_HISTORIAL { get; set; }

        public int? ID_PLANILLA { get; set; }

        [Required]
        [StringLength(100)]
        public string NOMBRE_EMPLEADO_HISTORIAL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TOTAL { get; set; }

        [StringLength(25)]
        public string CODIGO_EMPLEADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INGRESO> ingreso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DESCUENTO> descuento { get; set; }
    }
}
