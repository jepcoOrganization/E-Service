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
                entity.HasMany(e => e.tb_Fault_Compliants);
                entity.ToTable("tb_ElectricalFaultStatus");
                


            });

            modelBuilder.Entity<tb_Fault_Compliants>(entity =>
            {
                entity.HasKey(e => new { e.FaultComplaintID });
                entity.HasMany(e => e.tb_FaultDetails);
                entity.ToTable("tb_Fault_Compliants");

            });

            modelBuilder.Entity<tb_RepairingStatus>(entity =>
            {
                entity.HasKey(e => new { e.RepairingStatusID });
                entity.ToTable("tb_RepairingStatus");

            });






            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

