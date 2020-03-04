using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiUCVTest.Auth;
using Domain.Dto.Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Layer;

namespace ApiUCVTest.Controllers.Clementina
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenAuth _tokenAuth;

        public AuthController(IAuthService authService, ITokenAuth tokenAuth)
        {
            _authService = authService;
            _tokenAuth = tokenAuth;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto userLoginDto)
        {
            var response = _authService.Login(userLoginDto.Usuario, userLoginDto.Password);

            if (!response.Success)
                return BadRequest();

            string token = _tokenAuth.GenerateToken(userLoginDto.Usuario);
            return Ok(new { token });
        }


    }
}