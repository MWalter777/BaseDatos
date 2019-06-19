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
        [Display(Name = "Nombre")]
        public string NOMBRE_DESCUENTO { get; set; }

        [Display(Name = "¿Descuento de Ley?")]
        public bool DELEY_DESCUENTO { get; set; }

        [Column(TypeName = "numeric")]
        [Display(Name = "Porcentaje")]
        public decimal? PORCENTAJE { get; set; }

        [Column(TypeName = "numeric")]
        [Display(Name = "Cantidad")]
        public decimal? DESCUENTO { get; set; }

        [Display(Name = "Fecha de inicio")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FECHA_INICIO { get; set; }

        [Display(Name = "Fecha de finalización")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FECHA_FIN { get; set; }

        [Display(Name ="Activo")]
        public bool ACTIVO { get; set; }
    }
}
