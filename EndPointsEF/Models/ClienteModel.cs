using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointsEF.Models
{
    public class ClienteModelRequest
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Calle { get; set; }
        public string NumeroExterior { get; set; }
        public string Colonia { get; set; }
        public string CodigoPostal { get; set; }
    }
    public class ClienteModel
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public string Domicilio { get; set; }
    }
}
