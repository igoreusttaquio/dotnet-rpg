using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Data;
using dotnet_rpg.Dtos.Character;
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

        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            serviceResponse.Data = GetAllCharactersToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = GetAllCharactersToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = _context.Characters.FirstOrDefault(c => c.Id == id);
            if (character != null)
            {
                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
                return serviceResponse;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdtateCharacterDto updateCharacter)
        {
            ServiceResponse<GetCharacterDto> response = new();
            try
            {
                Character character = _context.Characters.FirstOrDefault(c => c.Id == updateCharacter.Id);

                _mapper.Map(source: updateCharacter, destination: character);
                await _context.SaveChangesAsync();
                // character.Name = updateCharacter.Name;
                // character.HitPoints = updateCharacter.HitPoints;
                // character.Strength = updateCharacter.Strength;
                // character.Defense = updateCharacter.Defense;
                // character.Intelligence = updateCharacter.Intelligence;
                // character.Class = updateCharacter.Class;

                response.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                response.Sucess = false;
                response.Message = ex.Message;

            }

            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> response = new();
            try
            {
                Character character = _context.Characters.First(c => c.Id == id);
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
                response.Data = GetAllCharactersToList();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Sucess = false;
            }

            return response;
        }
        private List<GetCharacterDto> GetAllCharactersToList()
        {
            return _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
        }
    }
}