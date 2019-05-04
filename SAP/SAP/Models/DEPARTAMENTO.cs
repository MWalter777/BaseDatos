namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DEPARTAMENTO")]
    public partial class DEPARTAMENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEPARTAMENTO()
        {
            DEPARTAMENTO1 = new HashSet<DEPARTAMENTO>();
            PUESTO = new HashSet<PUESTO>();
        }

        [Key]
        public int ID_DEPARTAMENTO { get; set; }

        public int ID_EMPRESA { get; set; }

        public int? DEP_ID_DEPARTAMENTO { get; set; }

        [Required]
        [StringLength(60)]
        public string NOMBRE_DEPARTAMENTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPARTAMENTO> DEPARTAMENTO1 { get; set; }

        public virtual DEPARTAMENTO DEPARTAMENTO2 { get; set; }

        public virtual EMPRESA EMPRESA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PUESTO> PUESTO { get; set; }
    }
}
