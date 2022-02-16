namespace managemen1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserLogin")]
    public partial class UserLogin
    {
        [Key]
        public int UserLoginId { get; set; }

        [Required]
        [StringLength(50)]
        [Display (Name ="User Name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }

        [Required]
        public string UserImage { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "No Telp")]
        public string UserContact { get; set; }
    }
}
