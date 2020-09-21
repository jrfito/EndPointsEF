using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndPointsEF.Models;
using EndPointsEF.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EndPointsEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuebleController : ControllerBase
    {
        private readonly IMuebleService _muebleService;
        public MuebleController(IMuebleService muebleService)
        {
            this._muebleService = muebleService;
        }

        [HttpPost()]
        public async Task<IActionResult> Post(MuebleModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var mueble = await this._muebleService.PostMueble(request);
            return Ok(mueble);
        }
     
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            return Ok(await this._muebleService.GetMuebles());
        }
    }
}
