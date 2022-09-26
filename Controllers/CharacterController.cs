using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_rpg.Models;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CharacterController : ControllerBase
    {
        private static Character mockCharacter = new Character { Name = "Frodo" };
        [HttpGet]
        public ActionResult<Character> Get()
        {
            return Ok(mockCharacter);
        }
    }
}