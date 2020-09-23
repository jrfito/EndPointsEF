using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointsEF.DataEntities
{
    public class AnotationEntity
    {
        [Key]
        public int IdKey { get; set; }

        [StringLength(10)]
        public string StringNVarCharTen { get; set; }

        [Column(TypeName = "VarChar(10)")]
        [StringLength(10)]
        public string StringVarCharTen { get; set; }

        public string StringNVarCharMax { get; set; }

        [Column(TypeName = "Text")]
        public string StringText { get; set; }

    }
}
