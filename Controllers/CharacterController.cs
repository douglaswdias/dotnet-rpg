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

    [HttpGet("GetAll")]
    public async Task<ActionResult<ServiceResponse<List<Character>>>> Get()
    {
        return Ok(await _characterService.GetAllCharacters());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Character>>> GetCharacter(int id)
    {
        return Ok(await _characterService.GetCharacterById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<Character>>>> AddCharacter(Character newCaracter)
    {
        return Ok(await _characterService.AddCharacter(newCaracter));
    }
}