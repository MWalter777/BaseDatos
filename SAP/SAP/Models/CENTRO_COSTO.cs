namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CENTRO_COSTO
    {
        [Key]
        public int ID_CENTRO_COSTO { get; set; }

        public int ID_DEPARTAMENTO { get; set; }

        public int ANIO { get; set; }

        public decimal MONTO_ASIGNADO { get; set; }

        public decimal SALDO { get; set; }
    }
}
