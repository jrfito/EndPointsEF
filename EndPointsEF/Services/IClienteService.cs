using EndPointsEF.DataEntities;
using EndPointsEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointsEF.Services
{
    public interface IClienteService
    {
        Task<ClienteEntity> PostCliente(ClienteModelRequest model);
    }
}
