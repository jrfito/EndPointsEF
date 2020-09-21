using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointsEF.DataEntities
{
    public class DetalleFacturaEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("FacturaEntityId")]
        public int FacturaId { get; set; }
        [ForeignKey("MuebleEntityId")]
        public int MuebleId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public virtual FacturaEntity Factura { get; set; }
        public virtual MuebleEntity Mueble { get; set; }

    }
}
