using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Data;
using Microsoft.AspNetCore.Mvc;
using dotnet_rpg.Services.CaracterService;
using dotnet_rpg.Dtos.User;
using dotnet_rpg.Models;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;

        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response = await _authRepository.Register(
                new User { Username = request.Username }, request.Password
            );
            
            if (!response.Sucess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto request)
        {
            var response = await _authRepository.Login(
                request.Username, request.Password
            );
            
            if (!response.Sucess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}