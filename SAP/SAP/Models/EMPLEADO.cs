namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPLEADO")]
    public partial class EMPLEADO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_EMPLEADO { get; set; }

        public int ID_DIRECCION { get; set; }

        public int? EMP_ID_EMPLEADO { get; set; }

        public int ID_IDENTIFICACION { get; set; }

        public int ID_GENERO { get; set; }

        public int? ID_PROFESION { get; set; }

        public int ID_ESTADO_CIVIL { get; set; }

        public int ID_PUESTO { get; set; }

        [Required]
        [StringLength(25)]
        public string CODIGO_EMPLEADO { get; set; }

        [StringLength(60)]
        public string APELLIDO_MATERNO { get; set; }

        [Required]
        [StringLength(60)]
        public string APELLIDO_PATERNO { get; set; }

        [Required]
        [StringLength(60)]
        public string PRIMER_NOMBRE { get; set; }

        [StringLength(60)]
        public string SEGUNDO_NOMBRE { get; set; }

        public DateTime FECHA_NACIMIENTO { get; set; }

        [Required]
        [StringLength(20)]
        public string DUI { get; set; }

        [StringLength(20)]
        public string PASAPORTE { get; set; }

        [Required]
        [StringLength(20)]
        public string NIT { get; set; }

        [Required]
        [StringLength(20)]
        public string ISSS { get; set; }

        [Required]
        [StringLength(20)]
        public string NUP { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SALARIO_BASE { get; set; }

        [Required]
        [StringLength(60)]
        public string CORREO_PERSONAL { get; set; }

        [Required]
        [StringLength(60)]
        public string CORREO_INSTITUCIONAL { get; set; }
    }
}
