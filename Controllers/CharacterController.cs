using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_rpg.Models;
using dotnet_rpg.Services.CaracterService;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public ActionResult<List<Character>> Get()
        {
            return Ok(_characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        // To Know more search for Attribute routing.
        public ActionResult<Character> Get(int id)
        {
            var character = _characterService.GetCharacterById(id);
            return character == null ? NotFound() : Ok(character);
        }

        [HttpPost]
        public ActionResult Post(Character character)
        {
            return CreatedAtAction(nameof(Get), _characterService.AddCharacter(character));
        }
    }
}