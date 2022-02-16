using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace managemen1
{
    public class userserViewModel
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

        public string User_fk_Set { get; set; }
    }
}