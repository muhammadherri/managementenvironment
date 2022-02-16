namespace managemen1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("userser")]
    public partial class userser
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

        //private Paging GetListPaging(int start, int length, string v, int intyear)
        //{
        //    Paging result = new Paging();
        //    try
        //    {
        //        IQueryable<dynamic> data = null;
        //        int intCount;
        //        using (myContext db = new myContext())
        //        {
        //            result.data = new List<List<string>>();
        //            var query = from a in db.usersers
        //                        join b in db.UsersSettings on a.User_fk_Set equals b.UserSetId
        //                        where (intyear == 0 || a.UserName == intyear)
        //                        select new { a.UserId, a.UserEmail, a.UserNoTelp, a.UserImage, a.User_fk_Set };

        //            intCount = query.Count();
        //            data = query.OrderByDescending(x => x.UserId).Skip(start).Take(length);
        //            int intLoop = 1;
        //            foreach (var item in data)
        //            {
        //                result.data.Add(new List<string>());
        //                result.data[result.data.Count - 1].Add(item.UserId.ToString());
        //                result.data[result.data.Count - 1].Add(item.UserEmail.ToString());
        //                result.data[result.data.Count - 1].Add(item.UserNoTelp.ToString());
        //                result.data[result.data.Count - 1].Add(item.UserImage.ToString());
        //                result.data[result.data.Count - 1].Add(item.User_fk_Set.ToString());
        //            }
        //        }
        //    }
        //}
    }
}
