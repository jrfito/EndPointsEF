using EndPointsEF.DataContext;
using EndPointsEF.DataEntities;
using EndPointsEF.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointsEF.Services.Implementations
{
    public class MuebleService : IMuebleService
    {
        private readonly MyDbContext _dbContext;

        public MuebleService(MyDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<MuebleEntity> PostMueble(MuebleModel model)
        {
            MuebleEntity mueble = new MuebleEntity
            {
                Marca = model.Marca,
                Modelo = model.Modelo,
                Precio = model.Precio
            };

            this._dbContext.Set<MuebleEntity>().Add(mueble);

            await this._dbContext.SaveChangesAsync();

            return mueble;
        }

        public async Task<IEnumerable<MuebleEntity>> GetMuebles()
        {
            return await this._dbContext.Set<MuebleEntity>().ToListAsync();
        }

        public async Task DeleteMueble(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<MuebleEntity> GetMuebleById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<MuebleEntity> PutMueble(MuebleModel model)
        {
            throw new NotImplementedException();
        }
    }
}
