namespace managemen1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WargaSettingAnggota")]
    public partial class WargaSettingAnggota
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WargaSettingAnggota()
        {
            Wargas = new HashSet<Warga>();
        }

        [Key]
        public int WargaSetId { get; set; }

        [Required]
        [StringLength(50)]
        public string WargaAnggotaKeluarga { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Warga> Wargas { get; set; }
    }
}
