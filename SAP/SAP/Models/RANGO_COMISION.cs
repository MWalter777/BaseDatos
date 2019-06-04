namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RANGO_COMISION
    {
        [Key]
        public int ID_RANGO { get; set; }

        public decimal MIN_COMISION { get; set; }

        public decimal MAX_COMISION { get; set; }

        public decimal PORCENTAJE_POR_COMISION { get; set; }
    }
}
