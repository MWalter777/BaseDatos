namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INGRESO")]
    public partial class INGRESO
    {
        [Key]
        public int ID_ING_HISTORIAL { get; set; }

        public int? ID_HISTORIAL { get; set; }
        [ForeignKey("ID_HISTORIAL")]
        public virtual HISTORIAL HISTORIAL { get; set; }

        [StringLength(100)]
        public string NOMBRE_INGRESO_HISTORIAL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? INGRESO_HISTORIAL { get; set; }
    }
}
