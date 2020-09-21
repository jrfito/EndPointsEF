using EndPointsEF.DataEntities;
using EndPointsEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointsEF.Services
{
    public interface IMuebleService
    {
        Task<IEnumerable<MuebleEntity>> GetMuebles();
        Task<MuebleEntity> GetMuebleById(int Id);
        Task<MuebleEntity> PostMueble(MuebleModel model);
        Task<MuebleEntity> PutMueble(MuebleModel model);
        Task DeleteMueble(int Id);

    }
}
