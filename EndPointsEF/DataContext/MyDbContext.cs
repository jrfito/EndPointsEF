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

        public DbSet<MuebleEntity> Mueble { get; set; }

        public DbSet<ClienteEntity> Cliente { get; set; }

        public DbSet<FacturaEntity> Factura { get; set; }

        public DbSet<DetalleFacturaEntity> DetalleFactura { get; set; }
    }
}
