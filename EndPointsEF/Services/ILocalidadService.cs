using EndPointsEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointsEF.Services
{
    public interface ILocalidadService
    {
        Task<LocalidadModel> PostLocalidad(LocalidadPostModel model);

        Task<LocalidadModel> GetLocalidadById(string idLocalidad);
        Task<LocalidadWithChildrensModel> GetLocalidadByIdWithChildrens(string idLocalidad);
    }
}
