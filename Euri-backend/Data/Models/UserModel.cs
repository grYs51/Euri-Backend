﻿namespace Euri_backend.Data.Models;

public class UserModel
{
    public string Id { get; set; }
    public string FirstName { get;  set; }
    public string LastName { get;  set; }
    public string Email { get;  set; }
    public string Role { get;  set; }
    public string Password { get;  set; }
    public AdressModel Adress { get;  set; }
}
