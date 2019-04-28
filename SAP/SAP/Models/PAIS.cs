namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PAIS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_PAIS { get; set; }

        [Required]
        [StringLength(60)]
        public string CODIGO_PAIS { get; set; }

        [Required]
        [StringLength(60)]
        public string NOMBRE_PAIS { get; set; }
    }
}
