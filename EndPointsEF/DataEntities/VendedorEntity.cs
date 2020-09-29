using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointsEF.DataEntities
{
    public class VendedorEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        
        public string Celular { get; set; }

        public int? ClienteId { get; set; }

    }
}
