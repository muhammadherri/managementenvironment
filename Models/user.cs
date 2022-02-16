namespace managemen1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string UserEmail { get; set; }

        [Required]
        [StringLength(50)]
        public string UserNoTelp { get; set; }

        [Required]
        public string UserImage { get; set; }

        public int? User_fk_Set { get; set; }
    }
}
