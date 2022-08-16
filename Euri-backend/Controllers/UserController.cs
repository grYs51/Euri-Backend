using Euri_backend.Data.Models;
using Euri_backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Euri_backend.Controllers;

[ApiController]
[Route("[controller]")]
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
        
        var user = await _userService.GetUser(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(User);
    }
    [HttpGet]
    public async Task<IEnumerable<UserModel>> GetAll()
    {
        var users = await _userService.GetAllUsers();
        return users;
    }
}