using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointsEF.Models
{
    public class MuebleModel
    {
        private DateTime _fecha;

        public MuebleModel(DateTime? fecha)
        {
            this._fecha =  fecha.Value;
        }
        public DateTime Fecha { get {
                return this._fecha;
            } }
        public int Id { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public decimal Precio { get; set; }
    }
}
