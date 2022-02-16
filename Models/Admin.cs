namespace managemen1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required]
        [StringLength(50)]
        public string Ad_UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Ad_Password { get; set; }
    }
}
