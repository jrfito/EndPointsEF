using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using EndPointsEF.Models;
using EndPointsEF.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EndPointsEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _facturaService;

        public FacturaController(IFacturaService facturaService)
        {
            this._facturaService = facturaService;
        }

        [HttpPost()]
        public async Task<IActionResult> Post(FacturaModel request)
        {

            return Ok(await this._facturaService.PostFacturaAsync(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFacturaId(int id)
        {
            var factura = await this._facturaService.GetFacturaByIdAsync(id);
            return Ok(factura);
        }
    }
}
