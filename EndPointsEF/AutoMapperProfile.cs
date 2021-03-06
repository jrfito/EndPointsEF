﻿using AutoMapper;
using EndPointsEF.DataEntities;
using EndPointsEF.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
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
            CreateMap<ClienteModelRequest, ClienteEntity>();
            CreateMap<ClienteEntity, ClienteModel>()
                .ForMember(dest => dest.Domicilio, options => options.MapFrom(origin => $"{origin.Calle} Numero Exterior {origin.NumeroExterior}, {origin.Colonia}, {origin.CodigoPostal}"));

            // Factura
            CreateMap<FacturaModel, FacturaEntity>();
            CreateMap<FacturaEntity, FacturaModel>();
            CreateMap<FacturaEntity, FacturaFullModel>();

            // Localidad
            CreateMap<LocalidadPostModel, LocalidadEntity>();
            CreateMap<LocalidadEntity, LocalidadModel>();
           
            // LOcalidad con childrens
            CreateMap<LocalidadEntity, LocalidadPostModel>();
            CreateMap<LocalidadEntity, LocalidadWithChildrensModel>()
               .ForMember(d => d.LocalidadChildrens , options=> options.MapFrom(columnas => columnas.Childrens));

            // Files
            CreateMap<IFormFile, FileUploadModel>()
               .ForMember(d => d.FileName, options => options.MapFrom(columnas => columnas.FileName));
            CreateMap<FileInfo, FileUploadModel>().ForMember(d => d.FileName, options => options.MapFrom(columnas => columnas.Name));
        }
    }
}
