namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DETALLEPLANILLA")]
    public partial class DETALLEPLANILLA
    {
        [Key]
        public int ID_DETALLE_PLANILLA { get; set; }

        public int? ID_INGRESO_EMPLEADO { get; set; }

        [ForeignKey("ID_INGRESO_EMPLEADO")]
        public virtual INGRESO_EMPLEADO ingreso_empleado { get; set; }

        public int ID_PLANILLA { get; set; }

        public int? ID_DESCUENTO_EMPLEADO { get; set; }

        [ForeignKey("ID_DESCUENTO_EMPLEADO")]
        public virtual DESCUENTO_EMPLEADO descuento_empleado { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SALARIO { get; set; }
    }
}
