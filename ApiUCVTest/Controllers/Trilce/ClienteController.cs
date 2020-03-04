using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.Layer.Trilce;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Layer.Trilce;

namespace ApiUCVTest.Controllers.Trilce
{
    [Route("api/trilce/[controller]")]
    [Authorize]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public readonly IClienteTrilceService _clienteTrilceService;

        public ClienteController(IClienteTrilceService clienteTrilceService)
        {
            _clienteTrilceService = clienteTrilceService;
        }

        [HttpPost]
        public IActionResult InsertarCliente([FromBody] ClienteTrilceDto clienteTrilceDto)
        {
            var response = _clienteTrilceService.InsertarCliente(clienteTrilceDto);
            if (!response.Success)
                return BadRequest();
            return Ok();
        }

    }
}