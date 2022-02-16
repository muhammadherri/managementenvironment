namespace managemen1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class warga1
    {
        [Key]
        public int WargaId { get; set; }

        [Required]
        [StringLength(50)]
        public string WargaName { get; set; }

        [Required]
        [StringLength(50)]
        public string WargaNoTelp { get; set; }

        [Required]
        public string WargaImage { get; set; }

        public int? Warga_fk_Set { get; set; }

        public int? Warga_fk_SetRumah { get; set; }

        public int? Warga_fk_AnggotaKeluarga { get; set; }
    }
}
