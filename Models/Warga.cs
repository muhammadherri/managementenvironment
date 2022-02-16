namespace managemen1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Warga")]
    public partial class Warga
    {
        [Key]
        public int WargaId { get; set; }

        [Required]
        [StringLength(50)]
        public string WargaName { get; set; }

        public int Warga_fk_Set { get; set; }

        public int Warga_fk_SetRumah { get; set; }

        public int Warga_fk_AnggotaKeluarga { get; set; }

        public int WargaNoTelp { get; set; }

        [Required]
        [StringLength(50)]
        public string WargaImage { get; set; }
    }
}
