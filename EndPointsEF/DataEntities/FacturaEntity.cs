using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointsEF.DataEntities
{
    public class FacturaEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        [ForeignKey("ClienteEntityId")]
        public int ClienteId { get; set; }

        public virtual ClienteEntity Cliente { get; set; }
        public virtual IEnumerable<DetalleFacturaEntity> DetalleFactura { get; set; }

    }
}
