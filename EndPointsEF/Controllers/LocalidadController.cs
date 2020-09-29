using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndPointsEF.DataContext;
using EndPointsEF.Models;
using EndPointsEF.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EndPointsEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadController : ControllerBase
    {
        private readonly ILocalidadService _localidadService;
        public LocalidadController(ILocalidadService localidadService)
        {
            _localidadService = localidadService;
        }

        public ILocalidadService LocalidadService { get; }

        [HttpPost]
        public async Task<IActionResult> Post(LocalidadPostModel request)
        {

            return Ok(await this._localidadService.PostLocalidad(request));
        }

        [HttpGet("{idLocalidad}")]
        public async Task<IActionResult> GetById(string idLocalidad)
        {

            var localidad = await this._localidadService.GetLocalidadById(idLocalidad);
            //var serilizedLocalidad = JsonSerializer.Serialize(localidad);
            return Ok("Tan Tan");
        }

        [HttpGet("Childrens/{idLocalidad}")]
        public async Task<IActionResult> GetByIdChildrens(string idLocalidad)
        {

            var localidad = await this._localidadService.GetLocalidadByIdWithChildrens(idLocalidad);
            //var localidadWithchildrens = new { id = localidad.Id, Parent = localidad.Parent, childrens = localidad.Childrens };
            //var serilizedLocalidad = JsonSerializer.Serialize(localidad);
            return Ok(localidad);
        }
    }
}
