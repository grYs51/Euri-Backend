using Euri_backend.Data.Dto;
using Euri_backend.Data.Models;
using Euri_backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Euri_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase
{
    private readonly IUserService _userService;

    public UserController([FromServices] IUserService service)
    {
        _userService = service;
    }
    
    [Route("{id}")]
    [HttpGet]
    public async Task<ActionResult<UserModel>> Get(string id)
    {
        // parse id to int
        if(!int.TryParse(id, out var userId))
        {
            BadRequest("Invalid user id");
        }
        var user = await _userService.GetUser(userId);
        if (user == null)
        {
            return NotFound("No user found");
        }
        return Ok(user);
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserModel>>> GetAll()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users);
    }
    
    [HttpPost]
    public async Task<ActionResult<UserModel>> Post([FromBody] UserToBeCreatedDto user)
    {
        try
        {
            if (user is null)
            {
                return BadRequest("User object is null");
            }
            
            if( !ModelState.IsValid)
            {
                return BadRequest("Invalid model state");
            }
            
            var userEntity = await _userService.CreateUser(user);
            
            return CreatedAtAction(nameof(Get), new { id = userEntity.Id }, userEntity);

            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        // var newUser = await _userService.CreateUser(user);
    }
}