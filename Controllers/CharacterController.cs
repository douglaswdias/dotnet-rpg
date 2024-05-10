namespace dotnet_rpg.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService _characterService;

    public CharacterController(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    [HttpGet("v1/GetAll")]
    public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
    {
        return Ok(await _characterService.GetAllCharacters());
    }

    [HttpGet("v1/{id}")]
    public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetCharacter(int id)
    {
        return Ok(await _characterService.GetCharacterById(id));
    }

    [HttpPost("v1")]
    public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCaracter)
    {
        return Ok(await _characterService.AddCharacter(newCaracter));
    }

    [HttpPut("v1")]
    public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacter(UpdateCharacterDto updateCaracter)
    {
        var response = await _characterService.UpdateCharacter(updateCaracter);
        if (response.Data is null)
            return NotFound(response);

        return Ok(response);
    }

    [HttpDelete("v1/{id}")]
    public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> DeleteCharacter(int id)
    {
        var response = await _characterService.DeleteCharacter(id);
        if (response.Data is null)
            return NotFound(response);

        return Ok(response);
    }
}
