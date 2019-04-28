namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IDENTIFICACION")]
    public partial class IDENTIFICACION
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_IDENTIFICACION { get; set; }

        [Required]
        [StringLength(60)]
        public string NOMBRE_IDENTIFICACION { get; set; }
    }
}
