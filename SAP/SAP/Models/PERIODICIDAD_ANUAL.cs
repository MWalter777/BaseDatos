namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PERIODICIDAD_ANUAL
    {
        [Key]
        public int ID_PERIODICIDAD { get; set; }

        public int ANIO_PERIODICIDAD { get; set; }

        public bool QUINCENAL { get; set; }

        public bool MENSUAL { get; set; }
    }
}
