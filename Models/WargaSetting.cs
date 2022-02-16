namespace managemen1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WargaSetting")]
    public partial class WargaSetting
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WargaSetting()
        {
            Wargas = new HashSet<Warga>();
        }

        [Key]
        public int WargaSetId { get; set; }

        [Required]
        [StringLength(50)]
        public string WargaSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Warga> Wargas { get; set; }
    }
}
