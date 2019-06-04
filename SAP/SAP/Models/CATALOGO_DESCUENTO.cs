namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CATALOGO_DESCUENTO
    {
        [Key]
        public int ID_DESCUENTO { get; set; }

        [Required]
        [StringLength(75)]
        public string NOMBRE_DESCUENTO { get; set; }

        public bool DELEY_DESCUENTO { get; set; }
    }
}
