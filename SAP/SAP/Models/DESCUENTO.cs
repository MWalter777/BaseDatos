namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DESCUENTO")]
    public partial class DESCUENTO
    {
        [Key]
        public int ID_DESC_HISOTIRAL { get; set; }

        public int? ID_HISTORIAL { get; set; }
        [ForeignKey("ID_HISTORIAL")]
        public virtual HISTORIAL HISTORIAL { get; set; }

        [Required]
        [StringLength(100)]
        public string NOMBRE_DESCUENTO_HISTORIAL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal DESCUENTO_HISTORIAL { get; set; }
    }
}
