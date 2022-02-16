namespace managemen1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsersSetting")]
    public partial class UsersSetting
    {
        [Key]
        public int UserSetId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserSet { get; set; }
    }
}
