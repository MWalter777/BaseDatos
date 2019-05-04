namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPRESA")]
    public partial class EMPRESA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPRESA()
        {
            DEPARTAMENTO = new HashSet<DEPARTAMENTO>();
        }

        [Key]
        public int ID_EMPRESA { get; set; }

        [Required]
        [StringLength(100)]
        public string NOMBRE_EMPRESA { get; set; }

        [Required]
        [StringLength(250)]
        public string DIRECCION { get; set; }

        [Required]
        [StringLength(60)]
        public string REPRESENTANTE { get; set; }

        [Required]
        [StringLength(17)]
        public string NIT_EMPRESA { get; set; }

        [Required]
        [StringLength(15)]
        public string NIC { get; set; }

        [Required]
        [StringLength(9)]
        public string TELEFONO_EMPRESA { get; set; }

        [StringLength(100)]
        public string PAGINA_WEB { get; set; }

        [Required]
        [StringLength(60)]
        public string CORREO_EMPRESA { get; set; }

        [StringLength(60)]
        public string PAGE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPARTAMENTO> DEPARTAMENTO { get; set; }
    }
}
