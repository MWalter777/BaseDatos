namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DESCUENTO_EMPLEADO
    {
        public bool HABILITAR_DESCUENTO { get; set; }

        [Key]
        public int ID_DESCUENTO_EMPLEADO { get; set; }

        public int ID_EMPLEADO { get; set; }
        [ForeignKey("ID_EMPLEADO")]
        public virtual EMPLEADO empleado { get; set; }

        public int ID_DESCUENTO { get; set; }
        [ForeignKey("ID_DESCUENTO")]
        public virtual CATALOGO_DESCUENTO descuento { get; set; }
    }
}
