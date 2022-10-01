using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CaracterService
{
    public class CharacterService : ICharacterService
    {
        private static Character mockCharacter = new Character { Name = "Frodo" };
        private static List<Character> mockCharacters = new List<Character>{
            mockCharacter,
            new Character { Name = "Jinx", Id = 1 , Class = RpgClass.Cleric},
            new Character { Name = "Lucian", Id = 2 },
            new Character { Name = "Thresh", Id = 3, Class = RpgClass.Mage},
            new Character { Name =  "Blitzcranck", Id = 4, HitPoints = 100, Strength = 80,
                Defense = 50, Intelligence = 15, Class = RpgClass.Mage }
        };

        public async Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<Character>>();

            if (mockCharacters.Any(c => c.Id == newCharacter.Id)) return serviceResponse;
            mockCharacters.Add(newCharacter);
            serviceResponse.Data = mockCharacters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<Character>>();
            serviceResponse.Data = mockCharacters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Character>>? GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<Character>();
            if (mockCharacters.Any(c => c.Id == id)){
                serviceResponse.Data = mockCharacters.Find(c => c.Id == id)!;
                return serviceResponse;
            }
            return serviceResponse;
        }
    }
}