namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROFESION")]
    public partial class PROFESION
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_PROFESION { get; set; }

        [Required]
        [StringLength(60)]
        public string NOMBRE_PROFESION { get; set; }
    }
}
