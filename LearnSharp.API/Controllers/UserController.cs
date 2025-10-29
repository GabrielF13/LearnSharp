using LearnSharp.Application.Dtos;
using LearnSharp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LearnSharp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetUserById(
    [FromRoute] Guid id,
    CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _userService.GetUserByIdAsync(id, cancellationToken);

            return Ok(user);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateUser(
    [FromBody] UserDto createUserDto,
    CancellationToken cancellationToken = default)
    {
        try
        {
            if (createUserDto == null)
            {
                return BadRequest("Dados do usuário são obrigatórios.");
            }

            var createdUser = await _userService.CreateUserAsync(createUserDto, cancellationToken);

            return Ok();
        }
        catch (Exception ex)
        {
            // Log da exceção
            // _logger.LogError(ex, "Erro ao criar usuário");

            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro interno do servidor ao criar o usuário.");
        }
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateUser(
        [FromRoute] Guid id,
        [FromBody] UserDto updateUserDto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            // Validação básica do ID
            if (id == Guid.Empty)
            {
                return BadRequest("ID não pode ser vazio.");
            }

            // Validação do modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (updateUserDto == null)
            {
                return BadRequest("Dados do usuário são obrigatórios.");
            }

            var updatedUser = await _userService.UpdateUserAsync(updateUserDto, cancellationToken);

            if (updatedUser == null)
            {
                return NotFound($"Usuário com ID {id} não foi encontrado.");
            }

            return Ok(updatedUser);
        }
        catch (Exception ex)
        {
            // Log da exceção
            // _logger.LogError(ex, "Erro ao atualizar usuário com ID {UserId}", id);

            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro interno do servidor ao atualizar o usuário.");
        }
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteUser(
        [FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        try
        {
            // Validação básica do ID
            if (id == Guid.Empty)
            {
                return BadRequest("ID não pode ser vazio.");
            }

            var deleted = await _userService.DeleteUserAsync(id, cancellationToken);

            if (!deleted)
            {
                return NotFound($"Usuário com ID {id} não foi encontrado.");
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            // Log da exceção
            // _logger.LogError(ex, "Erro ao deletar usuário com ID {UserId}", id);

            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro interno do servidor ao deletar o usuário.");
        }
    }
}