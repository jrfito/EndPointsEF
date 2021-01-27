using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointsEF.DataEntities.ContacEntities
{
    public class AmonestacionEntity
    {
        [Key]
        public int id_amonestacion { get; set; }
        [StringLength(50)]
        [ForeignKey("id_autorizado")]
        public int id_autorizado { get; set; }
        public DateTime amonestacion_fecha { get; set; }
        public string amonestacion_concepto { get; set; }

    }
}
