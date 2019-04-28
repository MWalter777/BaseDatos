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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_PUESTO { get; set; }

        public int ID_EMPRESA { get; set; }

        public int? PUE_ID_PUESTO { get; set; }

        [Required]
        [StringLength(10)]
        public string CODIGO_PUESTO { get; set; }

        [Required]
        [StringLength(60)]
        public string NOMBRE_PUESTO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SALARIO_MINIMO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SALARIO_MAXIMO { get; set; }
    }
}
