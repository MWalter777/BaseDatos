namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ESTADO_CIVIL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_ESTADO_CIVIL { get; set; }

        [Required]
        [StringLength(25)]
        public string NOMBRE_ESTADO_CIVIL { get; set; }
    }
}
