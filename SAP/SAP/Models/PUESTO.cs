namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PUESTO")]
    public partial class PUESTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PUESTO()
        {
            EMPLEADO = new HashSet<EMPLEADO>();
        }

        [Key]
        public int ID_PUESTO { get; set; }

        public int ID_DEPARTAMENTO { get; set; }


        [Required]
        [StringLength(10)]
        public string CODIGO_PUESTO { get; set; }

        [Required]
        [StringLength(60)]
        public string NOMBRE_PUESTO { get; set; }

        public decimal SALARIO_MINIMO { get; set; }

        public decimal SALARIO_MAXIMO { get; set; }

        public virtual DEPARTAMENTO DEPARTAMENTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLEADO> EMPLEADO { get; set; }
    }
}
