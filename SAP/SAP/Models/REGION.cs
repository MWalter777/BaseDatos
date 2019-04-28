namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("REGION")]
    public partial class REGION
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_REGION { get; set; }

        public int ID_PAIS { get; set; }

        [Required]
        [StringLength(60)]
        public string CODIGO_REGION { get; set; }

        [Required]
        [StringLength(60)]
        public string NOMBRE_REGION { get; set; }
    }
}
