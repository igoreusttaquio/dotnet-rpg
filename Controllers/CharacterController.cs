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
        private static List<Character> mockCharacters = new List<Character>{
            mockCharacter,
            new Character { Name = "Jinx", Id = 1 , Class = RpgClass.Cleric},
            new Character { Name = "Lucian", Id = 2 },
            new Character { Name = "Thresh", Id = 3, Class = RpgClass.Mage}
        };

        [HttpGet]
        public ActionResult<List<Character>> Get()
        {
            return Ok(mockCharacters);
        }

        [HttpGet("{id}")]
        // To Know more search for Attribute routing.
        public ActionResult<Character> Get(int id)
        {
            if (mockCharacters.Any(c => c.Id == id))
                return Ok(mockCharacters.Find(c => c.Id == id));
            return NotFound();
        }
    }
}