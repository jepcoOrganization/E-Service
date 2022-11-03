using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace JepcoBackEndSystemProject.Models.Models
{
    public partial class DBJEPCOBackEndContext : IdentityDbContext
    {
        public DBJEPCOBackEndContext()
        {
        }

        public DBJEPCOBackEndContext(DbContextOptions<DBJEPCOBackEndContext> options)
            : base(options)
        {
        }



        public virtual DbSet<tb_District> tb_District { get; set; }
        public virtual DbSet<tb_FazPowerCapacity> tb_FazPowerCapacity { get; set; }
        public virtual DbSet<tb_Governate> tb_Governate { get; set; }
        public virtual DbSet<tb_MaintenanceRequest> tb_MaintenanceRequest { get; set; }
        public virtual DbSet<tb_MaintenanceRequestType> tb_MaintenanceRequestType { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<tb_District>(entity =>
            {
                entity.HasKey(e => new { e.ID });
                entity.ToTable("tb_District");

            });

            modelBuilder.Entity<tb_FazPowerCapacity>(entity =>
            {
                entity.HasKey(e => new { e.ID });
                entity.ToTable("tb_FazPowerCapacity");

            });
            modelBuilder.Entity<tb_Governate>(entity =>
            {
                entity.HasKey(e => new { e.ID });
                entity.ToTable("tb_Governate");

            });
            modelBuilder.Entity<tb_MaintenanceRequestType>(entity =>
            {
                entity.HasKey(e => new { e.ID });
                entity.ToTable("tb_MaintenanceRequestType");

            });
            modelBuilder.Entity<tb_MaintenanceRequest>(entity =>
            {
                entity.HasKey(e => new { e.ID });
                entity.ToTable("tb_MaintenanceRequest");

            });







            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

