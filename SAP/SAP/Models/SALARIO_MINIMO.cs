namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SALARIO_MINIMO
    {
        [Key]
        public int ID_SALARIO_MINIMO { get; set; }

        public decimal MONTO_SALARIO_MINIMO { get; set; }
    }
}
