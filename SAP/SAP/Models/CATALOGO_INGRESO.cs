namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CATALOGO_INGRESO
    {
        [Key]
        public int ID_INGRESO { get; set; }

        [Required]
        [StringLength(75)]
        public string NOMBRE_INGRESO { get; set; }

        public bool DELEY_INGRESO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? INGRESO { get; set; }

        public bool ACTIVO { get; set; }
    }
}
