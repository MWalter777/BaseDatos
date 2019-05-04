namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PAIS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PAIS()
        {
            REGION = new HashSet<REGION>();
        }

        [Key]
        public int ID_PAIS { get; set; }

        [Required]
        [StringLength(2)]
        public string CODIGO_PAIS { get; set; }

        [Required]
        [StringLength(60)]
        public string NOMBRE_PAIS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGION> REGION { get; set; }
    }
}
