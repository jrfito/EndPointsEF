using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointsEF.DataEntities
{
    public class TipoMuebleEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Descripcion { get; set; }

        public int NumeroRegistro { get; set; }
    }
}
