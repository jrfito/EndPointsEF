using EndPointsEF.DataEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointsEF.DataContext
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Le asigna un nombre a la Entidad
            // modelBuilder.Entity<ClienteEntity>().ToTable("Customer");
            //  LLaves Foraneas
            //modelBuilder.Entity<FacturaEntity>()
            //    .HasKey(key => key.ClienteId);
            //Data Seed o Inserts en la tabla
            modelBuilder.Entity<TipoMuebleEntity>().HasData(new TipoMuebleEntity
            {
                Id = 1,
                Descripcion = "Linea Blanca"
            });
            modelBuilder.Entity<TipoMuebleEntity>().HasData(new TipoMuebleEntity
            {
                Id = 2,
                Descripcion = "Electrodomesticos"
            });
            modelBuilder.Entity<TipoMuebleEntity>().HasData(new TipoMuebleEntity
            {
                Id = 3,
                Descripcion = "Electrónica"
            });

            // Genera un indice a la descripción
            modelBuilder.Entity<TipoMuebleEntity>().HasIndex(idx => idx.Descripcion);

            // Manejo de propiedades
            // Autoincrementable
            //modelBuilder.Entity<TipoMuebleEntity>()
            //    .Property(p => p.NumeroRegistro)
            //    .ValueGeneratedOnAdd();

            // Poner valor default a una propiedad
            //modelBuilder.Entity<MuebleEntity>().Property(mu => mu.Modelo).HasDefaultValue("XX");
        }

        public DbSet<TipoMuebleEntity> TipoMueble { get; set; }
        public DbSet<MuebleEntity> Mueble { get; set; }

        public DbSet<ClienteEntity> Cliente { get; set; }

        public DbSet<FacturaEntity> Factura { get; set; }

        public DbSet<DetalleFacturaEntity> DetalleFactura { get; set; }

        public DbSet<AnotationEntity> AnotationExample { get; set; }

        public DbSet<VendedorEntity> Vendedor { get; set; }

        public DbSet<LocalidadEntity> Localidad { get; set; }


    }
}
