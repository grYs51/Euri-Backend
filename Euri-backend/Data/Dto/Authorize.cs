namespace Euri_backend.Data.Dto;

public class Authorize
{
    public string AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}