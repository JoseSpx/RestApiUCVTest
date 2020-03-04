using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.Layer.Clementina;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Layer.Clementina;

namespace ApiUCVTest.Controllers.Clementina
{
    [Route("api/clementina/[controller]")]
    [Authorize]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public readonly IClienteClementinaService _clienteClementinaService;

        public ClienteController(IClienteClementinaService clienteClementinaService)
        {
            _clienteClementinaService = clienteClementinaService;
        }

        [HttpPost]
        public IActionResult InsertarCliente([FromBody] ClienteClementinaDto clienteClementinaDto)
        {
            var response = _clienteClementinaService.InsertarCliente(clienteClementinaDto);
            if (!response.Success)
                return BadRequest();
            return Ok();
        }
    }
}