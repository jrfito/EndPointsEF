using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointsEF.Models
{
    public class FacturaModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
    }

    public class FacturaFullModel : FacturaModel
    {
        public ClienteModel Cliente { get; set; }
    }
}
