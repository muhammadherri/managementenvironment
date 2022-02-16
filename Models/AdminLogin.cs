namespace managemen1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdminLogin")]
    public partial class AdminLogin
    {
        [Key]
        public int AdminLoginId { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminUserName { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminPassword { get; set; }
    }
}
