namespace SAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MENU")]
    public partial class MENU
    {
        [Key]
        public int ID_MENU { get; set; }

        public int? MEN_ID_MENU { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE_MENU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MENU> MENU1 { get; set; }

        public virtual MENU MENU2 { get; set; }
    }
}
