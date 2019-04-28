namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SUB_REGION
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_SUB_REGION { get; set; }

        public int ID_REGION { get; set; }

        [Required]
        [StringLength(60)]
        public string CODIGO_SUB_REGION { get; set; }

        [Required]
        [StringLength(60)]
        public string NOMBRE_SUB_REGION { get; set; }
    }
}
