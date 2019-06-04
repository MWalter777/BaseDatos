namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PLANILLA")]
    public partial class PLANILLA
    {
        [Key]
        public int ID_PLANILLA { get; set; }

        public DateTime FECHA { get; set; }

        [Required]
        [StringLength(15)]
        public string CODIGO_PLANILLA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TOTAL_INGRESOS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TOTAL_DESCUENTOS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TOTAL_PAGAR { get; set; }
    }
}
