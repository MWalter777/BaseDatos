namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DESCUENTO_RENTA
    {
        [Key]
        public int ID_DESCUENTO_RENTA { get; set; }

        [Display(Name = "Salario mínimo a aplicar")]
        public decimal MIN_RENTA { get; set; }

        [Display(Name = "Salario máximo a aplicar")]
        public decimal MAX_RENTA { get; set; }

        [Display(Name = "Porcentaje de renta")]
        public decimal PORCENTAJE_RENTA { get; set; }
    }
}
