namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("REGION")]
    public partial class REGION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public REGION()
        {
            SUB_REGION = new HashSet<SUB_REGION>();
        }

        [Key]
        public int ID_REGION { get; set; }

        public int ID_PAIS { get; set; }

        [Required]
        [StringLength(60)]
        public string CODIGO_REGION { get; set; }

        [Required]
        [StringLength(60)]
        public string NOMBRE_REGION { get; set; }

        public virtual PAIS PAIS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUB_REGION> SUB_REGION { get; set; }
    }
}
