using AutoMapper;
using EndPointsEF.DataContext;
using EndPointsEF.DataEntities;
using EndPointsEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointsEF.Services.Implementations
{
    public class FacturaService : IFacturaService
    {
        private readonly MyDbContext _dbContext;
        private readonly IMapper _mapper;

        public FacturaService(MyDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public async Task<FacturaFullModel> GetFacturaByIdAsync(int id)

        {
            // Get factura
            var factura = await this._dbContext.Set<FacturaEntity>().FindAsync(id);
            // other way to get factura
            var factura2 = await this._dbContext.Factura.FindAsync(id);

            return this._mapper.Map<FacturaFullModel>(await this._dbContext.Set<FacturaEntity>().FindAsync(id));
        }

        public async Task<FacturaEntity> PostFacturaAsync(FacturaModel model)
        {
            var factura = this._dbContext.Set<FacturaEntity>().Add(this._mapper.Map<FacturaEntity>(model));
            await this._dbContext.SaveChangesAsync();
            return factura.Entity;
        }
    }
}
