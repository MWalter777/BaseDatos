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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLEADO()
        {
            descuento_empleados = new HashSet<DESCUENTO_EMPLEADO>();
            ingreso_empleados = new HashSet<INGRESO_EMPLEADO>();
        }


        [Key]
        public int ID_EMPLEADO { get; set; }

        public int ID_DIRECCION { get; set; }

        [ForeignKey("ID_DIRECCION")]
        public virtual DIRECCION direccion { get; set; }

        public int? EMP_ID_EMPLEADO { get; set; }

        [ForeignKey("EMP_ID_EMPLEADO")]
        public virtual EMPLEADO jefe { get; set; }

        public int ID_GENERO { get; set; }

        [ForeignKey("ID_GENERO")]
        public virtual GENERO genero { get; set; }

        public int? ID_PROFESION { get; set; }

        [ForeignKey("ID_PROFESION")]
        public virtual PROFESION profesion { get; set; }

        public int ID_ESTADO_CIVIL { get; set; }

        [ForeignKey("ID_ESTADO_CIVIL")]
        public virtual ESTADO_CIVIL estado_civil { get; set; }

        public int ID_PUESTO { get; set; }

        [ForeignKey("ID_PUESTO")]
        public virtual PUESTO puesto { get; set; }

        [Required]
        [StringLength(25)]
        public string CODIGO_EMPLEADO { get; set; }

        [StringLength(60)]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z������������]*$", ErrorMessage = "Solo se admiten letras")]
        public string APELLIDO_MATERNO { get; set; }

        [Required]
        [StringLength(60)]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z������������]*$", ErrorMessage = "Solo se admiten letras")]
        public string APELLIDO_PATERNO { get; set; }

        [Required]
        [StringLength(60)]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z������������]*$", ErrorMessage = "Solo se admiten letras")]
        public string PRIMER_NOMBRE { get; set; }

        [StringLength(60)]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z������������]*$", ErrorMessage = "Solo se admiten letras")]
        public string SEGUNDO_NOMBRE { get; set; }

        [Range(typeof(DateTime), "1/1/1950", "26/6/2001", ErrorMessage = "Debe de ser mayor de 18 a�os y menor a 69 a�os")]
        public DateTime FECHA_NACIMIENTO { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression(@"^[0-9]{8}-[0-9]$", ErrorMessage = "El formato de DUI es incorrecto. Formato correcto: 99999999-9")]
        public string DUI { get; set; }

        [StringLength(20)]
        public string PASAPORTE { get; set; }

        [Required]
        [StringLength(17)]
        [RegularExpression(@"^[0-9]{4}-[0-9]{6}-[0-9]{3}-[0-9]$", ErrorMessage = "El formato de NIT es incorrecto. Formato correcto 9999-999999-999-9")]
        public string NIT { get; set; }

        [Required]
        [StringLength(9)]
        [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "El formato de ISSS es incorrecto. El formato correcto es: 999999999")]
        public string ISSS { get; set; }

        [Required]
        [StringLength(12)]
        [RegularExpression(@"^[0-9]{12}$", ErrorMessage = "El formato de NUP es incorrecto. El formato correcto es: 999999999999")]
        public string NUP { get; set; }
        
        [Range(0.0, Double.MaxValue, ErrorMessage = "Debe de ser un valor positivo")]
        public decimal SALARIO_BASE { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(60)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El formato de correo no es valido")]
        public string CORREO_PERSONAL { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El formato de correo no es valido")]
        [StringLength(60)]
        public string CORREO_INSTITUCIONAL { get; set; }

        public bool? COMISION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DESCUENTO_EMPLEADO> descuento_empleados { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INGRESO_EMPLEADO> ingreso_empleados { get; set; }

    }
}
