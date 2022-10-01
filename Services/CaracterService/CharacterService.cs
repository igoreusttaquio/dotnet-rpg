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

        public List<Character> AddCharacter(Character newCharacter)
        {
            if (mockCharacters.Any(c => c.Id == newCharacter.Id)) return mockCharacters;
            mockCharacters.Add(newCharacter);
            return mockCharacters;
        }

        public List<Character> GetAllCharacters()
        {
            return mockCharacters;
        }

        public Character? GetCharacterById(int id)
        {
            if (mockCharacters.Any(c => c.Id == id))
                return mockCharacters.Find(c => c.Id == id)!;
            return null;
        }
    }
}