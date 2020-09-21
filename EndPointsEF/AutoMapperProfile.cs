using AutoMapper;
using EndPointsEF.DataEntities;
using EndPointsEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointsEF
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            SetUserMappings();
        }

        private void SetUserMappings()
        {
            // Cliente
            CreateMap<ClienteModel, ClienteEntity>();
            CreateMap<ClienteEntity, ClienteModel>();

            // Factura
            CreateMap<FacturaModel, FacturaEntity>();
            CreateMap<FacturaEntity, FacturaModel>();
            CreateMap<FacturaEntity, FacturaFullModel>();
        }
    }
}
