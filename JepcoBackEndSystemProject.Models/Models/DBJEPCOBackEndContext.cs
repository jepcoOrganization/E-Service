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


        public virtual DbSet<TbBranchesLookup> tb_BranchesLookup { get; set; }
        public virtual DbSet<TbCitiesLookup> tb_CitiesLookup { get; set; }
      




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<TbBranchesLookup>(entity =>
            {
                entity.HasKey(e => new { e.BranchID });

                entity.ToTable("tb_BranchesLookup");



            });

           


            modelBuilder.Entity<TbCitiesLookup>(entity =>
            {
                entity.HasKey(e => new { e.ID  });

                entity.ToTable("tb_CitiesLookup");



            });






            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

