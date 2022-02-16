using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace managemen1
{
    public class displayDataWargaViewModel
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

        public string Warga_fk_Set { get; set; }

        public string Warga_fk_SetRumah { get; set; }

        public string Warga_fk_AnggotaKeluarga { get; set; }

    }
}