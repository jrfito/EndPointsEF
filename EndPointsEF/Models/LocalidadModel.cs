using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointsEF.Models
{
    public class LocalidadPostModel
    {
        public string Id { get; set; }
        public string NombreLocalidad { get; set; }
        public string ParentId { get; set; }
    }
    public class LocalidadModel
    {
        public string Id { get; set; }
        public string NombreLocalidad { get; set; }
        public string ParentId { get; set; }
        public LocalidadModel Parent { get; set; }
        public IEnumerable<LocalidadModel> Childrens { get; set; }
    }

    public class LocalidadWithChildrensModel
    {
        public string Id { get; set; }
        public string NombreLocalidad { get; set; }
        public string ParentId { get; set; }
        public LocalidadWithChildrensModel Parent { get; set; }
        public IEnumerable<LocalidadPostModel> LocalidadChildrens { get; set; }
    }
}
