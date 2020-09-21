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
    public class ClienteService : IClienteService
    {
        private readonly MyDbContext _dbContext;
        private readonly IMapper _mapper;

        public ClienteService(MyDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }
        public async Task<ClienteEntity> PostCliente(ClienteModel model)
        {
            var cliente = this._dbContext.Set<ClienteEntity>().Add(this._mapper.Map<ClienteEntity>(model));
            await this._dbContext.SaveChangesAsync();
            return cliente.Entity;
        }
    }
}
