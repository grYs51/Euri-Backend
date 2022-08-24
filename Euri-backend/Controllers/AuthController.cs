using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Euri_backend.Data.Dto;
using Euri_backend.Data.Dto.Identity;
using Euri_backend.Data.Models;
using Euri_backend.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Euri_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _repository;
    private readonly IConfiguration _configuration;

    public AuthController(IUserRepository repository, IConfiguration configuration)
    {
        _repository = repository;
        _configuration = configuration;
    }

    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Authorize))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPost("login")]
    public async Task<IActionResult> Login(AuthenticationRequest model)
    {
        var user = await _repository.Login(model.Email, model.Password);
        if (user == null) return Unauthorized();

        var token = CreateToken(user);

        if (user.RefreshToken == null)
        {
            var refreshToken = CreateRefreshToken();
            var expiration = DateTime.UtcNow.AddMinutes(5);
            user.RefreshToken = refreshToken;
            user.ExpireTime = expiration;
            await _repository.UpdateUser(user);

        }
        

        var authorize = new Authorize()
        {
            AccessToken = token,
            RefreshToken = user.RefreshToken
        };
        return Ok(authorize);
    }

    private string CreateToken(UserModel user)
    {
        var issuer = _configuration["JwtConfig:validIssuer"];
        var audience = _configuration["JwtConfig:validAudience"];

        var key = Encoding.ASCII.GetBytes
            (_configuration["JwtConfig:secretKey"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString()),
            }),
            Expires = DateTime.UtcNow.AddMinutes(5),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);
        var stringToken = tokenHandler.WriteToken(token);
        
        return stringToken;
    }

    private string CreateRefreshToken()
    {
        var randomNumber = new byte[128];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
}