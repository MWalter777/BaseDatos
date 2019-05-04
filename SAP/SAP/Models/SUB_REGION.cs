namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SUB_REGION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUB_REGION()
        {
            DIRECCION = new HashSet<DIRECCION>();
        }

        [Key]
        public int ID_SUB_REGION { get; set; }

        public int ID_REGION { get; set; }

        [Required]
        [StringLength(60)]
        public string CODIGO_SUB_REGION { get; set; }

        [Required]
        [StringLength(60)]
        public string NOMBRE_SUB_REGION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIRECCION> DIRECCION { get; set; }

        public virtual REGION REGION { get; set; }
    }
}
