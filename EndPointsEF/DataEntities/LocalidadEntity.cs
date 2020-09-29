using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointsEF.DataEntities
{
    public class LocalidadEntity
    {
        [Key]
        [StringLength(2)]
        public string Id { get; set; }
        [StringLength(150)]
        public string NombreLocalidad { get; set; }
        [ForeignKey("LocalidadEntityId")]
        [StringLength(2)]
        public string ParentId { get; set; }

        public virtual LocalidadEntity Parent { get; set; }
        public virtual IEnumerable<LocalidadEntity> Childrens { get; set; }
    }
}
