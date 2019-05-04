namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DIRECCION")]
    public partial class DIRECCION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DIRECCION()
        {
            EMPLEADO = new HashSet<EMPLEADO>();
        }

        [Key]
        public int ID_DIRECCION { get; set; }

        public int ID_SUB_REGION { get; set; }

        [StringLength(60)]
        public string BARRIO { get; set; }

        [StringLength(60)]
        public string COLONIA { get; set; }

        [StringLength(60)]
        public string CANTON { get; set; }

        [StringLength(60)]
        public string CASERIO { get; set; }

        [StringLength(60)]
        public string CALLE { get; set; }

        [StringLength(60)]
        public string AVENIDA { get; set; }

        [StringLength(60)]
        public string PASAJE { get; set; }

        [StringLength(60)]
        public string RESIDENCIAL { get; set; }

        [StringLength(60)]
        public string NUMERO_CASA { get; set; }

        public virtual SUB_REGION SUB_REGION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLEADO> EMPLEADO { get; set; }
    }
}
