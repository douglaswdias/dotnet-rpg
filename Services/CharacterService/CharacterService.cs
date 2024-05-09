using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private static List<Character> characters = new()
    {
        new Character(),
        new Character { Id = 1, Name = "John" }
    };
    public async Task<ServiceResponse<List<Character>>> AddCharacter(Character newCaracter)
    {
        var serviceResponse = new ServiceResponse<List<Character>>();
        characters.Add(newCaracter);
        serviceResponse.Data = characters;
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
    {
        var serviceResponse = new ServiceResponse<List<Character>>();
        serviceResponse.Data = characters;
        return serviceResponse;
    }

    public async Task<ServiceResponse<Character>> GetCharacterById(int id)
    {
        var serviceResponse = new ServiceResponse<Character>();
        var character = characters.FirstOrDefault(c => c.Id == id);
        serviceResponse.Data = character;

        return serviceResponse;
    }
}