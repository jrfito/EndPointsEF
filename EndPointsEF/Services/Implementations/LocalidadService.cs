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
    public class LocalidadService : ILocalidadService
    {
        private readonly MyDbContext _dbContext;
        private readonly IMapper _mapper;
        public LocalidadService(MyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public MyDbContext DbContext { get; }
        public IMapper Mapper { get; }

        public async Task<LocalidadModel> GetLocalidadById(string idLocalidad)
        {
            //var localidad = await this._dbContext.Localidad.FindAsync(idLocalidad);
            return (this._mapper.Map<LocalidadModel>(await this._dbContext.Localidad.FindAsync(idLocalidad)));
        }

        public async Task<LocalidadWithChildrensModel> GetLocalidadByIdWithChildrens(string idLocalidad)
        {
            var localidad = this._mapper.Map<LocalidadWithChildrensModel>(await this._dbContext.Localidad.FindAsync(idLocalidad));
            return (localidad);
        }

        public async Task<LocalidadModel> PostLocalidad(LocalidadPostModel model)
        {
            var localidad = this._dbContext.Localidad.Add(this._mapper.Map<LocalidadEntity>(model));
                ////new LocalidadEntity { Id= model.Id, NombreLocalidad = model.NombreLocalidad, ParentId = model.ParentId };            
            await this._dbContext.SaveChangesAsync();
            return (this._mapper.Map<LocalidadModel>(localidad));
        }
    }
}
