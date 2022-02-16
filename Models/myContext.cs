namespace managemen1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using MySql.Data.MySqlClient;

    public partial class myContext : DbContext
    {
        public myContext()
            : base("name=myContext")
        {
        }
        public virtual DbSet<userser> usersers { get; set; }
        public virtual DbSet<AdminLogin> AdminLogins { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<WargaLogin> WargaLogins { get; set; }

        public virtual DbSet<warga1> warga1 { get; set; }
        //public virtual DbSet<Admin> Admins { get; set; }

        public virtual DbSet<UsersSetting> UsersSettings { get; set; }
        public virtual DbSet<Warga> Wargas { get; set; }
        public virtual DbSet<WargaSetting> WargaSettings { get; set; }
        public virtual DbSet<WargaSettingAnggota> WargaSettingAnggotas { get; set; }
        public virtual DbSet<WargaSettingRumah> WargaSettingRumahs { get; set; }
        public virtual DbSet<user> users { get; set; }

       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
