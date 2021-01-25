using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointsEF.DataEntities.ContacEntities
{
    public class AreaEntitiy
    {
        [Key]
        [StringLength(11)]
        public string id_area { get; set; }
        [StringLength(50)]
        public string area_nombre { get; set; }
        [StringLength(150)]
        public string area_descripcion { get; set; }
        
    }
}
