using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndPointsEF.DataEntities.ContacEntities;

namespace EndPointsEF.DataContext
{
    public class abcDbContext : DbContext
    {
        public abcDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<AreaEntitiy> Area { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AreaEntitiy>(entity =>
            {
                entity.HasKey(e => e.id_area);
                entity.ToTable("area");
                entity.Property(e => e.area_nombre)
                    .HasColumnName("area_nombre")
                    .HasMaxLength(50);
                entity.Property(e => e.area_descripcion)
                    .HasColumnName("area_descripcion")
                    .HasMaxLength(150);

            });
            modelBuilder.Entity<AmonestacionEntity>(entity => {
                entity.HasKey(e => e.id_amonestacion);
                entity.ToTable("amonestacion");
                entity.Property(e => e.id_autorizado)
                    .HasColumnName("id_autorizado");
                entity.Property(e => e.amonestacion_fecha)
                    .HasColumnName("amonestacion_fecha");
                entity.Property(e => e.amonestacion_concepto)
                    .HasColumnName("amonestacion_concepto");
            });
        }
    }
}
