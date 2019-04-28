namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GENERO")]
    public partial class GENERO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_GENERO { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE_GENERO { get; set; }
    }
}
