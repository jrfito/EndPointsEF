using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointsEF.DataEntities
{
    public class ClienteEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Calle { get; set; }
        public string NumeroExterior { get; set; }
        public string Colonia { get; set; }
        public string CodigoPostal { get; set; }
        public string Telefono { get; set; }

        public virtual IEnumerable<FacturaEntity> Facturas { get; set; }
    }
}
