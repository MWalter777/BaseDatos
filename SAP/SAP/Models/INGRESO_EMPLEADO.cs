namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INGRESO_EMPLEADO
    {
        public bool HABILITAR_INGRESO { get; set; }

        [Key]
        public int ID_INGRESO_EMPLEADO { get; set; }

        public int ID_INGRESO { get; set; }

        public int ID_EMPLEADO { get; set; }
    }
}
