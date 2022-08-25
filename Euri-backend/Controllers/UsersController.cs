using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Euri_backend.Data.Dto;
using Euri_backend.Data.Dto.Identity;
using Euri_backend.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Euri_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _repository;

    public UsersController(IUserRepository repository)
    {
        _repository = repository;
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<ActionResult<UserDto>> Get(int id)
    {
        var user = await _repository.GetUser(id);
        if (user == null) return NotFound("No user found");

        var userDto = new UserDto(user);
        return Ok(userDto);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
    {
        var users = await _repository.GetAllUsers();

        var usersDtos = users.Select(user => new UserDto(user));

        return Ok(usersDtos);
    }

    [HttpPost, Authorize]
    public async Task<ActionResult<UserDto>> Post([FromBody] CreateUserDto user)
    {
        try
        {
            if (user is null) return BadRequest("User object is null");

            if (!ModelState.IsValid) return BadRequest("Invalid model state");

            var userEntity = await _repository.CreateUser(user.MapToUserModel());

            return CreatedAtAction(nameof(Get), new { id = userEntity.Id }, new UserDto(userEntity));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut("{id}"), Authorize]
    public async Task<ActionResult<UserDto>> PutUser(int id, UpdatedUserDto user)
    {
        if (id != user.Id) return BadRequest();

        var newUser = await _repository.UpdateUser(user.MapToUserModel(user));

        if (newUser == null) return NotFound();

        return Ok(new UserDto(newUser));
    }

    [HttpDelete("{id}"), Authorize]
    public async Task<IActionResult> DeleteUser(int id)
    {
        if (id == 0) return BadRequest();

        var user = await _repository.DeleteUser(id);
        if (user == null) return NotFound();

        return NoContent();
    }
}