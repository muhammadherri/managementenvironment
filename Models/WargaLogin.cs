namespace managemen1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WargaLogin")]
    public partial class WargaLogin
    {
        [Key]
        public int WargaLoginId { get; set; }

        [Required]
        [StringLength(50)]
        public string WargaNama { get; set; }

        [Required]
        [StringLength(50)]
        public string WargaPassword { get; set; }

        [Required]
        public string WargaImage { get; set; }

        [Required]
        [StringLength(50)]
        public string WargaContact { get; set; }
    }
}
