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


       
        public virtual DbSet<tb_ElectricalFaultStatus> tb_ElectricalFaultStatus { get; set; }
        public virtual DbSet<tb_Fault_Compliants> tb_Fault_Compliants { get; set; }
        public virtual DbSet<tb_FaultDetails> tb_FaultDetails { get; set; }
        public virtual DbSet<tb_RepairingStatus> tb_RepairingStatus { get; set; }
        public virtual DbSet<tb_UserAccessRegister> tb_UserAccessRegister { get; set; }

     





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

     

            modelBuilder.Entity<tb_ElectricalFaultStatus>(entity =>
            {
                entity.HasKey(e => new { e.FaultStatusID });
                entity.ToTable("tb_ElectricalFaultStatus");
                


            });

            modelBuilder.Entity<tb_Fault_Compliants>(entity =>
            {
                entity.HasKey(e => new { e.FaultComplaintID });
                entity.ToTable("tb_Fault_Compliants");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
                entity.Property(e => e.CompliantDateTime).HasColumnType("datetime");



            });

            modelBuilder.Entity<tb_RepairingStatus>(entity =>
            {
                entity.HasKey(e => new { e.RepairingStatusID });
                entity.ToTable("tb_RepairingStatus");

            });

            modelBuilder.Entity<tb_UserAccessRegister>(entity =>
            {
                entity.HasKey(e => new { e.ID  });
                entity.ToTable("tb_UserAccessRegister");

            });


            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

