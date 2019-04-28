namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DIRECCION")]
    public partial class DIRECCION
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_DIRECCION { get; set; }

        public int ID_SUB_REGION { get; set; }

        [Required]
        [StringLength(150)]
        public string DETALLE_DIRECCION { get; set; }
    }
}
