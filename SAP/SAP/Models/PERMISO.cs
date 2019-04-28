namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PERMISO")]
    public partial class PERMISO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_PERMISO { get; set; }

        [Required]
        [StringLength(60)]
        public string NOMBRE_PERMISO { get; set; }

        [Required]
        [StringLength(150)]
        public string DESCRIPCION_PERMISO { get; set; }
    }
}
